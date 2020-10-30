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
    public partial class UcNoiCheoDon : UserControlBase
    {
        #region Variable declarations      

        #region Data

        private ES_SoanCauHoiBLL _business;

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelDapAnTrai;
        private List<TableLayoutPanel> _lstTablePanelDapAnPhai;
        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameLableDapAn = "btnDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #endregion

        #region Constructors

        public UcNoiCheoDon()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Events

        #region CauTraLoi        

        private void XoaCauTraLoiTrai(object sender, EventArgs e)
        {
            //Nếu trái it nhất phải = 1
            if (_lstTablePanelDapAnTrai.Count == 1)
            {
                UICommon.ShowMsgWarningString("Mệnh đề ở vế trái không được nhỏ hơn một \nBạn không thể xóa!");
                return;
            }

            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;
            int rowIndex = tblPanelMain.GetRow(tblPanelDapAn);

            //get id cau hoi bi xoa
            int idCauHoiBiXoa = Convert.ToInt32(button.Tag);

            //neu khac 0 la cau hoi da ton tai, can xoa
            if (idCauHoiBiXoa != 0)
            {
                ListIdCauHoiBiXoa.Add(idCauHoiBiXoa);
            }

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain.Controls.Remove(tblPanelDapAn);
            _lstTablePanelDapAnTrai.Remove(tblPanelDapAn);

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

            // Reset text
            ResetTextCauTraLoiTrai();
            ResizeLayoutCauTraLoiTrai(false);
            SetTextSoLuongCauHoi();
        }

        private void XoaCauTraLoiPhai(object sender, EventArgs e)
        {
            ////Nếu bên phải = bên trái thì ko cho xóa
            //if (_lstTablePanelDapAnPhai.Count <= _lstTablePanelDapAnTrai.Count)
            //{
            //    UICommon.ShowMsgWarningString("Mệnh đề ở vế phải không được ít hơn vế trái \nBạn không thể xóa!");
            //    return;
            //}

            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời gây nhiễu này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            SimpleButton button = sender as SimpleButton;
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
                ListIdCauHoiBiXoa.Add(idCauTraLoiBiXoa);
            }

            //remove old controls
            foreach (Control ctrl in tblPanelDapAn.Controls)
            {
                ctrl.Dispose();
            }
            tblPanelDapAn.Controls.Clear();
            tblPanelDapAn.Dispose();

            tblPanelMain2.Controls.Remove(tblPanelDapAn);
            _lstTablePanelDapAnPhai.Remove(tblPanelDapAn);

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

        private void txtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        #endregion

        #region Control

        private void BtnThemBenPhai_Click(object sender, EventArgs e)
        {
            ThemCauTraLoiPhai();
        }

        private void BtnThemBenTrai_Click(object sender, EventArgs e)
        {            
            ThemCauTraLoiTrai();
        }

        #endregion

        #endregion

        #region Public methods        

        public bool SaveCauHoiNew()
        {
            try
            {
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                foreach (var tblPanelDapAn in _lstTablePanelDapAnTrai)
                {
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                    lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAn.Rtf, IsDung = false, IsKhongDao = chkKhongDao.Checked, IsVeTrai = true });
                }

                foreach (var tblPanelDapAn in _lstTablePanelDapAnPhai)
                {
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                    lstCauTraLoi.Add(new EX_CauTraLoi() { NoiDung = txtDapAn.Rtf, IsDung = true, IsKhongDao = chkKhongDao.Checked, IsVeTrai = false });
                }

                #region Kiểm tra trùng câu hỏi

                #endregion

                #region Save new câu hỏi
                EX_CauHoi ch = new EX_CauHoi();
                ch.IDChuong = IdDanhMuc;
                ch.DoKho = IdMucDoNhanThuc;
                ch.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                ch.IsSuDung = true;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.TieuDeVeTrai = txtTieuDeVeTrai.Text.Trim();
                ch.TieuDeVePhai = txtTieuDeVePhai.Text.Trim();
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                ch.NgaySoan = DateTime.Now;
                _business.AddNewCauHoi(ch);

                // Danh sách câu trả lời
                foreach (var esCauTraLoi in lstCauTraLoi)
                {
                    esCauTraLoi.IDCauHoi = ch.Id;
                    _business.AddNewCauTraLoi(esCauTraLoi);
                }

                #endregion

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
                #region Update cau hoi

                //cap nhat noi dung cau hoi
                EX_CauHoi ch = _business.GetById(IdCauHoiCurent);
                if (ch == null) return false;
                ch.DoKho = IdMucDoNhanThuc;
                ch.IDChuong = IdDanhMuc;
                ch.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.TieuDeVeTrai = txtTieuDeVeTrai.Text.Trim();
                ch.TieuDeVePhai = txtTieuDeVePhai.Text.Trim();
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                //save lai
                _business.UpdateCauHoi(IdCauHoiCurent, ch);

                #endregion

                #region update dap an

                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                foreach (var tblPanelDapAn in _lstTablePanelDapAnTrai)
                {
                    SimpleButton btnXoa = tblPanelDapAn.Controls[_nameButtonXoa] as SimpleButton;
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;

                    EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                    cauTraLoi.IDCauHoi = ch.Id;
                    cauTraLoi.IdEx = Convert.ToInt32(btnXoa.Tag);
                    cauTraLoi.NoiDung = txtDapAn.Rtf;
                    cauTraLoi.IsDung = false;
                    cauTraLoi.IsKhongDao = chkKhongDao.Checked;
                    cauTraLoi.IsVeTrai = true;
                    lstCauTraLoi.Add(cauTraLoi);
                }

                foreach (var tblPanelDapAn in _lstTablePanelDapAnPhai)
                {
                    SimpleButton btnXoa = tblPanelDapAn.Controls[_nameButtonXoa] as SimpleButton;
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;

                    EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                    cauTraLoi.IDCauHoi = ch.Id;
                    cauTraLoi.IdEx = Convert.ToInt32(btnXoa.Tag);
                    cauTraLoi.NoiDung = txtDapAn.Rtf;
                    cauTraLoi.IsDung = false;
                    cauTraLoi.IsKhongDao = chkKhongDao.Checked;
                    cauTraLoi.IsVeTrai = false;
                    lstCauTraLoi.Add(cauTraLoi);
                }

                // Cập nhật câu trả lời
                foreach (var esCauTraLoi in lstCauTraLoi)
                {
                    if (esCauTraLoi.IdEx == 0) _business.AddNewCauTraLoi(esCauTraLoi);
                    else _business.UpdateCauTraLoi(esCauTraLoi.IdEx, esCauTraLoi);
                }

                // Xoa cau tra loi
                foreach (int IdCauTraLoiBiXoa in ListIdCauHoiBiXoa)
                {
                    _business.DeleteCauTraLoiById(IdCauTraLoiBiXoa);
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
            #region Kiem tra rong
            
            bool hasCauHoiCha = false;
            // Nếu nội dung rỗng và không có câu hỏi cha thì thông báo
            // Ngược lại khác rỗng hoặc rỗng nhưng có câu hỏi cha thì cho phép
            if (txtCtrlNoiDungCauHoi.IsEmpty && !hasCauHoiCha)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi.");
                return false;
            }
            
            if (_lstTablePanelDapAnTrai.Count != _lstTablePanelDapAnPhai.Count)
            {
                UICommon.ShowMsgWarningString("Mệnh đề ở vế trái và vế phải phải bằng nhau");
                return false;
            }

            foreach (var tblPanelDapAn in _lstTablePanelDapAnTrai)
            {
                Label lableDapAn = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;

                if (txtDapAn.IsEmpty)
                {
                    UICommon.ShowMsgWarningString("Bạn hãy nhập đáp án " + lableDapAn.Text);
                    return false;
                }
            }

            foreach (var tblPanelDapAn in _lstTablePanelDapAnPhai)
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
                LoadCauTraLoi(CauHoiCurent);
            }
            else if (Mode == ModeForm.ThemMoi)
            {
                //Add cau tra loi
                CauHoiCurent = new EX_CauHoi();
                IdCauHoiCurent = 1;
                // Add 4 cau tra loi mac dinh
                for (int i = 1; i <= 4; i++)
                {
                    CauHoiCurent.ListCauTraLoi.Add(new EX_CauTraLoi { IdEx = i, IsVeTrai = true });
                    CauHoiCurent.ListCauTraLoiPhai.Add(new EX_CauTraLoi { IdEx = i, IsVeTrai = false });
                    ThemCauTraLoiTrai();
                    ThemCauTraLoiPhai();
                }
            }
        }

        #endregion

        #region Private methods        

        #region Data

        private void InitForm()
        {
            #region Data
            _business = new ES_SoanCauHoiBLL();
            _lstTablePanelDapAnTrai = new List<TableLayoutPanel>();
            _lstTablePanelDapAnPhai = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();

            #endregion

            #region Control

            Dock = DockStyle.Fill;
            #endregion

            #region Event
            btnThemBenTrai.Click += BtnThemBenTrai_Click;
            btnThemBenPhai.Click += BtnThemBenPhai_Click;
            txtCtrlNoiDungCauHoi.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;
            #endregion
        }

        private void LoadCauHoiOld(EX_CauHoi cauHoi)
        {
            //noi dung cau hoi
            txtCtrlNoiDungCauHoi.Rtf = cauHoi.NoiDung;
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
            txtTieuDeVeTrai.Text = cauHoi.TieuDeVeTrai;
            txtTieuDeVePhai.Text = cauHoi.TieuDeVePhai;
        }

        private void LoadCauTraLoi(EX_CauHoi cauHoi)
        {
            // Load danh sách đáp án
            List<EX_CauTraLoi> listDapAnTrai = cauHoi.ListCauTraLoi;
            List<EX_CauTraLoi> listDapAnPhai = cauHoi.ListCauTraLoiPhai;
            foreach (var dapAnTrai in listDapAnTrai)
            {
                ThemCauTraLoiTrai(dapAnTrai);
            }
            foreach (var dapAnPhai in listDapAnPhai)
            {
                ThemCauTraLoiPhai(dapAnPhai);
            }
        }

        private void ClearAllCauTraLoi()
        {
            foreach (var tblPanelDapAn in _lstTablePanelDapAnTrai)
            {
                // Remove controls
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();

                // Remove table panel
                tblPanelMain.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelDapAnTrai = new List<TableLayoutPanel>();

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
            foreach (var tblPanelDapAn in _lstTablePanelDapAnPhai)
            {
                // Remove controls
                foreach (Control ctrl in tblPanelDapAn.Controls) ctrl.Dispose();
                tblPanelDapAn.Controls.Clear();

                // Remove table panel
                tblPanelMain2.Controls.Remove(tblPanelDapAn);
            }

            _lstTablePanelDapAnPhai = new List<TableLayoutPanel>();

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
            txtSoLuongTrai.Text = _lstTablePanelDapAnTrai.Count.ToString();
            txtSoLuongPhai.Text = _lstTablePanelDapAnPhai.Count.ToString();
        }

        #endregion

        #region Control

        private void ThemCauTraLoiTrai(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án đúng
            Label lblDapAn = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLableDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };  //Tag = 1 = true, Tag = 0 = false
            lblDapAn.Text = Convert.ToChar(65 + _lstTablePanelDapAnTrai.Count).ToString();

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
            btnXoa.Click += new EventHandler(XoaCauTraLoiTrai);

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BorderStyle = BorderStyle.FixedSingle };
            txtCtrl.Margin = new Padding(2);
            txtCtrl.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;

            // Table panel
            TableLayoutPanel tblPanelDapAn = new TableLayoutPanel();
            tblPanelDapAn.Name = _nameTablePanelDapAn + rowIndex;
            tblPanelDapAn.ColumnCount = 4;
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tblPanelDapAn.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tblPanelDapAn.RowCount = 1;
            tblPanelDapAn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPanelDapAn.Dock = DockStyle.Top;

            tblPanelDapAn.Controls.Add(lblDapAn, 0, 0);
            tblPanelDapAn.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAn.Controls.Add(btnXoa, 2, 0);
            tblPanelDapAn.Controls.Add(chkKhongDao, 3, 0);

            tblPanelMain.Controls.Add(tblPanelDapAn, 0, rowIndex);
            //add panel to list
            _lstTablePanelDapAnTrai.Add(tblPanelDapAn);

            if (cauTraLoi != null)
            {
                // Load noi dung dap an
                txtCtrl.Rtf = cauTraLoi.NoiDung;
                // Gán id câu trả lời
                btnXoa.Tag = cauTraLoi.Id;
                // Gán check không đảo
                chkKhongDao.Checked = cauTraLoi.IsKhongDao ?? false;
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
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLableDapAn, Tag = 0, Font = new Font(Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };  //Tag = 1 = true, Tag = 0 = false
            lblCauHoi.Text = (_lstTablePanelDapAnPhai.Count + 1).ToString();

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
            btnXoa.Click += new EventHandler(XoaCauTraLoiPhai);

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
            tblPanelDapAnPhai.Controls.Add(btnXoa, 2, 0);
            tblPanelDapAnPhai.Controls.Add(chkKhongDao, 3, 0);

            tblPanelMain2.Controls.Add(tblPanelDapAnPhai, 0, rowIndex);
            //add panel to list
            _lstTablePanelDapAnPhai.Add(tblPanelDapAnPhai);

            if (cauTraLoi != null)
            {
                // Load noi dung dap an
                if (!string.IsNullOrEmpty(cauTraLoi.NoiDung))
                {
                    txtCtrl.Rtf = cauTraLoi.NoiDung;
                }

                // Gán id câu trả lời
                btnXoa.Tag = cauTraLoi.Id;
                // Gán check không đảo
                chkKhongDao.Checked = cauTraLoi.IsKhongDao ?? false;
                tblPanelDapAnPhai.Tag = cauTraLoi.IdEx;
            }
            ResizeLayoutCauTraLoiPhai(true);
            SetTextSoLuongCauHoi();
        }

        private void ResetTextCauTraLoiTrai()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelDapAnTrai)
            {
                Label button = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                button.Text = Convert.ToChar(65 + viTri++).ToString();
            }
        }

        private void ResetTextCauTraLoiPhai()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelDapAnPhai)
            {
                Label button = tblPanelDapAn.Controls[_nameLableDapAn] as Label;
                button.Text = (1 + viTri++).ToString();
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
