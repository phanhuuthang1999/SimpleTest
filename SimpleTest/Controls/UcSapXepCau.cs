using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.XtraEditors;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Controls
{
    public partial class UcSapXepCau : UserControlBase
    {
        #region Variable declarations      

        #region Data

        private ES_SoanCauHoiBLL _cauHoiBll = new ES_SoanCauHoiBLL();

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelCauHoi;
        private const string _nameTablePanelCauHoi = "tblPanelCauHoi";
        private const string _nameLableCauHoi = "lblCauHoi";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungCauHoi = "txtCtrlCauHoi";
        private const string _nameCheckBox = "chkKhongDao";

        #endregion

        #endregion

        #region Constructors

        public UcSapXepCau()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion        

        #region Public methods

        public int SaveCauHoiNew()
        {
            EX_CauHoi chc = new EX_CauHoi();
            try
            {
                //get body
                string noiDungCauHoiEx = txtCtrlNoiDungCauHoi.Rtf;
                List<EX_CauHoi> lstCauHoiCon = new List<EX_CauHoi>();
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();

                foreach (var tblPanelCauHoi in _lstTablePanelCauHoi)
                {
                    EditorControl txtCauHoi = tblPanelCauHoi.Controls[_nameTextNoiDungCauHoi] as EditorControl;
                    Label lblCauHoi = tblPanelCauHoi.Controls[_nameLableCauHoi] as Label;
                    CheckBox chkKhongDao = tblPanelCauHoi.Controls[_nameCheckBox] as CheckBox;
                    SimpleButton btnXoa = tblPanelCauHoi.Controls[_nameButtonXoa] as SimpleButton;
                    int idEx = (int)btnXoa.Tag;

                    //get body
                    var noiDungCauHoiConEx = txtCauHoi.Rtf;
                    lstCauHoiCon.Add(new EX_CauHoi()
                    {
                        NoiDung = noiDungCauHoiConEx,
                        IsKhongDao = chkKhongDao.Checked,
                        IDEx = idEx
                    });

                    // Tìm câu trả lời
                    var cauHoi = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.IDEx == idEx);
                    if (cauHoi != null)
                    {
                        lstCauTraLoi.Add(cauHoi.ListCauTraLoi.FirstOrDefault());
                    }
                }

                #region Save new câu hỏi

                chc.IDChuong = IdDanhMuc;
                chc.NoiDung = noiDungCauHoiEx;
                chc.IDLoaiCauHoi = IdLoaiCauHoi;
                chc.IsCauHoiCha = true;
                chc.NgayTao = DateTime.Now;
                chc.DoKho = IdMucDoNhanThuc;

                foreach (var exCauHoi in lstCauHoiCon)
                {
                    exCauHoi.IDCauHoiCha = chc.Id;
                    exCauHoi.IDChuong = chc.IDChuong;
                    exCauHoi.DoKho = IdMucDoNhanThuc;
                    exCauHoi.IDLoaiCauHoi = chc.IDLoaiCauHoi;
                    exCauHoi.IsSuDung = true;
                    exCauHoi.NgaySoan = DateTime.Now;

                    // Add câu trả lời tương ứng với câu hỏi
                    foreach (var exCauTraLoi in lstCauTraLoi)
                    {
                        if (exCauTraLoi.IdEx == exCauHoi.IDEx)
                        {
                            exCauTraLoi.IDCauHoi = exCauHoi.Id;
                            exCauHoi.ListCauTraLoi.Add(exCauTraLoi);
                            break;
                        }
                    }
                    chc.ListCauHoi.Add(exCauHoi);
                }

                #endregion                

                IsChanged = false;
            }
            catch (Exception ex)
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

                if (CauHoiCurent == null) return 0;

                //get body
                CauHoiCurent.IDChuong = IdDanhMuc;
                CauHoiCurent.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                CauHoiCurent.IDLoaiCauHoi = IdLoaiCauHoi;
                CauHoiCurent.IsCauHoiCha = true;
                CauHoiCurent.DoKho = IdMucDoNhanThuc;

                #endregion

                #region Update câu hỏi con

                List<EX_CauHoi> lstCauHoi = new List<EX_CauHoi>();
                List<EX_CauTraLoi> lstCauTraLoi = new List<EX_CauTraLoi>();
                foreach (var tblPanelDapAn in _lstTablePanelCauHoi)
                {
                    SimpleButton btnXoa = tblPanelDapAn.Controls[_nameButtonXoa] as SimpleButton;
                    EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungCauHoi] as EditorControl;
                    Label lblCauHoi = tblPanelDapAn.Controls[_nameLableCauHoi] as Label;
                    CheckBox chkKhongDao = tblPanelDapAn.Controls[_nameCheckBox] as CheckBox;
                    int idEX = Convert.ToInt32(btnXoa.Tag);

                    EX_CauHoi cauHoi = new EX_CauHoi();
                    cauHoi.IDCauHoiCha = (int)CauHoiCurent.Id;
                    cauHoi.IDEx = idEX;
                    cauHoi.NoiDung = txtDapAn.Rtf;
                    cauHoi.IsKhongDao = chkKhongDao.Checked;
                    cauHoi.DoKho = IdMucDoNhanThuc;
                    cauHoi.IDLoaiCauHoi = IdLoaiCauHoi;
                    cauHoi.IDChuong = IdDanhMuc;

                    lstCauHoi.Add(cauHoi);

                    // Tìm câu trả lời
                    var cauHoiTmp = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.IDEx == idEX);
                    if (cauHoiTmp != null)
                    {
                        lstCauTraLoi.Add(cauHoiTmp.ListCauTraLoi.FirstOrDefault());
                    }
                }


                // Cập nhật câu hỏi
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
                    }
                }

                // Xoa cau hoi
                foreach (int IdCauHoiBiXoa in ListIdCauHoiBiXoa)
                {
                    var cauHoiDel = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.Id == IdCauHoiBiXoa);
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

            return _cauHoiBll.UpdateCauHoi(CauHoiCurent.Id,CauHoiCurent);
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

            foreach (var tblPanelDapAn in _lstTablePanelCauHoi)
            {
                Label lblCauHoi = tblPanelDapAn.Controls[_nameLableCauHoi] as Label;
                EditorControl txtDapAn = tblPanelDapAn.Controls[_nameTextNoiDungCauHoi] as EditorControl;

                if (txtDapAn.IsEmpty)
                {
                    UICommon.ShowMsgWarningString("Bạn hãy nhập đáp án " + lblCauHoi.Text);
                    return false;
                }
            }

            return true;
        }

        public void CauHoiLoad()
        {
            ClearAllCauTraLoi();
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                LoadCauHoiOld(CauHoiCurent);
                LoadCauHoiVaCauTraLoi(CauHoiCurent);
            }
            else if (Mode == ModeForm.ThemMoi)
            {
                CauHoiCurent = new EX_CauHoi();
                // Add 4 cau tra loi mac dinh
                for (int i = 1; i <= 4; i++)
                {
                    var cauHoi = new EX_CauHoi { IDEx = i, NoiDung = "" };
                    var cauTraLoi = new EX_CauTraLoi { IdEx = i, NoiDung = "", IsKhongDao = false, IsDung = true };
                    cauHoi.ListCauTraLoi.Add(cauTraLoi);
                    CauHoiCurent.ListCauHoi.Add(cauHoi);

                    ThemCauHoiCon(cauHoi);
                }
            }
        }

        #endregion

        #region Private methods        

        #region Data

        private void InitForm()
        {
            #region Data

            _cauHoiBll = new ES_SoanCauHoiBLL();
            _lstTablePanelCauHoi = new List<TableLayoutPanel>();
            ListIdCauHoiBiXoa = new List<long>();
            ListIdCauTraLoiBiXoa = new List<long>();

            #endregion

            this.Dock = DockStyle.Fill;
            CauHoiLoad();

            #region Event

            btnThemCauHoi.Click += btnThemCauHoi_Click;
            txtCtrlNoiDungCauHoi.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;

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
            List<EX_CauHoi> lstCauHoi = cauHoiCha.ListCauHoi;

            foreach (EX_CauHoi cauHoi in lstCauHoi)
            {
                // Gắn IdEx = Id để khi có thêm mới thì sẽ ko bị trùng IdEx với những câu hỏi cũ
                cauHoi.IDEx = (int)cauHoi.Id;
                var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault();
                if (cauTraLoi != null)
                {
                    cauTraLoi.IdEx = (int)cauHoi.IDEx;
                }
                ThemCauHoiCon(cauHoi);
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

        #endregion

        #region Control

        private void ThemCauHoiCon(EX_CauHoi cauHoi = null)
        {
            //add more 2 new rows
            tblPanelMain.RowCount += 2;
            int rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));

            // Đáp án đúng
            Label lblCauHoi = new Label() { Width = 40, Dock = DockStyle.Right, Name = _nameLableCauHoi, Tag = 0, Font = new Font(this.Font.FontFamily, 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
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
            btnXoa.Click += new EventHandler(XoaCauHoiCon);

            // Không đảo vị trí
            CheckBox chkKhongDao = new CheckBox() { Text = "Không đảo", Dock = DockStyle.Fill, Name = _nameCheckBox };

            #region CauHoi

            var txtCtrl = new EditorControl();
            txtCtrl.Dock = DockStyle.Fill;
            txtCtrl.Location = new Point(0, 0);
            txtCtrl.Name = _nameTextNoiDungCauHoi;
            txtCtrl.Size = new Size(886, 127);
            txtCtrl.TabIndex = 0;
            txtCtrl.Margin = new Padding(2);
            txtCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCtrl.GotFocus += TxtCtrlNoiDungCauHoi_GotFocus;

            #endregion

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
                // Load noi dung dap an
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

            ResizeLayoutCauTraLoi(true);
        }

        private void ResetTextCauTraLoi()
        {
            int viTri = 0;
            foreach (var tblPanelCauHoi in _lstTablePanelCauHoi)
            {
                Label lblCauHoi = tblPanelCauHoi.Controls[_nameLableCauHoi] as Label;
                lblCauHoi.Text = (1 + viTri++).ToString();
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

        #region CauHoi

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            var maxIdEx = CauHoiCurent.ListCauHoi.Max(m => m.IDEx);
            var cauHoi = new EX_CauHoi { IDEx = maxIdEx + 1, NoiDung = "" };
            var cauTraLoi = new EX_CauTraLoi { IdEx = maxIdEx + 1, NoiDung = "", IsKhongDao = false, IsDung = true };
            cauHoi.ListCauTraLoi.Add(cauTraLoi);
            CauHoiCurent.ListCauHoi.Add(cauHoi);

            ThemCauHoiCon(cauHoi);

            if (Mode == ModeForm.CapNhat)
            {
                IsChanged = true;
            }
        }

        private void XoaCauHoiCon(object sender, EventArgs e)
        {
            //Nếu trái it nhất phải = 1
            if (_lstTablePanelCauHoi.Count == 2)
            {
                UICommon.ShowMsgWarningString("Số câu hỏi con không được nhỏ hơn 2 \nBạn không thể xóa!");
                return;
            }

            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu hỏi này không ?") != DialogResult.Yes)
            {
                return;
            }

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;
            int rowIndex = tblPanelMain.GetRow(tblPanelDapAn);

            //get id cau hoi bi xoa
            int idEx = Convert.ToInt32(button.Tag);

            //neu khac 0 la cau hoi da ton tai, can xoa
            var cauHoi = CauHoiCurent.ListCauHoi.FirstOrDefault(m => m.IDEx == idEx);
            if (cauHoi != null && cauHoi.Id > 0)
            {
                ListIdCauHoiBiXoa.Add((int)cauHoi.Id);
                ListIdCauTraLoiBiXoa.Add((int)cauHoi.ListCauTraLoi.FirstOrDefault()?.Id);

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
            _lstTablePanelCauHoi.Remove(tblPanelDapAn);

            //decrease row index of panels down 2
            //rename panel
            for (int i = rowIndex + 2; i < tblPanelMain.RowStyles.Count; i = i + 2)
            {
                tblPanelDapAn = tblPanelMain.Controls[_nameTablePanelCauHoi + i] as TableLayoutPanel;

                if (tblPanelDapAn != null)
                {
                    tblPanelMain.SetRow(tblPanelDapAn, i - 2);
                    tblPanelDapAn.Name = _nameTablePanelCauHoi + (i - 2);
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

        private void TxtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = (EditorControl)sender;
        }

        #endregion

        #endregion        
    }
}