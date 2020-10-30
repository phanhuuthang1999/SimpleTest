using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.XtraEditors;
using PMT.EXAM.DISPLAY;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static PMT.EXAM.DISPLAY.UiCommon;
using static SimpleTest.Common.UICommon;
using EX_CauHoi = DataLayer.DAL.EX_CauHoi;
using EX_CauTraLoi = DataLayer.DAL.EX_CauTraLoi;

namespace SimpleTest.Controls
{
    public partial class UcDienKhuyetChum : UserControlBase
    {
        #region Variable declarations      

        #region Data

        private ES_SoanCauHoiBLL _business;
        private bool _isDienKhuyet;
        private Parsing _parsing;
        private MatchCollection _mathCollection;

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelCauHoi;
        private List<TableLayoutPanel> _lstTablePanelGayNhieu;

        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameLabelDapAn = "lblDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #endregion

        #region Constructors

        public UcDienKhuyetChum()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Events

        #region CauTraLoi

        private void XoaCauTraLoi(object sender, EventArgs e)
        {
            if (ListCauHoi.Count == 1)
            {
                UICommon.ShowMsgWarningString("Số lượng câu hỏi không thể nhỏ hơn 1 \nBạn không thể xóa câu hỏi này");
                return;
            }
            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;
            int rowIndex = tblPanelMain.GetRow(tblPanelDapAn);
            ListIdCauHoiBiXoa.Add(CauHoiCurent.Id);

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain.Controls.Remove(tblPanelDapAn);
            _lstTablePanelCauHoi.Remove(tblPanelDapAn);

            //decrease row index of panels down 2
            //rename panel
            for (int i = rowIndex + 2; i < tblPanelMain.RowStyles.Count; i = i + 2)
            {
                tblPanelDapAn = tblPanelMain.Controls[_nameTablePanelDapAn + i] as TableLayoutPanel;

                if (tblPanelDapAn != null)
                {
                    tblPanelMain.SetRow(tblPanelDapAn, i - 2);
                    tblPanelDapAn.Name = _nameTablePanelDapAn + (i - 2);
                }
            }

            //remove 2 last rows
            tblPanelMain.RowStyles.RemoveAt(tblPanelMain.RowStyles.Count - 2);
            tblPanelMain.RowCount--;
            tblPanelMain.RowStyles.RemoveAt(tblPanelMain.RowStyles.Count - 2);
            tblPanelMain.RowCount--;

            //Tìm vị trí điền khuyết             
            var noiDungReply = CauHoiCurent.ListCauTraLoi.FirstOrDefault();
            var textReply = (string.Format("({0})_____", CauHoiCurent.IDEx));
            txtCtrlNoiDungCauHoi.Focus();
            txtCtrlNoiDungCauHoi.Find(textReply, RichTextBoxFinds.MatchCase);
            txtCtrlNoiDungCauHoi.Cut();
            Clipboard.Clear();
            //Tra lai noi dung cho text box cau hoi
            if (noiDungReply == null) return;
            var noiDungText = UICommon.ConvertRftToText(noiDungReply.NoiDung).Trim();
            Clipboard.SetText(noiDungText);
            txtCtrlNoiDungCauHoi.Paste();
            txtCtrlNoiDungCauHoi.Refresh();
            Clipboard.Clear();
            ListCauHoi.Remove(CauHoiCurent);
            int idEx = 1;
            foreach (var viTri in ListCauHoi)
            {
                var textFind = (string.Format("({0})_____", viTri.IDEx));
                var textRepalce = (string.Format("({0})_____", idEx));
                txtCtrlNoiDungCauHoi.Find(textFind, RichTextBoxFinds.MatchCase);
                txtCtrlNoiDungCauHoi.Focus();
                txtCtrlNoiDungCauHoi.Cut();
                Clipboard.Clear();
                Clipboard.SetText(textRepalce);
                txtCtrlNoiDungCauHoi.Paste();
                txtCtrlNoiDungCauHoi.Refresh();
                viTri.IDEx = idEx++;
            }

            SetDataToCboCauHoi();
            var cauHoiKeTiep = ListCauHoi.LastOrDefault();
            //Xoa het du lieu cau hoi
            ClearAllCauTraLoi();
            ClearAllCauTraLoiGayNhieu();

            cboCauHoi.EditValueChanged -= CboCauHoi_EditValueChanged; ;
            if (cauHoiKeTiep != null)
            {
                CauHoiCurent = cauHoiKeTiep;
                IdCauHoiCurent = cauHoiKeTiep.IDEx;
                LoadCauHoiNew(IdCauHoiCurent);
                cboCauHoi.CategoryID = cauHoiKeTiep.IDEx;
            }
            else
            {
                cboCauHoi.CategoryID = null;
            }
            cboCauHoi.EditValueChanged += CboCauHoi_EditValueChanged;
            _mathCollection = _parsing.ParseDienKhuyet2(txtCtrlNoiDungCauHoi.Text);
            IsChanged = true;
        }

