using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.XtraEditors;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Controls
{
    public partial class UcDungSaiChum : UserControlBase
    {
        #region Variables

        private Color _colorDapAnDung = Color.Red;

        //BLL
        private ES_SoanCauHoiBLL _bus;

        private List<TableLayoutPanel> _lstTablePanelDapAn;

        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameButtonDapAn = "btnDapAn";
        private const string _nameLableDapAn = "lblDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #region Constructor

        public UcDungSaiChum()
        {
            Mode = ModeForm.ThemMoi;
            InitializeCommon();
            Dock = DockStyle.Fill;
            btnTaoCauHoi.Text = "Tạo";
            btnXoaCauHoi.Text = "Xóa";
            btnThem.Text = "Thêm";
        }

        #endregion

        #region Protected Methods

        #endregion

        #region Public Method

        public void CauHoiLoad()
        {
            ClearAllCauTraLoi();
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                LoadNoiDungCauHoiCha((int)IdCauHoiCha);
                LoadCauHoiOld();
                LoadCauTraLoi();
            }
            else if (Mode == ModeForm.ThemMoi)
            {
                // Add 4 cau tra loi mac dinh
                for (int i = 1; i <= 4; i++)
                {
                    ThemCauTraLoi();
                }
                SetReadOnlyControl(true);
            }
        }

        public bool SaveNewCauHoi()
        {
            try
            {
                var cauHoiCha = new EX_CauHoi();
                cauHoiCha.NoiDung = txtNoiDungCauHoiCha.Rtf;
                cauHoiCha.IDChuong = IdDanhMuc;
                cauHoiCha.IDLoaiCauHoi = IdLoaiCauHoi;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                cauHoiCha.IsCauHoiCha = true;
                _bus.AddNewCauHoi(cauHoiCha);

                foreach (var ch in ListCauHoi)
                {
                    ch.IDCauHoiCha = cauHoiCha.Id;
                    ch.IDLoaiCauHoi = IdLoaiCauHoi;
                    ch.IDChuong = IdDanhMuc;
                    ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                    ch.IsSuDung = true;
                    ch.DoKho = IdMucDoNhanThuc;
                    ch.NgaySoan = DateTime.Now;
                    _bus.AddNewCauHoi(ch);
                    foreach (var ctl in ch.ListCauTraLoi)
                    {
                        ctl.IDCauHoi = ch.Id;
                        _bus.AddNewCauTraLoi(ctl);
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
                cauHoiCha.NoiDung = txtNoiDungCauHoiCha.Rtf;
                cauHoiCha.IDChuong = IdDanhMuc;
                cauHoiCha.IDLoaiCauHoi = IdLoaiCauHoi;
                cauHoiCha.IsCauHoiCha = true;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                _bus.UpdateCauHoi(IdCauHoiCha ?? 0, cauHoiCha);

                #endregion

                #region Update cau hoi
                
                    foreach (var ch in ListCauHoi)
                    {
                        ch.IDCauHoiCha = IdCauHoiCha;
                        ch.IDLoaiCauHoi = IdLoaiCauHoi;
                        ch.IDChuong = IdDanhMuc;
                        ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                        ch.NgaySoan = DateTime.Now;
                        ch.DoKho = IdMucDoNhanThuc;
                        if (ch.Id > 0)
                            _bus.UpdateCauHoi(ch.Id, ch);
                        else
                            _bus.AddNewCauHoi(ch);
                        // Câu trả lời
                        foreach (var ctl in ch.ListCauTraLoi)
                        {
                            ctl.IDCauHoi = ch.Id;
                            if (ctl.Id == 0)
                            {
                                _bus.AddNewCauTraLoi(ctl);
                            }
                            else
                            {
                                _bus.UpdateCauTraLoi(ctl.Id, ctl);
                            }
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
            //kiem tra rong

            if (txtNoiDungCauHoiCha.IsEmpty)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi cha.");
                return false;
            }

            //reset IsEmpty
            if (ListCauHoi == null || ListCauHoi.Count == 0)
            {
                UICommon.ShowMsgWarningString("Bạn chưa tạo số lượng câu hỏi");
                return false;
            }

            SaveNewCauHoiTemp(IdCauHoiCurent);

            foreach (var item in ListCauHoi)
            {
                if (string.IsNullOrEmpty(UICommon.ConvertRftToText(item.NoiDung)))
                {
                    UICommon.ShowMsgWarningString("Tồn tại câu hỏi bạn chưa nhập nội dung.");
                    return false;
                }
                //Do kho
                if (!item.DoKho.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa chọn độ khó cho câu hỏi.");
                    return false;
                }
                //noi dung cau tra loi
                foreach (var cauTl in item.ListCauTraLoi)
                {
                    if (string.IsNullOrEmpty(UICommon.ConvertRftToText(cauTl.NoiDung)))
                    {
                        UICommon.ShowMsgWarningString("Tồn tại câu trả lời bạn chưa nhập nội dung.");
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Private Methods

        private void InitializeData()
        {
            //BLL
            _bus = new ES_SoanCauHoiBLL();
            _lstTablePanelDapAn = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();
            ListCauHoi = new List<EX_CauHoi>();
        }

        private void InitializeCommon()
        {
            //build UI
            InitializeComponent();
            //initialize data
            InitializeData();
            //add event
            AddEvent();
        }

        private void AddEvent()
        {
            Load += new EventHandler(CauHoi_Load);
            btnThemCauTraLoi.Click += new EventHandler(tsbThemCauTraLoi_Click);

            txtNoiDungCauHoiCha.GotFocus += txtNoiDungCauHoiCha_GotFocus;
            txtNoiDungCauHoiCon.GotFocus += txtNoiDungCauHoiCha_GotFocus;
            txtNoiDungCauHoiCha.KeyDown += new KeyEventHandler(EditorControl_KeyDown);
            txtNoiDungCauHoiCon.KeyDown += new KeyEventHandler(EditorControl_KeyDown);
            btnTaoCauHoi.Click += BtnTaoSoCauHoi_Click;
            btnXoaCauHoi.Click += BtnXoaCauHoi_Click;
            btnThem.Click += BtnThem_Click;
            cboChonCauHoi.EditValueChanged += CboChonCauHoi_EditValueChanged; ;
        }

        private void ThemCauTraLoi(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            //Câu trả lời
            Label lblDapAn = new Label() { Width = 90, Dock = DockStyle.Left, Name = _nameLableDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };  //Tag = 1 = true, Tag = 0 = false
            lblDapAn.Text = "Đáp án " + Convert.ToChar(65 + _lstTablePanelDapAn.Count).ToString();

            // Đáp án đúng
            SimpleButton btnDapAn = new SimpleButton() { Width = 40, Dock = DockStyle.Right, Name = _nameButtonDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold) };  //Tag = 1 = true, Tag = 0 = false
            btnDapAn.Text = "";
            btnDapAn.Image = ((System.Drawing.Image)(Properties.Resources.uncheck));
            btnDapAn.Click += new EventHandler(btnDapAn_Click);

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

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BorderStyle = BorderStyle.FixedSingle };
            txtCtrl.Margin = new Padding(2);
            txtCtrl.GotFocus += txtNoiDungCauHoiCha_GotFocus;

            // Table panel
            TableLayoutPanel tblPanelDapAn = new TableLayoutPanel();
            tblPanelDapAn.Name = _nameTablePanelDapAn + rowIndex;
            tblPanelDapAn.Tag = _lstTablePanelDapAn.Count + 1;
            tblPanelDapAn.ColumnCount = 5;
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tblPanelDapAn.RowCount = 1;
            tblPanelDapAn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelDapAn.Dock = DockStyle.Top;

            tblPanelDapAn.Controls.Add(lblDapAn, 0, 0);
            tblPanelDapAn.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAn.Controls.Add(btnDapAn, 2, 0);
            tblPanelDapAn.Controls.Add(btnXoa, 3, 0);
            tblPanelDapAn.Controls.Add(chkKhongDao, 4, 0);

            tblPanelMain.Controls.Add(tblPanelDapAn, 0, rowIndex);
            //add panel to list
            _lstTablePanelDapAn.Add(tblPanelDapAn);

            if (cauTraLoi != null)
            {
                tblPanelDapAn.Tag = cauTraLoi.IdEx;
                // Tô màu đáp án đúng
                if (cauTraLoi.IsDung ?? false)
                {
                    btnDapAn.Image = ((System.Drawing.Image)(Properties.Resources.check));
                    btnDapAn.Tag = 1;
                }

                // Load noi dung dap an
                txtCtrl.Rtf = cauTraLoi.NoiDung;

                // Gán id câu trả lời
                btnXoa.Tag = cauTraLoi.Id;

                // Gán check không đảo
                chkKhongDao.Checked = cauTraLoi.IsKhongDao ?? false;
            }
            ResizeLayoutCauTraLoi(true);
        }

        private void ResizeLayoutCauTraLoi(bool isAdd)
        {
            tblPanelMain.AutoScroll = false;
            var heightTb = tblPanelMain.Height;
            if (!isAdd)
                tblPanelMain.Height = heightTb - 63;

            tblPanelMain.AutoScroll = true;
        }

        private void ResetTextCauTraLoi()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelDapAn)
            {
                //Reset tag => nếu hk reset thì qua phần save câu hỏi team se bi sai
                tblPanelDapAn.Tag = viTri + 1;
                Label label = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                label.Text = "Đáp án " + Convert.ToChar(65 + viTri++).ToString();
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            //neu thu muc goc ton tai thi copy
            if (dir.Exists)
            {
                //thu muc dich neu chua co thi tao
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }

        private void LoadCauHoiDapAn()
        {
            LoadCauHoiOld();
            LoadCauTraLoi();
        }

        private void LoadNoiDungCauHoiCha(int idCauHoiCha)
        {
            //Chuyen id cau hoi va idcau tra li ve dang IDEx từ 1 đến... để xủ lý chung
            if (base.IdCauHoiCha > 0)
            {
                var cauHoiCha = _bus.GetById(base.IdCauHoiCha);
                if (cauHoiCha != null)
                {
                    txtNoiDungCauHoiCha.Rtf = cauHoiCha.NoiDung;
                    //Đổ dữ liệu cau hoi để xử lý
                    ListCauHoi = new List<EX_CauHoi>();
                    ListCauHoi = _bus.Context.EX_CauHoi.Where(mbox => mbox.IDCauHoiCha == cauHoiCha.Id).ToList();
                    var lstDataCbo = new List<DM_STT>();
                    int i = 1;
                    foreach (var item in ListCauHoi)
                    {
                        var lstCauTL = _bus.GetCauTraLoi(item.Id);
                        int j = 1;
                        foreach (var ctl in lstCauTL)
                        {
                            ctl.IdEx = j; j++;
                        }
                        item.ListCauTraLoi = lstCauTL;
                        item.IDEx = i;
                        lstDataCbo.Add(new DM_STT { Id = i, Ten = string.Format("Câu hỏi {0}", i) });
                        i++;
                    }
                    cboChonCauHoi.EditValueChanged -= CboChonCauHoi_EditValueChanged;
                    SetDataChonCauHoi(lstDataCbo);

                    var cauHoiFirst = new EX_CauHoi();
                    if (IdCauHoiCurent > 0)
                        cauHoiFirst = ListCauHoi.FirstOrDefault(m => m.Id == IdCauHoiCurent);
                    else
                        cauHoiFirst = ListCauHoi.FirstOrDefault();

                    CauHoiCurent = cauHoiFirst;
                    IdCauHoiCurent = cauHoiFirst.IDEx;
                    cboChonCauHoi.CategoryID = IdCauHoiCurent;

                    txtSoCauHoi.Text = ListCauHoi.Count.ToString();
                    txtSoCauHoi.Enabled = false;
                    btnTaoCauHoi.Enabled = false;
                    cboChonCauHoi.EditValueChanged += CboChonCauHoi_EditValueChanged;
                }
            }
        }

        private void LoadCauHoiOld()
        {
            EX_CauHoi cauHoi = _bus.GetById(CauHoiCurent.Id);

            //noi dung cau hoi
            txtNoiDungCauHoiCon.Rtf = cauHoi.NoiDung;

            //check nếu có dùng câu hỏi cha
            base.IdCauHoiCha = cauHoi.IDCauHoiCha;
            // Check đảo/không đảo
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
            //nếu id câu hỏi cha khác null thì hiển thị nội dung câu hỏi cha lên
            if (base.IdCauHoiCha != null)
            {
                EX_CauHoi cauHoiCha = _bus.GetById(base.IdCauHoiCha);
                if (cauHoiCha != null)
                {
                    txtNoiDungCauHoiCha.Rtf = cauHoiCha.NoiDung;
                }
            }
            else   // Ngược lại nếu không có câu hỏi cha, refresh câu hỏi cha
            {
                txtNoiDungCauHoiCha.Clear();
            }
        }

        private void LoadCauHoiNew(long? idCauHoi)
        {
            var cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == idCauHoi);
            if (cauHoi == null) cauHoi = new EX_CauHoi();
            IdCauHoiCurent = cauHoi.IDEx;
            txtNoiDungCauHoiCon.Rtf = cauHoi.NoiDung;
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
            LoadCauTraLoiNew(IdCauHoiCurent);
        }

        private void LoadCauTraLoi()
        {
            // Load danh sách đáp án
            List<EX_CauTraLoi> listDapAn = _bus.GetCauTraLoi(CauHoiCurent.Id);
            foreach (var dapAn in listDapAn)
            {
                ThemCauTraLoi(dapAn);
            }
        }

        private void LoadCauTraLoiNew(long idCauHoi)
        {
            // Load danh sách đáp án
            List<EX_CauTraLoi> listDapAn = new List<EX_CauTraLoi>();
            listDapAn = ListCauHoi.Where(m => m.IDEx == idCauHoi).Select(m => m.ListCauTraLoi).FirstOrDefault();

            foreach (var dapAn in listDapAn)
            {
                ThemCauTraLoi(dapAn);
            }
        }

        private bool SaveNewCauHoiTemp(long idCauHoiEx)
        {
            var lstCauTraLoi = new List<EX_CauTraLoi>();
            foreach (var tblPanelDapAn in _lstTablePanelDapAn)
            {
                EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                SimpleButton btnDapAn = tblPanelDapAn.Controls[_nameButtonDapAn] as SimpleButton;
                CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAn.Rtf, IsDung = Convert.ToBoolean(btnDapAn.Tag), IsKhongDao = chkKhongDao.Checked });
            }

            #region Save new câu hỏi
            //Cau hoi cha
            if (ListCauHoi == null)
            {
                return false;
            }
            EX_CauHoi cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == IdCauHoiCurent);
            cauHoi.IDChuong = IdDanhMuc;
            cauHoi.DoKho = IdMucDoNhanThuc;
            cauHoi.NoiDung = txtNoiDungCauHoiCon.Rtf;
            cauHoi.IsSuDung = true;
            cauHoi.IsKhongDao = ckbKhongDaoCauHoi.Checked;
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
                var cauTraLoiBiXoa = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.Id == idCauTraLoiBiXoa);
                cauHoi.ListCauTraLoi.Remove(cauTraLoiBiXoa);
                _bus.DeleteCauTraLoiById(idCauTraLoiBiXoa);
            }
            #endregion

            return true;
        }

        private void SetReadOnlyControl(bool isReadOnly)
        {
            txtNoiDungCauHoiCon.ReadOnly = isReadOnly;
            ckbKhongDaoCauHoi.Enabled = !isReadOnly;
            txtSoCauHoi.ReadOnly = !isReadOnly;
        }

        private string HtmlToText(string htmlString)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return reg.Replace(htmlString, "");
        }

        private void SetDataChonCauHoi(List<DM_STT> lstDataCbo)
        {
            var lstItem = new List<LookUpEditItem>();
            lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
            lstItem.Add(new LookUpEditItem { ColumnName = "Ten", ColumnCaption = "Tên" });
            cboChonCauHoi.SetData(lstDataCbo, lstItem, "Ten", "Id");
        }

        #endregion

        #region Events

        private void CauHoi_Load(object sender, EventArgs e)
        {
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                LoadCauHoiDapAn();
            }
            else if (Mode == ModeForm.ThemMoi)
            {
                // Add 4 cau tra loi mac dinh
                for (int i = 1; i <= 4; i++)
                {
                    ThemCauTraLoi();
                }
            }
        }

        private void ClearAllCauTraLoi()
        {
            foreach (var tblPanelDapAn in _lstTablePanelDapAn)
            {
                // Remove controls
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();

                // Remove table panel
                tblPanelMain.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelDapAn = new List<TableLayoutPanel>();

            //remove empty rows            
            var position = tblPanelMain.GetPositionFromControl(tblPanelMain.Controls["pmtPanelRoot"]);
            int count = tblPanelMain.RowCount;
            for (int row = count - 1; row > position.Row; row--)
            {
                tblPanelMain.RowCount--;
                tblPanelMain.RowStyles.RemoveAt(row);
            }
        }

        private void tsbThemCauTraLoi_Click(object sender, EventArgs e)
        {
            ThemCauTraLoi();

            if (Mode == ModeForm.CapNhat)
            {
                IsChanged = true;
            }
        }

        private void XoaCauTraLoi(object sender, EventArgs e)
        {
            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;
            int rowIndex = tblPanelMain.GetRow(tblPanelDapAn);

            //get id cau hoi bi xoa
            int idCauHoiBiXoa = Convert.ToInt32(button.Tag);

            int idCauTraLoiEx = 0;
            try { idCauTraLoiEx = Convert.ToInt32(tblPanelDapAn.Tag); } catch { }
            //Xoa cau tra loi trong lstCauHoi
            var cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == IdCauHoiCurent);
            if (cauHoi != null)
            {
                var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault(m => m.IdEx == idCauTraLoiEx);
                if (cauTraLoi != null) cauHoi.ListCauTraLoi.Remove(cauTraLoi);
                int idEx = 1;
                //Reset lai idEx = bắt đầu từ 1 => nhớ phải reset tag của tblPanelDapAn ở phần reset text
                foreach (var item in cauHoi.ListCauTraLoi)
                {
                    item.IdEx = idEx++;
                }
            }

            //neu khac 0 la cau hoi da ton tai, can xoa
            if (idCauHoiBiXoa != 0)
            {
                ListIdCauHoiBiXoa.Add(idCauHoiBiXoa);
                IsChanged = true;
            }

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain.Controls.Remove(tblPanelDapAn);
            _lstTablePanelDapAn.Remove(tblPanelDapAn);

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

            // Reset text
            ResetTextCauTraLoi();
            ResizeLayoutCauTraLoi(false);
        }

        private void btnDapAn_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            int IsDung = Convert.ToInt32(btn.Tag);

            //neu dang la sai, thi cho dung
            if (IsDung == 0)
            {
                btn.Tag = 1;
                btn.Image = ((System.Drawing.Image)(Properties.Resources.check));
            }
            else if (IsDung == 1)
            {
                btn.Tag = 0;
                btn.Image = ((System.Drawing.Image)(Properties.Resources.uncheck));
            }
            IsChanged = true;
        }

        private void txtNoiDungCauHoiCha_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        private void EditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            EditorControl EditorControl = sender as EditorControl;
            if (EditorControl.Name == "txtNoiDungCauHoiCon" || EditorControl.Name == "txtCtrlDapAn")
            {
                if (ListCauHoi == null || ListCauHoi.Count == 0 || !cboChonCauHoi.CategoryID.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa tạo số lượng câu hỏi");
                    EditorControl.Text = "";
                    return;
                }
            }
        }

        private void BtnTaoSoCauHoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCauHoi.Text))
            {
                UICommon.ShowMsgInfoString("Bạn hãy nhập số câu hỏi cần tạo");
                return;
            }
            if (txtNoiDungCauHoiCha.IsEmpty)
            {
                UICommon.ShowMsgInfoString("Bạn hãy nhập nội dung câu hỏi cha");
                txtNoiDungCauHoiCha.Focus();
                return;
            }
            var soCau = Convert.ToInt32(txtSoCauHoi.Text);
            if (soCau < 1)
            {
                UICommon.ShowMsgInfoString("Số câu hỏi cần phải lớn hơn 0");
                return;
            }

            //Khởi tạo danh sách câu hỏi
            ListCauHoi = new List<EX_CauHoi>();
            var dataCboCauHoi = new List<DM_STT>();
            for (int i = 1; i <= soCau; i++)
            {
                EX_CauHoi cauHoi = new EX_CauHoi();
                cauHoi.IDEx = i;
                cauHoi.NoiDung = "";
                cauHoi.IDChuong = IdDanhMuc;
                cauHoi.DoKho = IdMucDoNhanThuc;
                cauHoi.IsSuDung = true;
                cauHoi.IsKhongDao = ckbKhongDaoCauHoi.Checked;

                //Khởi tạo danh sách câu trả lời
                for (int j = 1; j <= 4; j++)
                {
                    EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                    cauTraLoi.IdEx = j;
                    cauTraLoi.IDCauHoi = cauHoi.Id;
                    cauTraLoi.NoiDung = "";
                    cauHoi.ListCauTraLoi.Add(cauTraLoi);
                }
                ListCauHoi.Add(cauHoi);
                dataCboCauHoi.Add(new DM_STT { Id = cauHoi.IDEx, Ten = string.Format("Câu hỏi {0}", i) });
            }

            //Set data cauHoi vào trong cbo
            //cboChonCauHoi.CategoryID = 1;
            SetDataChonCauHoi(dataCboCauHoi);
            if (dataCboCauHoi.Count > 0)
            {
                IdCauHoiCurent = 0;
                cboChonCauHoi.CategoryID = 1;
            }
            SetReadOnlyControl(false);
            btnTaoCauHoi.Enabled = false;
        }

        private void BtnXoaCauHoi_Click(object sender, EventArgs e)
        {
            if (ListCauHoi == null || ListCauHoi.Count == 0)
            {
                UICommon.ShowMsgWarningString("Bạn phải tạo câu hỏi trước");
                return;
            }
            else if (ListCauHoi.Count == 1)
            {
                UICommon.ShowMsgWarningString("Số lượng câu hỏi quá ít bạn không thể xóa");
                return;
            }

            if (UICommon.ShowMsgQuestionString("Bạn muốn xóa câu hỏi này?") == DialogResult.Yes)
            {
                var cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == IdCauHoiCurent);
                if (cauHoi != null)
                {
                    //Xóa toàn cục
                    ListCauHoi.Remove(cauHoi);
                    //Xoa duoi db
                    IsChanged = (_bus.DeleteCauHoiByLstId(new List<long> { cauHoi.Id }) > 0);
                    //Set lai data
                    var cauHoiKeTiep = ListCauHoi.FirstOrDefault();
                    IdCauHoiCurent = 0;
                    if (cauHoiKeTiep != null)
                    {
                        CauHoiCurent = cauHoiKeTiep;
                    }
                    var lstDataCbo = new List<DM_STT>();
                    //int i = 1;
                    foreach (var item in ListCauHoi)
                    {
                        lstDataCbo.Add(new DM_STT { Id = item.IDEx, Ten = "Câu hỏi " + item.IDEx });
                    }
                    txtSoCauHoi.Text = lstDataCbo.Count().ToString();
                    SetDataChonCauHoi(lstDataCbo);
                    if (cauHoiKeTiep != null)
                        cboChonCauHoi.CategoryID = cauHoiKeTiep.IDEx;
                    else
                    {
                        cboChonCauHoi.CategoryID = null;
                        txtSoCauHoi.Enabled = true;
                        btnTaoCauHoi.Enabled = true;
                    }

                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (ListCauHoi == null || ListCauHoi.Count == 0)
            {
                UICommon.ShowMsgWarningString("Bạn phải tạo câu hỏi trước");
                return;
            }

            var cauHoi = new EX_CauHoi();
            for (int i = 1; i <= 4; i++)
            {
                EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.IdEx = i;
                cauTraLoi.IDCauHoi = cauHoi.Id;
                cauTraLoi.NoiDung = "";
                cauHoi.ListCauTraLoi.Add(cauTraLoi);
            }

            var cauHoiLast = ListCauHoi.LastOrDefault();
            if (cauHoiLast != null)
            {
                cauHoi.IDEx = cauHoiLast.IDEx + 1;
                cauHoi.NoiDung = "";
                cauHoi.IDChuong = IdDanhMuc;
                cauHoi.DoKho = IdMucDoNhanThuc;
                cauHoi.IsSuDung = true;
                cauHoi.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ListCauHoi.Add(cauHoi);

                //Set lai data

                var lstDataCbo = new List<DM_STT>();
                //int i = 1;
                foreach (var item in ListCauHoi)
                {
                    lstDataCbo.Add(new DM_STT { Id = item.IDEx, Ten = "Câu hỏi " + item.IDEx });
                }
                txtSoCauHoi.Text = lstDataCbo.Count().ToString();
                SetDataChonCauHoi(lstDataCbo);
                cboChonCauHoi.CategoryID = cauHoi.IDEx;
            }
        }

        private void CboChonCauHoi_EditValueChanged(object sender, EventArgs e)
        {
            if (cboChonCauHoi.CategoryID.HasValue)
            {
                if (IdCauHoiCurent > 0)
                {
                    SaveNewCauHoiTemp(IdCauHoiCurent);
                }
                ClearAllCauTraLoi();
                LoadCauHoiNew(cboChonCauHoi.CategoryID);
            }
            SetReadOnlyControl(false);
        }

        #endregion

        #region Properties

        public List<EX_CauHoi> LstCauHoiChon
        {
            get { return ListCauHoi; }
            set { ListCauHoi = value; }
        }

        #endregion
    }
}
