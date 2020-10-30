using DataLayer.BLL;
using DataLayer.Common;
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
    public partial class UcTracNghiemDon : UserControlBase
    {
        #region Variable declarations      

        #region Data

        private ES_SoanCauHoiBLL _business;

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelDapAn;
        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameButtonDapAn = "btnDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #endregion

        #region Constructors

        public UcTracNghiemDon()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion        

        #region Public methods

        public bool SaveCauHoiNew()
        {
            try
            {
                //get body
                string noiDungCauHoiEx = txtCtrlNoiDungCauHoi.Rtf;
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                string noiDungCauTraLoiEx = "";

                foreach (var tblPanelDapAn in _lstTablePanelDapAn)
                {
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    SimpleButton btnDapAn = tblPanelDapAn.Controls[_nameButtonDapAn] as SimpleButton;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                    //get body
                    noiDungCauTraLoiEx = txtDapAn.Rtf;
                    lstCauTraLoi.Add(new EX_CauTraLoi()
                    {
                        NoiDung = noiDungCauTraLoiEx,
                        IsDung = Convert.ToBoolean(btnDapAn.Tag),
                        IsKhongDao = chkKhongDao.Checked
                    });
                }

                #region Kiểm tra trùng câu hỏi

                // Kiểm tra trùng đáp án
                if (lstCauTraLoi.GroupBy(o => o.NoiDung).ToList().Count < _lstTablePanelDapAn.Count &&
                    UICommon.ShowMsgQuestionString("Tồn tại đáp án trùng nhau. Bạn có muốn tiếp tục lưu không?") == DialogResult.No) return false;

                #endregion

                #region Save new câu hỏi

                EX_CauHoi ch = new EX_CauHoi();
                ch.IDChuong = IdDanhMuc;
                ch.DoKho = IdMucDoNhanThuc;
                ch.NoiDung = noiDungCauHoiEx;
                ch.IsSuDung = true;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
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

                IsChanged = false;
            }
            catch (Exception ex)
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

                //get body
                ch.DoKho = IdMucDoNhanThuc;
                ch.IDChuong = IdDanhMuc;
                ch.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                ch.IsSuDung = true;

                //save lai
                _business.UpdateCauHoi(IdCauHoiCurent, ch);

                #endregion

                #region update dap an

                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                foreach (var tblPanelDapAn in _lstTablePanelDapAn)
                {
                    SimpleButton btnXoa = tblPanelDapAn.Controls[_nameButtonXoa] as SimpleButton;
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;
                    SimpleButton btnDapAn = tblPanelDapAn.Controls[_nameButtonDapAn] as SimpleButton;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                    EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                    cauTraLoi.IDCauHoi = ch.Id;
                    cauTraLoi.IdEx = Convert.ToInt32(btnXoa.Tag);
                    cauTraLoi.NoiDung = txtDapAn.Rtf;
                    cauTraLoi.IsDung = Convert.ToBoolean(btnDapAn.Tag);
                    cauTraLoi.IsKhongDao = chkKhongDao.Checked;

                    lstCauTraLoi.Add(cauTraLoi);
                }

                #region Kiểm tra trùng câu hỏi

                // Kiểm tra trùng đáp án
                if (lstCauTraLoi.GroupBy(o => o.NoiDung).ToList().Count < _lstTablePanelDapAn.Count &&
                    UICommon.ShowMsgQuestionString("Tồn tại đáp án trùng nhau. Bạn có muốn tiếp tục lưu không?") == DialogResult.No) return false;

                #endregion

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
            string tmp = txtCtrlNoiDungCauHoi.Rtf;
            bool HasCauHoiCha = false;

            // Nếu nội dung rỗng và không có câu hỏi cha thì thông báo
            // Ngược lại khác rỗng hoặc rỗng nhưng có câu hỏi cha thì cho phép
            if (txtCtrlNoiDungCauHoi.IsEmpty && !HasCauHoiCha)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi.");
                return false;
            }

            int SoDapAnDung = 0;

            foreach (var tblPanelDapAn in _lstTablePanelDapAn)
            {
                SimpleButton buttonDapAn = tblPanelDapAn.Controls[_nameButtonDapAn] as SimpleButton;
                EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungDapAn] as EditorControl;

                if (txtDapAn.IsEmpty)
                {
                    UICommon.ShowMsgWarningString("Bạn hãy nhập đáp án " + buttonDapAn.Text);
                    return false;
                }

                //neu la dap an dung thi dem len 1
                if (Convert.ToInt32(buttonDapAn.Tag) == 1)
                {
                    SoDapAnDung++;
                }
            }

            //neu chua co dap an dung nao thi thong bao (toi thieu phai co 1 dap an dung)
            if (SoDapAnDung == 0)
            {
                UICommon.ShowMsgWarningString("Bạn hãy chọn đáp án đúng.");
                return false;
            }

            return true;
        }

        public void CauHoiLoad()
        {
            ClearAllCauTraLoi();
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                if (CheckAllEditCauHoi(IdCauHoiCurent))
                {
                    LoadCauHoiOld(CauHoiCurent);
                    LoadCauTraLoi(CauHoiCurent);
                }
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

        #endregion

        #region Private methods

        #region Data

        private void InitForm()
        {
            #region Data
            _business = new ES_SoanCauHoiBLL();
            _lstTablePanelDapAn = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();

            #endregion

            this.Dock = DockStyle.Fill;
            CauHoiLoad();

            #region Event

            btnThemCauTraLoi.Click += BtnThemCauTraLoi_Click;
            txtCtrlNoiDungCauHoi.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;

            #endregion
        }

        private bool CheckAllEditCauHoi(long idCauHoi)
        {
            // Kiểm tra câu hỏi
            EX_CauHoi cauHoi = _business.GetById(idCauHoi);
            if (cauHoi == null)
            {
                UICommon.ShowMsgWarningString("Câu hỏi không tồn tại.");
                return false;
            }

            // Kiểm tra Đơn vị KT
            EX_DanhMuc dm = _business.GetDanhMucById(cauHoi.IDChuong);
            if (dm == null)
            {
                UICommon.ShowMsgWarningString("Đơn vị KT không tồn tại.");
                return false;
            }

            return true;
        }

        private void LoadCauHoiOld(EX_CauHoi cauHoi)
        {
            //noi dung cau hoi
            txtCtrlNoiDungCauHoi.Rtf = cauHoi.NoiDung;
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
        }

        private void LoadCauTraLoi(EX_CauHoi cauHoi)
        {
            // Load danh sách đáp án
            List<EX_CauTraLoi> listDapAn = cauHoi.ListCauTraLoi;
            foreach (var dapAn in listDapAn)
            {
                ThemCauTraLoi(dapAn);
            }
        }

        private string ConvertNoiDungCauHoi(string cauHoi)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            string content = reg.Replace(cauHoi, "");

            // nếu nội dung rỗng, do chỉ có hình ảnh, trả về <rỗng>
            if (content.Trim().Length == 0)
            {
                return "<rỗng>";
            }
            else
            {
                // giới hạn lấy 50 kí tự
                if (content.Length > 50)
                {
                    return content.Substring(0, 49) + "...";
                }
                else
                {
                    return content;
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

        #endregion

        #region Control

        private void ThemCauTraLoi(EX_CauTraLoi cauTraLoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án đúng
            var text = Convert.ToChar(65 + _lstTablePanelDapAn.Count).ToString();
            var btnDapAn = new DevExpress.XtraEditors.SimpleButton();
            btnDapAn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnDapAn.Appearance.Options.UseFont = true;
            btnDapAn.Dock = System.Windows.Forms.DockStyle.Right;
            btnDapAn.Margin = new System.Windows.Forms.Padding(2);
            btnDapAn.Name = _nameButtonDapAn;
            btnDapAn.Text = text;
            btnDapAn.Tag = 0;
            btnDapAn.ToolTip = "Đáp án " + text;
            btnDapAn.Click += new EventHandler(btnDapAn_Click);

            // Xóa câu trả lời
            var btnXoa = new DevExpress.XtraEditors.SimpleButton();
            btnXoa.ImageOptions.Image = global::SimpleTest.Properties.Resources.tsbDelete;
            btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            btnXoa.Margin = new System.Windows.Forms.Padding(2);
            btnXoa.Name = _nameButtonXoa;
            btnXoa.Text = "";
            btnXoa.Tag = 0;
            btnXoa.Width = 40;
            btnXoa.ToolTip = "Xóa câu trả lời";
            btnXoa.Click += new EventHandler(XoaCauTraLoi);

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            #region CauTraLoi

            var txtCtrl = new EditorControl();
            txtCtrl.Dock = DockStyle.Fill;
            txtCtrl.Location = new Point(0, 0);
            txtCtrl.Name = _nameTextNoiDungDapAn;
            txtCtrl.Size = new Size(886, 127);
            txtCtrl.TabIndex = 0;
            txtCtrl.Margin = new Padding(2);
            txtCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCtrl.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;

            #endregion

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

            tblPanelDapAn.Controls.Add(btnDapAn, 0, 0);
            tblPanelDapAn.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAn.Controls.Add(btnXoa, 2, 0);
            tblPanelDapAn.Controls.Add(chkKhongDao, 3, 0);

            tblPanelMain.Controls.Add(tblPanelDapAn, 0, rowIndex);
            //add panel to list
            _lstTablePanelDapAn.Add(tblPanelDapAn);

            if (cauTraLoi != null)
            {
                // Tô màu đáp án đúng
                if (cauTraLoi.IsDung ?? false)
                {
                    btnDapAn.BackColor = Color.Red;
                    btnDapAn.ForeColor = Color.Red;
                    btnDapAn.Font = new Font(btnDapAn.Font.FontFamily, 11F, FontStyle.Bold);
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

        private void ResetTextCauTraLoi()
        {
            int viTri = 0;
            foreach (var tblPanelDapAn in _lstTablePanelDapAn)
            {
                SimpleButton button = tblPanelDapAn.Controls[_nameButtonDapAn] as SimpleButton;
                button.Text = Convert.ToChar(65 + viTri++).ToString();
            }
        }

        private void ResizeLayoutCauTraLoi(bool isAdd)
        {
            tblPanelMain.AutoScroll = false;
            var heightTb = tblPanelMain.Height;
            if (!isAdd)
                tblPanelMain.Height = heightTb - 63;

            tblPanelMain.AutoScroll = true;
        }

        #endregion

        #endregion

        #region Events

        #region CauTraLoi

        private void btnDapAn_Click(object sender, EventArgs e)
        {
            //doi mau khi chon dap an dung

            //SimpleButton btn = sender as SimpleButton;
            SimpleButton btn = sender as SimpleButton;

            //highlight neu dap an dung
            int IsDung = Convert.ToInt32(btn.Tag);

            //neu dang la sai, thi cho dung
            if (IsDung == 0)
            {
                btn.Tag = 1;
                btn.ForeColor = Color.Red;
                btn.Font = new Font(btn.Font.FontFamily, 11F, FontStyle.Bold);
            }
            else if (IsDung == 1)
            {
                btn.Tag = 0;
                btn.ForeColor = Color.Black;
                btn.Font = new Font(btn.Font.FontFamily, 11F, FontStyle.Bold);
            }
            IsChanged = true;
        }

        private void XoaCauTraLoi(object sender, EventArgs e)
        {
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
            this.ResetTextCauTraLoi();
            ResizeLayoutCauTraLoi(false);
        }

        #endregion

        #region Control

        private void BtnThemCauTraLoi_Click(object sender, EventArgs e)
        {
            ThemCauTraLoi();
            if (Mode == ModeForm.CapNhat)
            {
                IsChanged = true;
            }
        }

        private void TxtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = (EditorControl)sender;
        }

        #endregion

        #endregion

    }
}