        private void XoaCauTraLoiGayNhieu(object sender, EventArgs e)
        {
            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời gây nhiễu này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;
            int rowIndex = tblPanelMain2.GetRow(tblPanelDapAn);

            //get id cau hoi bi xoa
            int idCauTraLoiBiXoa = Convert.ToInt32(button.Tag);
            //IDEx xác định id ex de xoa trong list cau tra loi
            int idEx = Convert.ToInt32(tblPanelDapAn.Tag);
            var cauTraLoiBiXoa = CauHoiCurent.ListCauTraLoi.FirstOrDefault(m => m.IdEx == idEx);
            CauHoiCurent.ListCauTraLoi.Remove(cauTraLoiBiXoa);

            //neu khac 0 la cau hoi da ton tai, can xoa
            if (idCauTraLoiBiXoa != 0)
            {
                ListIdCauTraLoiBiXoa.Add(idCauTraLoiBiXoa);
            }

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain2.Controls.Remove(tblPanelDapAn);
            _lstTablePanelGayNhieu.Remove(tblPanelDapAn);

            //decrease row index of panels down 2
            //rename panel
            for (int i = rowIndex + 2; i < tblPanelMain2.RowStyles.Count; i = i + 2)
            {
                tblPanelDapAn = tblPanelMain2.Controls[_nameTablePanelDapAn + i] as TableLayoutPanel;

                if (tblPanelDapAn != null)
                {
                    tblPanelMain2.SetRow(tblPanelDapAn, i - 2);
                    tblPanelDapAn.Name = _nameTablePanelDapAn + (i - 2);
                }
            }

            //remove 2 last rows
            tblPanelMain2.RowStyles.RemoveAt(tblPanelMain2.RowStyles.Count - 2);
            tblPanelMain2.RowCount--;
            tblPanelMain2.RowStyles.RemoveAt(tblPanelMain2.RowStyles.Count - 2);
            tblPanelMain2.RowCount--;
            IsChanged = true;
        }

        private void TxtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        #endregion

        #region Control

        private void CboCauHoi_EditValueChanged(object sender, EventArgs e)
        {
            //Save cau hoi team
            //Load lai cau hoi                
            //Load lai cau tra loi
            //Load lai cau tra loi gay nhieu
            if (cboCauHoi.CategoryID.HasValue)
            {
                //Buoc 5: Save cau hoi hien tai => với trường hợp vị trí điền khuyết nhiều hon 2
                if (IdCauHoiCurent > 0)
                {
                    SaveNewCauHoiTemp(IdCauHoiCurent);
                }
                //Vi khi nhan dang phai ve lai truoc khi change ID
                if (!_isDienKhuyet)
                {
                    ClearAllCauTraLoi();
                    ClearAllCauTraLoiGayNhieu();
                    //Bước 6: Load lai cau hoi moi hoặc cau hoi trong danh sách update
                    LoadCauHoiNew((int)cboCauHoi.CategoryID);
                }
                _isDienKhuyet = false;

            }
        }

