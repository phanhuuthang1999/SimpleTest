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
    public partial class UcGachChanDon : UserControlBase
    {
        #region Variable declarations      

        #region Data
        private ES_SoanCauHoiBLL _business;
        private int _textLength = 0;

        #endregion

        #region Control

        private List<TableLayoutPanel> _lstTablePanelDapAn;
        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameButtonDapAn = "btnDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";
        private int _rowInsert;

        #endregion

        #endregion

        #region Constructors

        public UcGachChanDon()
        {
            InitializeComponent();
            InitForm();
            SimpleTest.Common.EventAggregator.Instance.Subscribe(EventType.UnderlineClick, OnUnderlineClicked);
        }

        #endregion

        #region Events

        private void OnUnderlineClicked(object sender, EventArg e)
        {
            var obj = (EditorControl)sender;
            if (obj != null && obj.Name == "txtCtrlNoiDungCauHoi")
            {

                var lenght = txtCtrlNoiDungCauHoi.SelectionLength;
                if (lenght > 0 && !string.IsNullOrEmpty(txtCtrlNoiDungCauHoi.SelectedText.Trim()))
                {
                    var index = txtCtrlNoiDungCauHoi.SelectionStart;
                    var line = txtCtrlNoiDungCauHoi.GetLineFromCharIndex(index);
                    if (CauHoiCurent.ListCauTraLoi.Any(n => (n.IndexEx <= index && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) >= index)
                                                          || (n.IndexEx <= (index + lenght) && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) >= (index + lenght))
                                                          || (n.IndexEx >= index && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) <= (index + lenght))
                                                          ))
                    {
                        UICommon.ShowMsgWarningString("Vị trí gạch chân không hợp lệ");
                        txtCtrlNoiDungCauHoi.ReadOnly = false;
                        txtCtrlNoiDungCauHoi.Undo();
                        txtCtrlNoiDungCauHoi.ReadOnly = true;
                        return;
                    }
                    if (txtCtrlNoiDungCauHoi.GetLineFromCharIndex(index + lenght) != line)
                    {
                        UICommon.ShowMsgWarningString("Vị trí gạch chân không hợp lệ");
                        txtCtrlNoiDungCauHoi.ReadOnly = false;
                        txtCtrlNoiDungCauHoi.Undo();
                        txtCtrlNoiDungCauHoi.ReadOnly = true;
                        return;
                    }
                    // Xóa hết câu trả lời để add lại
                    ClearAllCauTraLoi();
                    // nếu như là hợp lệ
                    CauHoiCurent.ListCauTraLoi.Add(new EX_CauTraLoi { NoiDung = txtCtrlNoiDungCauHoi.SelectedRtf, IndexEx = index, Line = line });
                    //Add lại câu trả lời
                    CauHoiCurent.ListCauTraLoi = CauHoiCurent.ListCauTraLoi.OrderBy(n => n.IndexEx).ToList();
                    for (int i = 1; i <= CauHoiCurent.ListCauTraLoi.Count; i++)
                    {
                        var ctraLoi = CauHoiCurent.ListCauTraLoi[i - 1];
                        ctraLoi.IdEx = i;
                        ThemCauTraLoi(ctraLoi);
                    }
                }
                else if (lenght > 0)
                {
                    UICommon.ShowMsgWarningString("Vị trí gạch chân không hợp lệ");
                    txtCtrlNoiDungCauHoi.ReadOnly = false;
                    txtCtrlNoiDungCauHoi.Undo();
                    txtCtrlNoiDungCauHoi.ReadOnly = true;
                }
            }
            else
            {
                if (txtCtrlNoiDungCauHoi.SelectionLength > 0)
                {
                    txtCtrlNoiDungCauHoi.ReadOnly = false;
                    txtCtrlNoiDungCauHoi.Undo();
                    txtCtrlNoiDungCauHoi.ReadOnly = true;
                }
            }
        }

        private void btnDapAn_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            //neu dang la sai, thi cho dung
            if (btn.ForeColor != Color.Red)
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.Red;
                btn.Font = new Font(btn.Font.FontFamily, 11F, FontStyle.Bold);
            }
            else if (btn.ForeColor == Color.Red)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.Black;
                btn.Font = new Font(btn.Font.FontFamily, 11F, FontStyle.Bold);
            }
            var cauTraLoi = CauHoiCurent.ListCauTraLoi.FirstOrDefault(m => m.IdEx == (int)btn.Tag);
            cauTraLoi.IsDung = btn.ForeColor == Color.Red;
            IsChanged = true;
        }

        private void txtCtrlNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = (EditorControl)sender;
        }

        private void txtCtrlNoiDungCauHoi_TextChanged(object sender, EventArgs e)
        {
            if (CauHoiCurent.ListCauTraLoi.Count == 0)
            {
                _textLength = txtCtrlNoiDungCauHoi.TextLength;
                return;
            }
            var lenghtNow = txtCtrlNoiDungCauHoi.TextLength;
            var indexNow = txtCtrlNoiDungCauHoi.SelectionStart;
            if (lenghtNow > _textLength && _textLength > 0)
            {
                foreach (var ctl in CauHoiCurent.ListCauTraLoi)
                {
                    if (ctl.IndexEx + (lenghtNow - _textLength) >= indexNow)
                    {
                        ctl.IndexEx += lenghtNow - _textLength;
                    }
                }
            }
            else if (lenghtNow < _textLength && _textLength > 0)
            {
                foreach (var ctl in CauHoiCurent.ListCauTraLoi)
                {
                    if (ctl.IndexEx + (_textLength - lenghtNow) >= indexNow)
                    {
                        ctl.IndexEx -= _textLength - lenghtNow;
                    }
                }
            }
            _textLength = txtCtrlNoiDungCauHoi.TextLength;
        }

        private void txtCtrlNoiDungCauHoi_KeyDown(object sender, KeyEventArgs e)
        {

            RichTextBox richTextBox1 = (RichTextBox)sender;
            if (richTextBox1.ReadOnly)
                return;
            bool flag1 = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
            bool flag2 = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;
            bool flag3 = e.KeyCode == Keys.Delete;
            bool flag4 = e.KeyCode == Keys.Back;
            int selectionStart = richTextBox1.SelectionStart;
            if (flag3)
            {
                foreach (var ctl in CauHoiCurent.ListCauTraLoi)
                {
                    if (ctl.IndexEx == selectionStart)
                    {
                        richTextBox1.ReadOnly = true;
                        break;
                    }
                    richTextBox1.ReadOnly = false;
                }
            }
            if (flag4)
            {
                foreach (var ctl in CauHoiCurent.ListCauTraLoi)
                {
                    if (ctl.IndexEx + UICommon.GetLengthRtf(ctl.NoiDung) == selectionStart)
                    {
                        richTextBox1.ReadOnly = true;
                        break;
                    }
                    richTextBox1.ReadOnly = false;
                }
            }

            if (richTextBox1.SelectionLength == richTextBox1.TextLength)
            {
                if (flag1 | flag2)
                {
                    RichTextBox richTextBox2 = new RichTextBox();
                    richTextBox2.Clear();
                    richTextBox2.Paste();
                    Clipboard.Clear();
                    richTextBox2.SelectAll();
                    richTextBox2.SelectionColor = Color.Black;
                    richTextBox2.SelectionFont = new Font("Times New Roman", 11.25f, FontStyle.Regular);
                    richTextBox2.Copy();
                    richTextBox1.Visible = false;
                    richTextBox1.Clear();
                    richTextBox1.Paste();
                    richTextBox1.Focus();
                    richTextBox1.Visible = true;
                    richTextBox1.SelectionLength = 0;
                    richTextBox1.Select(richTextBox1.TextLength, 0);
                    Clipboard.Clear();
                }
                else if (flag3 | flag4)
                {
                    RichTextBox richTextBox2 = new RichTextBox();
                    Clipboard.Clear();
                    richTextBox2.Clear();
                }
            }
        }

        private void txtCtrlNoiDungCauHoi_SelectionChanged(object sender, EventArgs e)
        {
            var lenght = txtCtrlNoiDungCauHoi.SelectionLength;
            txtCtrlNoiDungCauHoi.ReadOnly = false;
            var index = txtCtrlNoiDungCauHoi.SelectionStart;
            var line = txtCtrlNoiDungCauHoi.GetLineFromCharIndex(index);
            if (CauHoiCurent.ListCauTraLoi.Any(n => (n.IndexEx <= index && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) >= index)
                                                  || (n.IndexEx <= (index + lenght) && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) >= (index + lenght))
                                                  || (n.IndexEx >= index && (n.IndexEx + UICommon.GetLengthRtf(n.NoiDung)) <= (index + lenght))
                                                  ))
            {
                txtCtrlNoiDungCauHoi.ReadOnly = true;
                return;
            }
            if (txtCtrlNoiDungCauHoi.GetLineFromCharIndex(index + lenght) != line)
            {
                txtCtrlNoiDungCauHoi.ReadOnly = true;
                return;
            }

            //RichTextBox richTextBox = (RichTextBox)sender;
            //var selectionLenghNow = richTextBox.SelectionLength;

            //if (_cauHoiCurent.ListCauTraLoi.Count < 2)
            //    _textLength = richTextBox.TextLength;
            //richTextBox.ReadOnly = false;
            //foreach (var ctl in _cauHoiCurent.ListCauTraLoi)
            //{
            //    if (richTextBox.SelectionStart >= ctl.IndexEx && richTextBox.SelectionStart <= ctl.IndexEx + UICommon.GetLengthRtf(ctl.NoiDung) || richTextBox.SelectionStart + selectionLenghNow >= ctl.IndexEx && richTextBox.SelectionStart + selectionLenghNow <= ctl.IndexEx + UICommon.GetLengthRtf(ctl.NoiDung))
            //    {
            //        richTextBox.ReadOnly = true;
            //        break;
            //    }
            //    if (richTextBox.SelectionStart < ctl.IndexEx && richTextBox.SelectionStart + selectionLenghNow > ctl.IndexEx + UICommon.GetLengthRtf(ctl.NoiDung) && selectionLenghNow != richTextBox.TextLength)
            //    {
            //        richTextBox.ReadOnly = true;
            //        break;
            //    }
            //    richTextBox.ReadOnly = false;
            //}
        }

        private void XoaCauTraLoi(object sender, EventArgs e)
        {
            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn xóa câu trả lời này không ?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            SimpleButton button = sender as SimpleButton;
            TableLayoutPanel tblPanelDapAn = button.Parent as TableLayoutPanel;

            //get id cau hoi bi xoa
            int idEx = Convert.ToInt32(button.Tag);
            var cauTraLoi = CauHoiCurent.ListCauTraLoi.FirstOrDefault(m => m.IdEx == idEx);
            if (cauTraLoi != null)
            {
                // Xóa gạch chân trên câu hỏi
                txtCtrlNoiDungCauHoi.SelectionStart = cauTraLoi.IndexEx ?? 0;
                txtCtrlNoiDungCauHoi.SelectionLength = UICommon.GetLengthRtf(cauTraLoi.NoiDung);
                if (txtCtrlNoiDungCauHoi.IsUnderline())
                    txtCtrlNoiDungCauHoi.Underline();
                CauHoiCurent.ListCauTraLoi = CauHoiCurent.ListCauTraLoi.Except(new List<EX_CauTraLoi> { cauTraLoi }).ToList();
                // Nhập những câu hỏi có Id bị xóa
                if (cauTraLoi.Id > 0)
                {
                    ListIdCauHoiBiXoa.Add(cauTraLoi.Id);
                    IsChanged = true;
                }

            }
            // Xóa hết trên màn hình
            ClearAllCauTraLoi();
            // Hiển thị lại
            for (int i = 1; i <= CauHoiCurent.ListCauTraLoi.Count; i++)
            {
                var ctraLoi = CauHoiCurent.ListCauTraLoi[i - 1];
                ctraLoi.IdEx = i;
                ThemCauTraLoi(ctraLoi);
            }
        }

        #endregion

        #region Public methods

        public bool SaveCauHoiNew()
        {
            try
            {
                #region Kiểm tra trùng câu hỏi

                // Kiểm tra trùng đáp án
                if (CauHoiCurent.ListCauTraLoi.GroupBy(o => o.NoiDung).ToList().Count < _lstTablePanelDapAn.Count &&
                    UICommon.ShowMsgQuestionString("Tồn tại đáp án trùng nhau. Bạn có muốn tiếp tục lưu không?") == DialogResult.No) return false;

                #endregion

                #region Save new câu hỏi

                EX_CauHoi ch = new EX_CauHoi();
                ch.IDChuong = IdDanhMuc;
                ch.DoKho = IdMucDoNhanThuc;
                ch.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                ch.IsSuDung = true;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                ch.NgaySoan = DateTime.Now;
                _business.AddNewCauHoi(ch);

                // Danh sách câu trả lời
                foreach (var esCauTraLoi in CauHoiCurent.ListCauTraLoi)
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

                //get body
                ch.DoKho = IdMucDoNhanThuc;
                ch.IDChuong = IdDanhMuc;
                ch.NoiDung = txtCtrlNoiDungCauHoi.Rtf;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.IDLoaiCauHoi = IdLoaiCauHoi;

                //save lai
                _business.UpdateCauHoi(IdCauHoiCurent, ch);

                #endregion

                // Cập nhật câu trả lời
                foreach (var esCauTraLoi in CauHoiCurent.ListCauTraLoi)
                {
                    if (esCauTraLoi.Id == 0)
                    {
                        esCauTraLoi.IDCauHoi = CauHoiCurent.Id;
                        _business.AddNewCauTraLoi(esCauTraLoi);
                    }
                    else _business.UpdateCauTraLoi(esCauTraLoi.Id, esCauTraLoi);
                }

                // Xoa cau tra loi
                foreach (int IdCauTraLoiBiXoa in ListIdCauHoiBiXoa)
                {
                    _business.DeleteCauTraLoiById(IdCauTraLoiBiXoa);
                }

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
            if (txtCtrlNoiDungCauHoi.IsEmpty)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi.");
                return false;
            }

            List<string> lstCauTraLoi = new List<string>();
            if (!CauHoiCurent.ListCauTraLoi.Any(m => m.IsDung ?? false))
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn đáp án đúng");
                return false;
            }

            if (CauHoiCurent.ListCauTraLoi.Any(m => UICommon.GetLengthRtf(m.NoiDung) == 0))
            {
                UICommon.ShowMsgWarningString("Tồn tại câu trả lời bạn chưa nhập nội dung");
                return false;
            }

            return true;
        }

        public void CauHoiLoad()
        {
            if (Mode == ModeForm.CapNhat)
            {
                LoadCauHoiOld(CauHoiCurent);
                LoadCauTraLoi(CauHoiCurent);
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

            #region Control

            this.Dock = DockStyle.Fill;
            txtCtrlNoiDungCauHoi.EnableAutoDragDrop = false;

            #endregion

            #region Event

            txtCtrlNoiDungCauHoi.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;
            txtCtrlNoiDungCauHoi.KeyDown += txtCtrlNoiDungCauHoi_KeyDown;
            txtCtrlNoiDungCauHoi.SelectionChanged += txtCtrlNoiDungCauHoi_SelectionChanged;
            txtCtrlNoiDungCauHoi.TextChanged += txtCtrlNoiDungCauHoi_TextChanged;
            //Comment
            //ucToolstript1.OnUnderLineClick += UcToolstript1_OnUnderLineClick;

            #endregion
        }

        private void LoadCauHoiOld(EX_CauHoi cauHoi)
        {
            //noi dung cau hoi
            txtCtrlNoiDungCauHoi.Rtf = cauHoi.NoiDung;
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
        }

        private void LoadCauTraLoi(EX_CauHoi cauHoi)
        {
            CauHoiCurent.ListCauTraLoi = CauHoiCurent.ListCauTraLoi.OrderBy(n => n.IndexEx).ToList();
            for (int i = 1; i <= CauHoiCurent.ListCauTraLoi.Count; i++)
            {
                var ctraLoi = CauHoiCurent.ListCauTraLoi[i - 1];
                ctraLoi.IdEx = i;
                ThemCauTraLoi(ctraLoi);
            }
        }

        private string ConvertNoiDungCauHoi(string cauHoi)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            string content = reg.Replace(cauHoi, "");

            //nếu nội dung rỗng, do chỉ có hình ảnh, trả về <rỗng>
            if (content.Trim().Length == 0)
            {
                return "<rỗng>";
            }
            else
            {
                //giới hạn lấy 50 kí tự
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
            int rowIndex = 0;

            if (_lstTablePanelDapAn.Count == 0 || _lstTablePanelDapAn.Count % 2 == 0)
            {
                tblPanelMain.RowCount += 2;
                rowIndex = tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
                tblPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                _rowInsert = rowIndex;
            }

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
            btnXoa.Width = 40;
            btnXoa.ToolTip = "Xóa câu trả lời";
            btnXoa.Click += new EventHandler(XoaCauTraLoi);

            //EditorControl
            EditorControl txtCtrl = new EditorControl() { Dock = DockStyle.Fill, Name = _nameTextNoiDungDapAn, BorderStyle = BorderStyle.FixedSingle };
            txtCtrl.ReadOnly = true;
            txtCtrl.BackColor = Color.White;
            txtCtrl.Margin = new Padding(2);
            txtCtrl.GotFocus += txtCtrlNoiDungCauHoi_GotFocus;

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

            tblPanelDapAn.Controls.Add(btnDapAn, 0, 0);
            tblPanelDapAn.Controls.Add(txtCtrl, 1, 0);
            tblPanelDapAn.Controls.Add(btnXoa, 2, 0);

            if ((_lstTablePanelDapAn.Count == 0 || _lstTablePanelDapAn.Count % 2 == 0))
            {
                tblPanelMain.Controls.Add(tblPanelDapAn, 0, _rowInsert);
            }
            else
            {
                tblPanelMain.Controls.Add(tblPanelDapAn, 3, _rowInsert);
            }
            _rowInsert = rowIndex == 0 ? _rowInsert : rowIndex;

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
                txtCtrl.Text = UICommon.ConvertRftToText(cauTraLoi.NoiDung);

            }
            // Gán id câu trả lời
            txtCtrl.Tag = cauTraLoi.IdEx;
            btnDapAn.Tag = cauTraLoi.IdEx;
            btnXoa.Tag = cauTraLoi.IdEx;

            ResizeLayoutCauTraLoi(true);
            IsChanged = true;
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
    }
}
