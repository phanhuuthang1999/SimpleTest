using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.XtraEditors;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Controls
{
    public partial class UcHoanThanhCau : UserControlBase
    {
        #region Variable declarations      

        #region Data

        private ES_SoanCauHoiBLL _cauHoiBll = new ES_SoanCauHoiBLL();

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelCauHoi;
        private List<TableLayoutPanel> _lstTablePanelCauTraLoi;
        private const string _nameTablePanelCauHoi = "tblPanelCauHoi";
        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameLableCauHoi = "lblCauHoi";
        private const string _nameLableDapAn = "lblDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungCauHoi = "txtCtrlCauHoi";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #endregion

        #region Constructors

        public UcHoanThanhCau()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Events

        #region CauTraLoi        

        private void XoaCauHoiHoiVaCauTraLoi(object sender, EventArgs e)
        {
            //Nếu trái it nhất phải = 1
            if (_lstTablePanelCauHoi.Count == 1)
            {
                UICommon.ShowMsgWarningString("Số câu hỏi con không được nhỏ hơn 1 \nBạn không thể xóa!");
                return;
            }

            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu hỏi này không ?") != DialogResult.Yes)
            {
                return;
            }

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelCauHoi = button.Parent as TableLayoutPanel;
            EditorControl txtCauHoi = tblPanelCauHoi.Controls[_nameTextNoiDungCauHoi] as EditorControl;
            int rowIndex = tblPanelMain.GetRow(tblPanelCauHoi);

            //get id cau hoi bi xoa
            int idEx = Convert.ToInt32(button.Tag);

            //neu khac 0 la cau hoi da ton tai, can xoa
            var cauHoi = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.IDEx == idEx);
            if (cauHoi != null && cauHoi.Id > 0)
            {
                ListIdCauHoiBiXoa.Add((int)cauHoi.Id);
                ListIdCauTraLoiBiXoa.Add((int)cauHoi.ListCauTraLoi.FirstOrDefault()?.Id);
            }

            //remove old controls
            foreach (Control ctrl in tblPanelCauHoi.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelCauHoi.Controls.Clear();
            tblPanelCauHoi.Dispose();

            tblPanelMain.Controls.Remove(tblPanelCauHoi);
            _lstTablePanelCauHoi.Remove(tblPanelCauHoi);

            //decrease row index of panels down 2
            //rename panel
            for (int i = rowIndex + 2; i < tblPanelMain.RowStyles.Count; i = i + 2)
            {
                tblPanelCauHoi = tblPanelMain.Controls[_nameTablePanelCauHoi + i] as TableLayoutPanel;

                if (tblPanelCauHoi != null)
                {
                    tblPanelMain.SetRow(tblPanelCauHoi, i - 2);
                    tblPanelCauHoi.Name = _nameTablePanelCauHoi + (i - 2);
                }
            }

            //remove 2 last rows
            tblPanelMain.RowStyles.RemoveAt(tblPanelMain.RowStyles.Count - 2);
            tblPanelMain.RowCount--;
            tblPanelMain.RowStyles.RemoveAt(tblPanelMain.RowStyles.Count - 2);
            tblPanelMain.RowCount--;

            // Reset text
            ResetTextCauHoiTrai();
            ResizeLayoutCauTraLoiTrai(false);
            SetTextSoLuongCauHoi();

            XoaCauTraLoiPhai(idEx);
        }

        private void txtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        #endregion

        #region Control

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            var maxIdEx = CauHoiCurent.ListCauHoi.Max(m => m.IDEx);
            var cauHoi = new EX_CauHoi { IDEx = maxIdEx + 1, NoiDung = "" };
            var cauTraLoi = new EX_CauTraLoi { IdEx = maxIdEx + 1, NoiDung = "" };
            cauHoi.ListCauTraLoi.Add(cauTraLoi);
            CauHoiCurent.ListCauHoi.Add(cauHoi);

            ThemCauHoiTrai(cauHoi);
            ThemCauTraLoiPhai(cauTraLoi);
        }

        #endregion

        #endregion

        #region Public methods        

        public int SaveCauHoiNew()
        {
            EX_CauHoi chc = new EX_CauHoi();
            try
            {
                List<EX_CauHoi> lstCauHoiCon = new List<EX_CauHoi>();
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                foreach (var tblPanelCauHoi in _lstTablePanelCauHoi)
                {
                    EditorControl txtCauHoi = tblPanelCauHoi.Controls[_nameTextNoiDungCauHoi] as EditorControl;
                    CheckBox chkKhongDaoCH = tblPanelCauHoi.Controls[_nameCheckBox] as CheckBox;
                    SimpleButton button = tblPanelCauHoi.Controls[_nameButtonXoa] as SimpleButton;
                    lstCauHoiCon.Add(new EX_CauHoi() { NoiDung = txtCauHoi.Rtf, IsKhongDao = chkKhongDaoCH.Checked, IDEx = (int)button.Tag });

                    foreach (var tblPanelDapAn in _lstTablePanelCauTraLoi)
                    {
                        EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                        CheckBox chkKhongDaoCTL = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                        if (Convert.ToInt32(button.Tag) == Convert.ToInt32(txtDapAn.Tag))
                        {
                            lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAn.Rtf, IsDung = true, IsKhongDao = chkKhongDaoCTL.Checked, IdEx = (int)txtDapAn.Tag });
                            break;
                        }
                    }
                }

                #region Save new câu hỏi

                chc.IDChuong = IdDanhMuc;
                chc.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                chc.IDLoaiCauHoi = IdLoaiCauHoi;
                chc.IsCauHoiCha = true;
                chc.NgayTao = DateTime.Now;
                chc.DoKho = IdMucDoNhanThuc;
                // Danh sách câu hỏi
                foreach (var exCauHoi in lstCauHoiCon)
                {
                    exCauHoi.IDCauHoiCha = chc.Id;
                    exCauHoi.IDChuong = chc.IDChuong;
                    exCauHoi.DoKho = IdMucDoNhanThuc;
                    exCauHoi.IDLoaiCauHoi = IdLoaiCauHoi;
                    exCauHoi.DoKho = IdMucDoNhanThuc;
                    exCauHoi.IsSuDung = true;
                    exCauHoi.NgaySoan =  DateTime.Now;

                    // Add câu trả lời tương ứng với câu hỏi
                    foreach (var exCauTraLoi in lstCauTraLoi)
                    {
                        if (exCauTraLoi.IdEx == exCauHoi.IDEx)
                        {
                            exCauTraLoi.IDCauHoi = (int)exCauHoi.Id;
                            exCauHoi.ListCauTraLoi.Add(exCauTraLoi);
                            break;
                        }
                    }
                    chc.ListCauHoi.Add(exCauHoi);
                }

                #endregion
            }
            catch (Exception)
            {
                return 0;
            }

            return _cauHoiBll.UpdateCauHoi(chc.Id, chc);
        }

        public int SaveUpdateCauHoi()
        {
            try
            {
                #region Update câu hỏi cha

                //cap nhat noi dung cau hoi               
                if (CauHoiCurent == null) return 0;
                CauHoiCurent.IDChuong = IdDanhMuc;
                CauHoiCurent.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                CauHoiCurent.IDLoaiCauHoi = IdLoaiCauHoi;
                CauHoiCurent.IsCauHoiCha = true;
                CauHoiCurent.DoKho = IdMucDoNhanThuc;

                #endregion

                #region Update câu hỏi con và đáp án

                List<EX_CauHoi> lstCauHoi = new List<EX_CauHoi>();
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();

                foreach (var tblPanelCauHoi in _lstTablePanelCauHoi)
                {
                    SimpleButton btnXoa = tblPanelCauHoi.Controls[_nameButtonXoa] as SimpleButton;
                    EditorControl txtCauHoi = tblPanelCauHoi.Controls[_nameTextNoiDungCauHoi] as EditorControl;
                    CheckBox chkKhongDaoCH = tblPanelCauHoi.Controls[_nameCheckBox] as CheckBox;

                    EX_CauHoi cauHoi = new EX_CauHoi();
                    cauHoi.IDCauHoiCha = CauHoiCurent.Id;
                    cauHoi.IDEx = Convert.ToInt32(btnXoa.Tag);
                    cauHoi.NoiDung = txtCauHoi.Rtf;
                    cauHoi.IsKhongDao = chkKhongDaoCH.Checked;
                    cauHoi.DoKho = IdMucDoNhanThuc;
                    cauHoi.IDLoaiCauHoi = IdLoaiCauHoi;
                    cauHoi.IDChuong = IdDanhMuc;
                    lstCauHoi.Add(cauHoi);

                    foreach (var tblPanelDapAn in _lstTablePanelCauTraLoi)
                    {
                        EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                        CheckBox chkKhongDaoCTL = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;

                        if (Convert.ToInt32(txtDapAn.Tag) == Convert.ToInt32(btnXoa.Tag))
                        {
                            EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                            cauTraLoi.IDCauHoi = cauHoi.IDEx;
                            cauTraLoi.IdEx = cauHoi.IDEx;
                            cauTraLoi.NoiDung = txtDapAn.Rtf;
                            cauTraLoi.IsDung = true;
                            cauTraLoi.IsKhongDao = chkKhongDaoCTL.Checked;
                            lstCauTraLoi.Add(cauTraLoi);
                        }
                    }
                }

                // Cập nhật câu trả lời
                foreach (var exCauHoi in lstCauHoi)
                {
                    var cauHoi = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.Id == exCauHoi.IDEx);
                    if (cauHoi == null)
                    {
                        cauHoi = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.IDEx == exCauHoi.IDEx);
                    }
                    if (cauHoi != null)
                    {
                        cauHoi.DoKho = exCauHoi.DoKho;
                        cauHoi.NoiDung = exCauHoi.NoiDung;
                        cauHoi.IDChuong = exCauHoi.IDChuong;
                        cauHoi.IsKhongDao = exCauHoi.IsKhongDao;
                        cauHoi.IDCauHoiCha = exCauHoi.IDCauHoiCha;
                        cauHoi.IDLoaiCauHoi = exCauHoi.IDLoaiCauHoi;

                        foreach (var exCauTraLoi in lstCauTraLoi)
                        {
                            if (exCauTraLoi.IdEx == exCauHoi.IDEx)
                            {
                                var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.IDCauHoi == exCauTraLoi.IdEx);
                                if (cauTraLoi == null)
                                {
                                    cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.IdEx == exCauTraLoi.IdEx);
                                }

                                if (cauTraLoi != null)
                                {
                                    cauTraLoi.NoiDung = exCauTraLoi.NoiDung;
                                    cauTraLoi.IsDung = exCauTraLoi.IsDung;
                                    cauTraLoi.IsKhongDao = exCauTraLoi.IsKhongDao;
                                }
                            }
                        }
                    }
                }

                // Xoa cau hoi
                foreach (int idCauHoiBiXoa in ListIdCauHoiBiXoa)
                {
                    var cauHoiDel = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.Id == idCauHoiBiXoa);
                    if (cauHoiDel != null)
                    {
                        cauHoiDel.IsDeleted = true;
                        var cauTraLoiDel = cauHoiDel.ListCauTraLoi.FirstOrDefault();
                        if (cauTraLoiDel != null)
                        {
                            cauTraLoiDel.IsDeleted = true;
                        }
                    }
                }

                #endregion

                IsChanged = false;
            }
            catch (Exception)
            {
                return 0;
            }

            return _cauHoiBll.UpdateCauHoi(CauHoiCurent.Id, CauHoiCurent);
        }

        public bool ValidateNoiDung()
        {
            #region Kiem tra rong

            bool hasCauHoiCha = false;
            // Nếu nội dung rỗng và không có câu hỏi cha thì thông báo
            // Ngược lại khác rỗng hoặc rỗng nhưng có câu hỏi cha thì cho phép
            if (txtCtrlNoiDungCauHoi.IsEmpty && !hasCauHoiCha)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi.");
                return false;
            }

            foreach (var tblPanelCauHoi in _lstTablePanelCauHoi)
            {
                Label lableCauHoi = tblPanelCauHoi.Controls[_nameLableCauHoi] as Label;
                EditorControl txtCauHoi = tblPanelCauHoi.Controls[_nameTextNoiDungCauHoi] as EditorControl;

                if (txtCauHoi.IsEmpty)
                {
                    UICommon.ShowMsgWarningString("Bạn hãy nhập câu hỏi " + lableCauHoi.Text);
                    return false;
                }
            }

            foreach (var tblPanelDapAn in _lstTablePanelCauTraLoi)
            {
                Label lableDapAn = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;

                if (txtDapAn.IsEmpty)
                {
                    UICommon.ShowMsgWarningString("Bạn hãy nhập đáp án " + lableDapAn.Text);
                    return false;
                }
            }

            #endregion

            return true;
        }

        public void CauHoiLoad()
        {
            ClearAllCauTraLoi();
            ClearAllCauTraLoiPhai();
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                LoadCauHoiOld(CauHoiCurent);
                LoadCauHoiVaCauTraLoi(CauHoiCurent);
            }
            else if (Mode == ModeForm.ThemMoi)
            {
                CauHoiCurent = new EX_CauHoi();
                IdCauHoiCurent = 1;
                // Add 4 cau hỏi và câu trả lời mặc định
                for (int i = 1; i <= 4; i++)
                {
                    var cauHoi = new EX_CauHoi { IDEx = i,NoiDung = "" };
                    var cauTraLoi = new EX_CauTraLoi { IdEx = i, NoiDung = "" };
                    cauHoi.ListCauTraLoi.Add(cauTraLoi);
                    CauHoiCurent.ListCauHoi.Add(cauHoi);
                    ThemCauHoiTrai(cauHoi);
                    ThemCauTraLoiPhai(cauTraLoi);
                }
            }
        }

        #endregion

        #region Private methods        

        #region Data

        private void InitForm()
        {
            #region Data

            _lstTablePanelCauHoi = new List<TableLayoutPanel>();
            _lstTablePanelCauTraLoi = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();
            ListIdCauTraLoiBiXoa = new List<long>();

            #endregion

            #region Control

            Dock = DockStyle.Fill;

            #endregion

            #region Event
            btnThemCauHoi.Click += btnThemCauHoi_Click;
            txtCtrlNoiDungCauHoi.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;
            #endregion
        }

        private void LoadCauHoiOld(EX_CauHoi cauHoi)
        {
            //noi dung cau hoi
            txtCtrlNoiDungCauHoi.Rtf = cauHoi.NoiDung;
        }

        private void LoadCauHoiVaCauTraLoi(EX_CauHoi cauHoiCha)
        {
            // Load danh sách đáp án
            var lstCauHoi = cauHoiCha.ListCauHoi;

            foreach (EX_CauHoi cauHoi in lstCauHoi)
            {
                // Gắn IdEx = Id để khi có thêm mới thì sẽ ko bị trùng IdEx với những câu hỏi cũ
                cauHoi.IDEx = (int)cauHoi.Id;
                var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault();
                if (cauTraLoi != null)
                {
                    cauTraLoi.IdEx = (int)cauHoi.IDEx;
                    ThemCauTraLoiPhai(cauTraLoi);
                }
                ThemCauHoiTrai(cauHoi);
            }
        }

        private void ClearAllCauTraLoi()
        {
            foreach (var tblPanelDapAn in _lstTablePanelCauHoi)
            {
                // Remove controls
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

        private void ClearAllCauTraLoiPhai()
        {
            foreach (var tblPanelDapAn in _lstTablePanelCauTraLoi)
            {
                // Remove controls
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();

                // Remove table panel
                tblPanelMain2.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelCauTraLoi = new List<TableLayoutPanel>();

            //remove empty rows            
            var position = tblPanelMain2.GetPositionFromControl(tblPanelMain2.Controls["pmtPanelRoot2"]);
            int count = tblPanelMain2.RowCount;
            for (int row = count - 1; row > position.Row; row--)
            {
                tblPanelMain2.RowCount--;
                tblPanelMain2.RowStyles.RemoveAt(row);
            }
        }

        private void SetTextSoLuongCauHoi()
        {
            txtSoLuongTrai.Text = _lstTablePanelCauHoi.Count.ToString();
        }

        #endregion

        #region Control

        private void ThemCauHoiTrai(EX_CauHoi cauHoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án đúng
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLableCauHoi, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };  //Tag = 1 = true, Tag = 0 = false
            lblCauHoi.Text = (1 + _lstTablePanelCauHoi.Count).ToString();

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
            btnXoa.Click += new EventHandler(XoaCauHoiHoiVaCauTraLoi);

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungCauHoi, BorderStyle = BorderStyle.FixedSingle };
            txtCtrl.Margin = new Padding(2);
            txtCtrl.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;

            // Table panel
            TableLayoutPanel tblPanelCauHoi = new TableLayoutPanel();
            tblPanelCauHoi.Name = _nameTablePanelCauHoi + rowIndex;
            tblPanelCauHoi.ColumnCount = 4;
            tblPanelCauHoi.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelCauHoi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelCauHoi.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelCauHoi.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tblPanelCauHoi.RowCount = 1;
            tblPanelCauHoi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelCauHoi.Dock = DockStyle.Top;

            tblPanelCauHoi.Controls.Add(lblCauHoi, 0, 0);
            tblPanelCauHoi.Controls.Add(txtCtrl, 1, 0);
            tblPanelCauHoi.Controls.Add(btnXoa, 2, 0);
            tblPanelCauHoi.Controls.Add(chkKhongDao, 3, 0);

            tblPanelMain.Controls.Add(tblPanelCauHoi, 0, rowIndex);
            //add panel to list
            _lstTablePanelCauHoi.Add(tblPanelCauHoi);

            if (cauHoi != null)
            {
                // Load noi dung cau hoi
                txtCtrl.Rtf = cauHoi.NoiDung;
                // Gán id câu trả lời
                if (cauHoi.Id > 0)
                {
                    btnXoa.Tag = cauHoi.Id;
                }
                else
                {
                    btnXoa.Tag = cauHoi.IDEx;
                }
                // Gán check không đảo
                chkKhongDao.Checked = cauHoi.IsKhongDao ?? false;
            }
            ResizeLayoutCauTraLoiTrai(true);
            SetTextSoLuongCauHoi();
        }

        private void ThemCauTraLoiPhai(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain2.RowCount += 2;
            int rowIndex = tblPanelMain2.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain2.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án gây nhiễu sẽ tính từ a,b,c,d
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLableDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };  //Tag = 1 = true, Tag = 0 = false
            lblCauHoi.Text = (1 + _lstTablePanelCauTraLoi.Count).ToString();

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BorderStyle = BorderStyle.FixedSingle };
            txtCtrl.Margin = new Padding(2);
            txtCtrl.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;

            // Table panel
            TableLayoutPanel tblPanelDapAnPhai = new TableLayoutPanel();
            tblPanelDapAnPhai.Name = _nameTablePanelDapAn + rowIndex;
            tblPanelDapAnPhai.ColumnCount = 4;
            tblPanelDapAnPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelDapAnPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelDapAnPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelDapAnPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tblPanelDapAnPhai.RowCount = 1;
            tblPanelDapAnPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelDapAnPhai.Dock = DockStyle.Top;

            tblPanelDapAnPhai.Controls.Add(lblCauHoi, 0, 0);
            tblPanelDapAnPhai.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAnPhai.Controls.Add(chkKhongDao, 3, 0);

            tblPanelMain2.Controls.Add(tblPanelDapAnPhai, 0, rowIndex);
            //add panel to list
            _lstTablePanelCauTraLoi.Add(tblPanelDapAnPhai);

            if (cauTraLoi != null)
            {
                // Load noi dung dap an
                if (!string.IsNullOrEmpty(cauTraLoi.NoiDung))
                {
                    txtCtrl.Rtf = cauTraLoi.NoiDung;
                }

                // Gán check không đảo
                chkKhongDao.Checked = cauTraLoi.IsKhongDao ?? false;
                if (cauTraLoi.IdEx > 0)
                {
                    tblPanelDapAnPhai.Tag = cauTraLoi.IdEx;
                    txtCtrl.Tag = cauTraLoi.IdEx;
                }
            }
            ResizeLayoutCauTraLoiPhai(true);
            SetTextSoLuongCauHoi();
        }

        private void XoaCauTraLoiPhai(int IndexEx)
        {
            TableLayoutPanel tblPanelDapAn = _lstTablePanelCauTraLoi.FirstOrDefault(m => (int)m.Tag == IndexEx);
            int rowIndex = tblPanelMain2.GetRow(tblPanelDapAn);

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain2.Controls.Remove(tblPanelDapAn);
            _lstTablePanelCauTraLoi.Remove(tblPanelDapAn);

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

            //xoa lai cau tra loi dien khuyet
            ResetTextCauTraLoiPhai();
            ResizeLayoutCauTraLoiPhai(false);
            SetTextSoLuongCauHoi();
        }

        private void ResetTextCauHoiTrai()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelCauHoi)
            {
                Label label = tblPanelDapAn.Controls[_nameLableCauHoi] as Label;
                label.Text = (1 + viTri++).ToString();
            }
        }

        private void ResetTextCauTraLoiPhai()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelCauTraLoi)
            {
                Label label = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                label.Text = (1 + viTri++).ToString();
            }
        }

        private void ResizeLayoutCauTraLoiTrai(bool isAdd)
        {
            tblPanelMain.AutoScroll = false;
            var heightTb = tblPanelMain.Height;
            if (!isAdd)
                tblPanelMain.Height = heightTb - 63;

            tblPanelMain.AutoScroll = true;
        }

        private void ResizeLayoutCauTraLoiPhai(bool isAdd)
        {
            tblPanelMain2.AutoScroll = false;
            var heightTb = tblPanelMain2.Height;
            if (!isAdd)
                tblPanelMain2.Height = heightTb - 63;

            tblPanelMain2.AutoScroll = true;
        }

        #endregion

        #endregion        
    }
}