        private void BtnDienKhuyet_Click(object sender, EventArgs e)
        {
            txtCtrlNoiDungCauHoi.Focus();
            //Them vao cau tra loi
            if (txtCtrlNoiDungCauHoi.SelectionLength == 0)
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn nội dung cần điền khuyết");
                return;
            }
            var textStart = txtCtrlNoiDungCauHoi.SelectionStart;

            //Kiem tra vi tri dien khuyet            
            if (_mathCollection != null)
            {
                for (int i = 0; i < _mathCollection.Count; i++)
                {
                    var viTriNext = _mathCollection[i].Index + _mathCollection[i].Length;
                    if (textStart >= _mathCollection[i].Index && textStart <= viTriNext)
                    {
                        UICommon.ShowMsgWarningString("Vị trí điền khuyết không hợp lệ!");
                        if (txtCtrlNoiDungCauHoi.SelectionLength == 0)
                            txtCtrlNoiDungCauHoi.Undo();
                        return;
                    }
                }
            }

            var tmp = txtCtrlNoiDungCauHoi.SelectedRtf;

            //Buoc 2: Add cau tra loi dau tien cho cau hoi hien tai => vi trí diền khuyết
            if (txtCtrlNoiDungCauHoi.SelectionLength != 0)
            {
                //Gan du lieu toan cuc và cboCauHoi
                CauHoiCurent = new EX_CauHoi { IDEx = ListCauHoi.Count + 1, DoKho = IdMucDoNhanThuc };
                //Buoc 1
                ListCauHoi.Add(CauHoiCurent);
                CauHoiCurent.ListCauTraLoi.Add(new EX_CauTraLoi { IdEx = 1, NoiDung = txtCtrlNoiDungCauHoi.SelectedRtf, IndexEx = textStart });

                var textStt = string.Format("({0})_____", ListCauHoi.Count);
            PasteClipboard:
                {
                    try
                    {
                        Clipboard.SetText(textStt);
                    }
                    catch (Exception)
                    {
                        goto PasteClipboard;
                    }
                }
                txtCtrlNoiDungCauHoi.Paste();
            }
            else
            {
                UICommon.ShowMsgWarningString("Nội dung chọn không hợp lệ");
                if (txtCtrlNoiDungCauHoi.SelectionLength == 0)
                    txtCtrlNoiDungCauHoi.Undo();
                return;
            }

            //Buoc 3: do du lieu len cbo
            if (ListCauHoi.Count > 0)
            {
                SetDataToCboCauHoi();
            }
            //Buoc 4 => changCategoryID
            _isDienKhuyet = true;
            cboCauHoi.CategoryID = ListCauHoi.Count;
            IdCauHoiCurent = (int)cboCauHoi.CategoryID;

            //Ve lai cau hoi => phan ben trai
            ClearAllCauTraLoi();
            ClearAllCauTraLoiGayNhieu();
            ThemCauTraLoi();

            CurrentControl.Focus();
            CurrentControl.Rtf = tmp;
            CurrentControl.ReadOnly = true;

            // Nhận dạng lại vị trí
            _mathCollection = _parsing.ParseDienKhuyet2(txtCtrlNoiDungCauHoi.Text);
        }

        private void BtnThemGayNhieu_Click(object sender, EventArgs e)
        {
            //đẩy vào cau hoi hien tai 1 cau tra loi tuong ung
            if (CauHoiCurent != null)
            {
                var cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.IdEx = CauHoiCurent.ListCauTraLoi.Count + 1;
                CauHoiCurent.ListCauTraLoi.Add(cauTraLoi);
                ThemCauTraLoiGayNhieu(cauTraLoi);
            }

        }

        #endregion

        #endregion

        #region Public methods

