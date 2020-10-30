using DataLayer.BLL;
using DataLayer.DAL;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Controls
{
    public partial class UcTuLuanChum : UserControlBase
    {
        #region Variables
        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameButtonDapAn = "btnDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";
        //color for danApDung
        private Color _colorDapAnDung = Color.Red;
        //BLL
        private ES_SoanCauHoiBLL _business;

        #endregion

        #region Constructor

        public UcTuLuanChum()
        {
            Mode = ModeForm.ThemMoi;
            InitializeCommon();
            //txtNoiDungCauHoiCon.Enabled = txtNoiDungCauTraLoi.Enabled = false;
            Dock = DockStyle.Fill;
            btnTaoCauHoi.Text = "Tạo";
            btnXoaCauHoi.Text = "Xóa";
            btnThem.Text = "Thêm";
        }

        #endregion

        #region Public Method

        public void CauHoiLoad()
        {
            txtNoiDungCauTraLoi.Clear();
            // Neu dang mode cap nhat thi tai noi dung cau hoi len form hien hanh
            if (Mode == ModeForm.CapNhat)
            {
                LoadNoiDungCauHoiCha((int)IdCauHoiCha);
                LoadCauHoiVaCauTraLoi();
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
                cauHoiCha.IsCauHoiCha = true;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                _business.AddNewCauHoi(cauHoiCha);

                foreach (var ch in ListCauHoi)
                {
                    ch.IDCauHoiCha = cauHoiCha.Id;
                    ch.IDLoaiCauHoi = IdLoaiCauHoi;
                    ch.IDChuong = IdDanhMuc;
                    ch.DoKho = IdMucDoNhanThuc;
                    ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                    ch.IsSuDung = true;
                    ch.NgaySoan = DateTime.Now;
                    _business.AddNewCauHoi(ch);
                    foreach (var ctl in ch.ListCauTraLoi)
                    {
                        ctl.IDCauHoi = ch.Id;
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
                cauHoiCha.NoiDung = txtNoiDungCauHoiCha.Rtf;
                cauHoiCha.IDChuong = IdDanhMuc;
                cauHoiCha.IDLoaiCauHoi = IdLoaiCauHoi;
                cauHoiCha.IsCauHoiCha = true;
                cauHoiCha.DoKho = IdMucDoNhanThuc;
                _business.UpdateCauHoi(IdCauHoiCha ?? 0, cauHoiCha);

                #endregion

                #region Update cau hoi

                foreach (var ch in ListCauHoi)
                {
                    ch.IDCauHoiCha = IdCauHoiCha;
                    ch.IDLoaiCauHoi = IdLoaiCauHoi;
                    ch.IDChuong = IdDanhMuc;
                    ch.DoKho = IdMucDoNhanThuc;
                    ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                    ch.NgaySoan = DateTime.Now;
                    _business.UpdateCauHoi(ch.Id, ch);
                    foreach (var ctl in ch.ListCauTraLoi)
                    {
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

            if (txtNoiDungCauHoiCha.IsEmpty)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi cha.");
                return false;
            }

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
            }
            return true;
        }

        #endregion

        #region Private Methods

        private void InitializeData()
        {
            //BLL
            _business = new ES_SoanCauHoiBLL();
        }

        private void InitializeCommon()
        {
            InitializeComponent();
            InitializeData();
            AddEvent();
        }

        private void AddEvent()
        {
            txtNoiDungCauHoiCha.GotFocus += txtNoiDungCauHoiCha_GotFocus;
            txtNoiDungCauHoiCon.GotFocus += txtNoiDungCauHoiCha_GotFocus;
            txtNoiDungCauTraLoi.GotFocus += txtNoiDungCauHoiCha_GotFocus;

            txtNoiDungCauHoiCha.KeyDown += new KeyEventHandler(UcEditor_KeyDown);
            txtNoiDungCauHoiCon.KeyDown += new KeyEventHandler(UcEditor_KeyDown);
            txtNoiDungCauTraLoi.KeyDown += new KeyEventHandler(UcEditor_KeyDown);

            btnTaoCauHoi.Click += BtnTaoSoCauHoi_Click;
            btnXoaCauHoi.Click += BtnXoaCauHoi_Click;
            btnThem.Click += BtnThem_Click;
            cboChonCauHoi.EditValueChanged += CboChonCauHoi_EditValueChanged;
        }

        private string HtmlToText(string htmlString)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return reg.Replace(htmlString, "");
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

        private void LoadNoiDungCauHoiCha(int idCauHoiCha)
        {
            //Chuyen id cau hoi va idcau tra li ve dang IDEx từ 1 đến... để xủ lý chung
            if (IdCauHoiCha > 0)
            {
                var cauHoiCha = _business.GetById(IdCauHoiCha);
                if (cauHoiCha != null)
                {
                    txtNoiDungCauHoiCha.Rtf = cauHoiCha.NoiDung;
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
                            ctl.IdEx = j++;
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

        private void SetDataChonCauHoi(List<DM_STT> lstDataCbo)
        {
            var lstItem = new List<LookUpEditItem>();
            lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
            lstItem.Add(new LookUpEditItem { ColumnName = "Ten", ColumnCaption = "Tên" });
            cboChonCauHoi.SetData(lstDataCbo, lstItem, "Ten", "Id");
        }

        private void LoadCauHoiVaCauTraLoi()
        {
            EX_CauHoi cauHoi = _business.GetById(CauHoiCurent.Id);
            if (cauHoi != null)
            {
                txtNoiDungCauHoiCon.Rtf = cauHoi.NoiDung;
                ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
                //Load noi dung cau tra loi
                var cauTraLoi = CauHoiCurent.ListCauTraLoi.FirstOrDefault();
                //noi dung cau tra loi
                txtNoiDungCauTraLoi.Rtf = cauTraLoi.NoiDung;
            }
        }

        private void LoadCauHoiNew(int idCauHoi)
        {
            EX_CauHoi cauHoi = new EX_CauHoi();
            cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == idCauHoi);
            IdCauHoiCurent = cauHoi.IDEx;
            txtNoiDungCauHoiCon.Rtf = cauHoi.NoiDung;
            ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
            LoadCauTraLoiNew(IdCauHoiCurent);
        }

        private void LoadCauTraLoiNew(long idCauHoi)
        {
            // Load danh sách đáp án
            var lstDapAn = ListCauHoi.Where(m => m.IDEx == idCauHoi).Select(m => m.ListCauTraLoi).FirstOrDefault();
            if (lstDapAn != null && lstDapAn.Count > 0)
            {
                var cautraLoi = lstDapAn.FirstOrDefault();
                txtNoiDungCauTraLoi.Rtf = cautraLoi.NoiDung;
            }
        }

        private bool SaveNewCauHoiTemp(long idCauHoiEx)
        {

            #region Save new câu hỏi
            //Cau hoi cha
            EX_CauHoi cauHoi = ListCauHoi.FirstOrDefault(m => m.IDEx == IdCauHoiCurent);
            cauHoi.IDChuong = IdDanhMuc;
            cauHoi.DoKho = IdMucDoNhanThuc;
            cauHoi.NoiDung = txtNoiDungCauHoiCon.Rtf;
            cauHoi.IsSuDung = true;
            cauHoi.IsKhongDao = ckbKhongDaoCauHoi.Checked;
            cauHoi.NgaySoan = DateTime.Now;

            var cauTraLoi = cauHoi.ListCauTraLoi.FirstOrDefault();
            cauTraLoi.NoiDung = txtNoiDungCauTraLoi.Rtf;

            #endregion

            return true;
        }

        private void SetReadOnlyControl(bool isReadOnly)
        {
            txtNoiDungCauHoiCon.Enabled = txtNoiDungCauTraLoi.Enabled = !isReadOnly;
            ckbKhongDaoCauHoi.Enabled = !isReadOnly;
            txtSoCauHoi.ReadOnly = !isReadOnly;
        }

        #endregion

        #region Events

        private void txtNoiDungCauHoiCha_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        private void UcEditor_KeyDown(object sender, KeyEventArgs e)
        {
            EditorControl UcEditor = sender as EditorControl;
            if (UcEditor.Name == "txtNoiDungCauHoiCon" || UcEditor.Name == "txtCtrlDapAn")
            {
                if (ListCauHoi == null || ListCauHoi.Count == 0 || !cboChonCauHoi.CategoryID.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa tạo số lượng câu hỏi");
                    UcEditor.Text = "";
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
            if (ListCauHoi != null && UICommon.ShowMsgQuestionString("Tạo mới danh sách câu hỏi toàn bộ dữ liệu câu hỏi bạn chưa lưu sẽ bị mất.\nBạn có muốn tiếp tục không?") != DialogResult.Yes)
                return;
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
                //Khởi tạo cau tra loi => cau hoi tu luan chi mot cau tra loi
                EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.IdEx = 1;
                cauTraLoi.IDCauHoi = cauHoi.Id;
                cauTraLoi.NoiDung = "";
                cauHoi.ListCauTraLoi.Add(cauTraLoi);

                ListCauHoi.Add(cauHoi);
                dataCboCauHoi.Add(new DM_STT { Id = cauHoi.IDEx, Ten = string.Format("Câu hỏi {0}", i) });
            }
            //Set data cauHoi vào trong cbo
            SetDataChonCauHoi(dataCboCauHoi);
            if (dataCboCauHoi.Count > 0)
            {
                IdCauHoiCurent = 0;
                cboChonCauHoi.CategoryID = 1;
            }
            SetReadOnlyControl(false);
            btnTaoCauHoi.Enabled = false;
        }

        private void CboChonCauHoi_OnChangedCategoryID(int? categoryID)
        {
            if (cboChonCauHoi.CategoryID.HasValue)
            {
                if (IdCauHoiCurent > 0)
                {
                    SaveNewCauHoiTemp(IdCauHoiCurent);
                }
                txtNoiDungCauTraLoi.Clear();
                LoadCauHoiNew((int)cboChonCauHoi.CategoryID);
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
                txtNoiDungCauTraLoi.Clear();
                LoadCauHoiNew((int)cboChonCauHoi.CategoryID);
            }
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
                    IsChanged = _business.DeleteCauHoiByLstId(new List<long>() { cauHoi.Id }) > 0;

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
            var cauHoiLast = ListCauHoi.LastOrDefault();
            if (cauHoiLast != null)
            {
                cauHoi.IDEx = cauHoiLast.IDEx + 1;
                cauHoi.IDChuong = IdDanhMuc;
                cauHoi.DoKho = IdMucDoNhanThuc;
                cauHoi.IsSuDung = true;
                cauHoi.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                //Cau tra loi
                EX_CauTraLoi cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.IdEx = 1;
                cauTraLoi.IDCauHoi = cauHoi.Id;
                cauHoi.ListCauTraLoi.Add(cauTraLoi);
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

        #endregion        
    }
}