        public bool SaveNewCauHoi()
        {
            try
            {
                //get body
                var cauHoiCha = new EX_CauHoi();
                cauHoiCha.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                cauHoiCha.IDChuong = IdDanhMuc;
                cauHoiCha.IDLoaiCauHoi = (int)LoaiCauHoi.CauHoiDienKhuyet;
                cauHoiCha.IsCauHoiCha = true;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                _business.AddNewCauHoi(cauHoiCha);

                foreach (var ch in ListCauHoi)
                {
                    ch.IDCauHoiCha = cauHoiCha.Id;
                    ch.IDLoaiCauHoi = (int)LoaiCauHoi.CauHoiDienKhuyet;
                    ch.IDChuong = IdDanhMuc;
                    ch.DoKho = IdMucDoNhanThuc;
                    ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                    ch.IsSuDung = true;
                    ch.NgaySoan = DateTime.Now;
                    _business.AddNewCauHoi(ch);
                    foreach (var ctl in ch.ListCauTraLoi)
                    {
                        ctl.IDCauHoi = ch.Id;
                        ctl.IsKhongDao = false;
                        _business.AddNewCauTraLoi(ctl);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SaveUpdateCauHoi()
        {
            try
            {
                #region Update cau hoi cha

                var cauHoiCha = new EX_CauHoi();
                cauHoiCha.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                cauHoiCha.IDChuong = IdDanhMuc;
                cauHoiCha.IDLoaiCauHoi = (int)LoaiCauHoi.CauHoiDienKhuyet;
                cauHoiCha.IsCauHoiCha = true;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                _business.UpdateCauHoi(IdCauHoiCha ?? 0, cauHoiCha);

                #endregion

                #region Update cau hoi

                foreach (var ch in ListCauHoi)
                {
                    ch.IDCauHoiCha = IdCauHoiCha;
                    ch.IDLoaiCauHoi = (int)LoaiCauHoi.CauHoiDienKhuyet;
                    ch.DoKho = IdMucDoNhanThuc;
                    ch.IDChuong = IdDanhMuc;
                    ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                    ch.NgaySoan = DateTime.Now;
                    if (ch.Id == 0)
                    {
                        _business.AddNewCauHoi(ch);
                    }
                    else
                    {
                        _business.UpdateCauHoi(ch.Id, ch);
                    }

                    // Câu trả lời
                    foreach (var ctl in ch.ListCauTraLoi)
                    {
                        ctl.IsKhongDao = false;
                        ctl.IDCauHoi = ch.Id;
                        if (ctl.Id == 0)
                        {
                            _business.AddNewCauTraLoi(ctl);
                        }
                        else
                        {
                            _business.UpdateCauTraLoi(ctl.Id, ctl);
                        }
                    }

                }
                // Xoa cau tra loi
                foreach (int idCauTraLoiBiXoa in ListIdCauTraLoiBiXoa)
                {
                    if (idCauTraLoiBiXoa != 0)
                    {
                        _business.DeleteCauTraLoiById(idCauTraLoiBiXoa);
                    }
                }

                // Xoa cau hoi
                foreach (int idCauHoiBiXoa in ListIdCauHoiBiXoa)
                {
                    if (idCauHoiBiXoa != 0)
                    {
                        _business.DeleteCauHoiByLstId(new List<long> { idCauHoiBiXoa });
                    }
                }


                #endregion

                IsChanged = false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool ValidateNoiDung()
        {
            SaveNewCauHoiTemp(IdCauHoiCurent);
            #region Kiem tra rong

            var isEmpty = txtCtrlNoiDungCauHoi.IsEmpty;

            // Nếu nội dung rỗng và không có câu hỏi cha thì thông báo
            // Ngược lại khác rỗng hoặc rỗng nhưng có câu hỏi cha thì cho phép
            if (isEmpty)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi");
                return false;
            }

            //reset IsEmpty
            isEmpty = false;

            if (ListCauHoi == null || ListCauHoi.Count == 0)
            {
                UICommon.ShowMsgWarningString("Bạn chưa tạo vị trí điền khuyết");
                return false;
            }

            //kiem tra đáp án gay nhiễu
            foreach (var item in ListCauHoi)
            {
                //Noi dung cau hoi khong nhap cho cau hoi dang nay
                //Do kho
                if (!item.DoKho.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa chọn độ khó cho câu hỏi.");
                    return false;
                }
                //noi dung cau tra loi
                if (item.ListCauTraLoi.Count < 2)
                {
                    UICommon.ShowMsgWarningString("Tồn tại câu hỏi chưa có câu trả lời gây nhiễu");
                    return false;
                }
                foreach (var cauTl in item.ListCauTraLoi)
                {
                    if (string.IsNullOrEmpty(UiCommon.ConvertRftToText(cauTl.NoiDung)))
                    {
                        UICommon.ShowMsgWarningString("Tồn tại câu trả lời gây nhiễu bạn chưa nhập nội dung.");
                        return false;
                    }
                }
            }

            //Kiem tra hop le
            _mathCollection = _parsing.ParseDienKhuyet2(txtCtrlNoiDungCauHoi.Text);
            string noiDungCauHoi = txtCtrlNoiDungCauHoi.Text;
            List<string> lstString = new List<string>();
            if (_mathCollection != null)
            {
                if (ListCauHoi.Count != _mathCollection.Count)
                {
                    UICommon.ShowMsgWarningString("Vị trí điền khuyết không khớp với số câu hỏi");
                    return false;
                }
            }
            else
            {
                UICommon.ShowMsgWarningString("Không có vị trí điền khuyết");
                return false;
            }

            #endregion

            return true;
        }

        public void CauHoiLoad()
        {
            if (Mode == ModeForm.CapNhat)
            {
                ClearAllCauTraLoi();
                ClearAllCauTraLoiGayNhieu();
                LoadNoiDungCauHoiCha(IdCauHoiCha ?? 0);
                ThemCauTraLoi(CauHoiCurent.ListCauTraLoi.FirstOrDefault());
                for (int i = 1; i < CauHoiCurent.ListCauTraLoi.Count; i++)
                {
                    ThemCauTraLoiGayNhieu(CauHoiCurent.ListCauTraLoi[i]);
                }
                _mathCollection = _parsing.ParseDienKhuyet2(txtCtrlNoiDungCauHoi.Text);
            }
        }

        #endregion

        #region Private methods        

        #region Data

        private void InitForm()
        {
            #region Data
            // BLL
            _business = new ES_SoanCauHoiBLL();
            _business = new ES_SoanCauHoiBLL();
            _lstTablePanelCauHoi = new List<TableLayoutPanel>();
            _lstTablePanelGayNhieu = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();
            ListIdCauTraLoiBiXoa = new List<long>();
            ListCauHoi = new List<EX_CauHoi>();
            _parsing = new Parsing(null, null);

            #endregion

            #region Control

            Dock = DockStyle.Fill;
            btnDienKhuyet.Text = "Điền khuyết";
            btnThemGayNhieu.Text = "";

            #endregion

            CauHoiLoad();

            #region Event

            txtCtrlNoiDungCauHoi.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;
            btnDienKhuyet.Click += BtnDienKhuyet_Click;
            btnThemGayNhieu.Click += BtnThemGayNhieu_Click;
            cboCauHoi.EditValueChanged += CboCauHoi_EditValueChanged;
            #endregion
        }

        private void LoadNoiDungCauHoiCha(long idCauHoiCha)
        {
            //Chuyen id cau hoi va idcau tra li ve dang IDEx từ 1 đến... để xủ lý chung
            if (IdCauHoiCha > 0)
            {
                var cauHoiCha = _business.GetById(IdCauHoiCha);
                if (cauHoiCha != null)
                {
                    txtCtrlNoiDungCauHoi.Rtf = cauHoiCha.NoiDung;
                    //Đổ dữ liệu cau hoi để xử lý
                    ListCauHoi = new List<EX_CauHoi>();
                    ListCauHoi = _business.Context.EX_CauHoi.Where(mbox => mbox.IDCauHoiCha == cauHoiCha.Id).ToList();
                    var lstDataCbo = new List<DM_STT>();
                    int i = 1;
                    foreach (var item in ListCauHoi)
                    {
                        var lstCauTL = _business.GetCauTraLoi(item.Id);
                        int j = 1;
                        foreach (var ctl in lstCauTL)
                        {
                            ctl.IdEx = j;
                            j++;
                        }
                        item.ListCauTraLoi = lstCauTL;
                        item.IDEx = i;
                        lstDataCbo.Add(new DM_STT { Id = i, Ten = string.Format("Câu hỏi {0}", i) });
                        i++;
                    }
                    cboCauHoi.EditValueChanged -= CboCauHoi_EditValueChanged;

                    var lstItem = new List<LookUpEditItem>();
                    lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
                    lstItem.Add(new LookUpEditItem { ColumnName = "Ten", ColumnCaption = "Tên" });
                    cboCauHoi.SetData(lstDataCbo, lstItem, "Ten", "Id");

                    var cauHoiFirst = new EX_CauHoi();
                    if (IdCauHoiCurent > 0)
                        cauHoiFirst = ListCauHoi.FirstOrDefault(m => m.Id == IdCauHoiCurent);
                    else
                        cauHoiFirst = ListCauHoi.FirstOrDefault();

                    CauHoiCurent = cauHoiFirst;
                    IdCauHoiCurent = cauHoiFirst.IDEx;
                    cboCauHoi.CategoryID = IdCauHoiCurent;

                    txtSoCauHoi.Text = ListCauHoi.Count.ToString();
                    cboCauHoi.EditValueChanged += CboCauHoi_EditValueChanged;
                    //Day vao list match
                    _mathCollection = _parsing.ParseDienKhuyet2(txtCtrlNoiDungCauHoi.Text);
                }
            }
        }

        private void LoadCauHoiNew(long idCauHoi)
        {
            //Load cau hoi
            EX_CauHoi cauHoi = new EX_CauHoi();
            cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == idCauHoi);
            IdCauHoiCurent = cauHoi.IDEx;
            if (!txtCtrlNoiDungCauHoi.IsEmpty)
            {
                LoadCauTraLoiNew(IdCauHoiCurent);
            }
        }

        private void LoadCauTraLoiNew(long idCauHoi)
        {
            // Load danh sách đáp án
            CauHoiCurent = ListCauHoi.Where(m => m.IDEx == idCauHoi).FirstOrDefault();
            //IdCauHoiCurent = CauHoiCurent.IDEx;
            List<EX_CauTraLoi> listDapAn = new List<EX_CauTraLoi>();
            listDapAn = CauHoiCurent.ListCauTraLoi;
            //Load cau hoi (bên trái)
            var cauTraLoiDau = listDapAn.FirstOrDefault();
            ThemCauTraLoi(cauTraLoiDau);
            //Load cau tra lời gây nhieu
            for (int i = 1; i < listDapAn.Count; i++)
            {
                ThemCauTraLoiGayNhieu(listDapAn[i]);
            }
        }

        private void ClearAllCauTraLoi()
        {
            foreach (var tblPanelDapAn in _lstTablePanelCauHoi)
            {
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();
                // Remove table panel
                tblPanelMain.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelCauHoi = new List<TableLayoutPanel>();

            //remove empty rows            
            var position = tblPanelMain.GetPositionFromControl(tblPanelMain.Controls["pmtPanelRoot"]);
            int count = tblPanelMain.RowCount;
            for (int row = count - 1; row > position.Row; row--)
            {
                tblPanelMain.RowCount--;
                tblPanelMain.RowStyles.RemoveAt(row);
            }
        }

        private void ClearAllCauTraLoiGayNhieu()
        {
            foreach (var tblPanelDapAn in _lstTablePanelGayNhieu)
            {
                // Remove controls
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();

                // Remove table panel
                tblPanelMain2.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelGayNhieu = new List<TableLayoutPanel>();

            //remove empty rows            
            var position = tblPanelMain2.GetPositionFromControl(tblPanelMain2.Controls["pmtPanelRoot2"]);
            int count = tblPanelMain2.RowCount;
            for (int row = count - 1; row > position.Row; row--)
            {
                tblPanelMain2.RowCount--;
                tblPanelMain2.RowStyles.RemoveAt(row);
            }
        }

        private void SetDataToCboCauHoi()
        {
            var lstDataCbo = new List<DM_STT>();
            int i = 1;
            foreach (var item in ListCauHoi)
            {
                lstDataCbo.Add(new DM_STT { Id = item.IDEx, Ten = string.Format("Câu hỏi {0}", i++) });
            }
            var lstItem = new List<LookUpEditItem>();
            lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
            lstItem.Add(new LookUpEditItem { ColumnName = "Ten", ColumnCaption = "Tên" });
            cboCauHoi.SetData(lstDataCbo, lstItem, "Ten", "Id");
            txtSoCauHoi.Text = lstDataCbo.Count.ToString();
        }

        #endregion

        #region Control        

        private void ThemCauTraLoi(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án đúng
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLabelDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };  //Tag = 1 = true, Tag = 0 = false
            lblCauHoi.Text = (_isDienKhuyet ? ListCauHoi.Count : IdCauHoiCurent).ToString();

            // Xóa câu trả lời
            var btnXoa = new DevExpress.XtraEditors.SimpleButton();
            btnXoa.ImageOptions.Image = global::SimpleTest.Properties.Resources.tsbDelete;
            btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            btnXoa.Margin = new System.Windows.Forms.Padding(2);
            btnXoa.Name = _nameButtonXoa;
            btnXoa.Text = "";
            btnXoa.Width = 40;
            btnXoa.ToolTip = "Xóa câu trả lời";
            btnXoa.Click += new EventHandler(XoaCauTraLoi);

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, ReadOnly = true, Margin = new Padding(2) };

            // Table panel
            TableLayoutPanel tblPanelDapAn = new TableLayoutPanel();
            tblPanelDapAn.Name = _nameTablePanelDapAn + rowIndex;
            tblPanelDapAn.ColumnCount = 3;
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelDapAn.RowCount = 1;
            tblPanelDapAn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelDapAn.Dock = DockStyle.Top;

            tblPanelDapAn.Controls.Add(lblCauHoi, 0, 0);
            tblPanelDapAn.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAn.Controls.Add(btnXoa, 2, 0);

            tblPanelMain.Controls.Add(tblPanelDapAn, 0, rowIndex);
            //add panel to list
            _lstTablePanelCauHoi.Add(tblPanelDapAn);

            if (cauTraLoi != null)
            {
                // Load noi dung dap an
                txtCtrl.Rtf = cauTraLoi.NoiDung;
                // Gán id câu trả lời
                btnXoa.Tag = cauTraLoi.Id;
            }
            CurrentControl = txtCtrl;
            CurrentControl.ReadOnly = true;
        }

        private void ThemCauTraLoiGayNhieu(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain2.RowCount += 2;
            int rowIndex = tblPanelMain2.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain2.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án gây nhiễu sẽ tính từ a,b,c,d
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLabelDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };  //Tag = 1 = true, Tag = 0 = false
            lblCauHoi.Text = Convert.ToChar(65 + _lstTablePanelGayNhieu.Count).ToString();

            // Xóa câu trả lời            
            var btnXoa = new DevExpress.XtraEditors.SimpleButton();
            btnXoa.ImageOptions.Image = global::SimpleTest.Properties.Resources.tsbDelete;
            btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            btnXoa.Margin = new System.Windows.Forms.Padding(2);
            btnXoa.Name = _nameButtonXoa;
            btnXoa.Text = "";
            btnXoa.Width = 40;
            btnXoa.ToolTip = "Xóa câu trả lời gây nhiễu";
            btnXoa.Click += new EventHandler(XoaCauTraLoiGayNhieu);

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(2) };
            txtCtrl.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;

            // Table panel
            TableLayoutPanel tblPanelDapAnGayNhieu = new TableLayoutPanel();
            tblPanelDapAnGayNhieu.Name = _nameTablePanelDapAn + rowIndex;
            tblPanelDapAnGayNhieu.ColumnCount = 3;
            tblPanelDapAnGayNhieu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelDapAnGayNhieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelDapAnGayNhieu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelDapAnGayNhieu.RowCount = 1;
            tblPanelDapAnGayNhieu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelDapAnGayNhieu.Dock = DockStyle.Top;

            tblPanelDapAnGayNhieu.Controls.Add(lblCauHoi, 0, 0);
            tblPanelDapAnGayNhieu.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAnGayNhieu.Controls.Add(btnXoa, 2, 0);

            tblPanelMain2.Controls.Add(tblPanelDapAnGayNhieu, 0, rowIndex);
            //add panel to list
            _lstTablePanelGayNhieu.Add(tblPanelDapAnGayNhieu);

            if (cauTraLoi != null)
            {
                // Load noi dung dap an
                if (!string.IsNullOrEmpty(cauTraLoi.NoiDung))
                {
                    txtCtrl.Rtf = cauTraLoi.NoiDung;
                }

                // Gán id câu trả lời
                btnXoa.Tag = cauTraLoi.Id;
                tblPanelDapAnGayNhieu.Tag = cauTraLoi.IdEx;
            }
            CurrentControl = txtCtrl;
        }

        private bool SaveNewCauHoiTemp(long idCauHoiEx)
        {
            var lstCauTraLoi = new List<EX_CauTraLoi>();
            //Cau tra loi dau tien 
            if (_lstTablePanelCauHoi.Count == 0)
            {
                return false;
            }
            var tblPanelDapAn = _lstTablePanelCauHoi.FirstOrDefault();
            EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
            Label btnDapAn = tblPanelDapAn.Controls[_nameLabelDapAn] as Label;
            lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAn.Rtf, IsDung = true, IsKhongDao = true });

            foreach (var tblPanelDapAnGayNhieu in _lstTablePanelGayNhieu)
            {
                EditorControl txtDapAnGayNhieu = tblPanelDapAnGayNhieu.Controls[_nameTextNoiDungDapAn] as EditorControl;
                Label btnDapAnGayNhieu = tblPanelDapAnGayNhieu.Controls[_nameLabelDapAn] as Label;
                lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAnGayNhieu.Rtf, IsDung = false, IsKhongDao = true });
            }

            #region Save new câu hỏi
            //Cau hoi cha
            EX_CauHoi cauHoiCha = new EX_CauHoi();
            cauHoiCha.IDChuong = IdDanhMuc;
            cauHoiCha.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
            cauHoiCha.IDLoaiCauHoi = (int)LoaiCauHoi.CauHoiDienKhuyet;

            EX_CauHoi cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == IdCauHoiCurent);
            cauHoi.IDChuong = IdDanhMuc;
            cauHoi.DoKho = IdMucDoNhanThuc;
            cauHoi.IsSuDung = true;
            cauHoi.NgaySoan = DateTime.Now;

            // Danh sách câu trả lời
            int i = 1;
            cauHoi.ListCauTraLoi.OrderBy(m => m.IdEx).ToList();
            cauHoi.ListCauTraLoi.ForEach(m => { m.IdEx = i++; });
            i = 1;
            foreach (var esCauTraLoi in lstCauTraLoi)
            {
                if (cauHoi.ListCauTraLoi.Any(m => m.IdEx == i))
                {
                    var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.IdEx == i);
                    cauTraLoi.IdEx = i;
                    cauTraLoi.NoiDung = esCauTraLoi.NoiDung;
                    cauTraLoi.IsDung = esCauTraLoi.IsDung;
                    cauTraLoi.IsKhongDao = esCauTraLoi.IsKhongDao;
                }
                else
                {
                    esCauTraLoi.IDCauHoi = cauHoi.IDEx;
                    esCauTraLoi.IdEx = i;
                    cauHoi.ListCauTraLoi.Add(esCauTraLoi);
                }
                i++;
            }

            // Xoa cau tra loi
            foreach (int idCauTraLoiBiXoa in ListIdCauHoiBiXoa)
            {
                if (idCauTraLoiBiXoa != 0)
                {
                    var cauTraLoiBiXoa = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.Id == idCauTraLoiBiXoa);
                    cauHoi.ListCauTraLoi.Remove(cauTraLoiBiXoa);
                }
            }
            #endregion

            return true;
        }

        #endregion

        #endregion
    }
}
