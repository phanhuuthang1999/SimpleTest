using DataLayer.BLL;
using DataLayer.DAL;
using SimpleTest.Common;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Controls
{
    public partial class UcTuLuanDon : UserControlBase
    {
        #region Variables

        private const string _nameTablePanelDapAn = "tblPanelDapAn";
        private const string _nameButtonDapAn = "btnDapAn";
        private const string _nameButtonXoa = "btnXoa";
        private const string _nameTextNoiDungDapAn = "txtCtrlDapAn";
        private const string _nameCheckBox = "chkKhongDao";
        private Color _colorDapAnDung = Color.Red;

        private ES_SoanCauHoiBLL _business;

        #endregion

        #region Constructor

        public UcTuLuanDon()
        {
            Mode = ModeForm.ThemMoi;
            InitializeCommon();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region Public Method

        public void CauHoiLoad()
        {
            //Phan nay ap dung khi upadate
            if (Mode == ModeForm.CapNhat)
            {
                var cauHoi = _business.GetById(IdCauHoiCurent);
                if (cauHoi != null)
                {
                    ckbKhongDaoCauHoi.Checked = cauHoi.IsKhongDao ?? false;
                    txtNoiDungCauHoi.Rtf = cauHoi.NoiDung;
                    //Load cau tra loi => loai cau hoi tu luan chỉ có một câu trả lời                
                    var lstCauTraLoi = _business.GetCauTraLoi(cauHoi.Id);
                    if (lstCauTraLoi.Count > 0)
                    {
                        var cauTraLoi = lstCauTraLoi.FirstOrDefault();
                        //Set lai id len bien toan cuc
                        IdCauTraLoi = cauTraLoi.Id;
                        txtNoiDungCauTraLoi.Rtf = cauTraLoi.NoiDung;
                    }
                }
            }
        }

        public bool SaveNewCauHoi()
        {
            try
            {
                var ch = new EX_CauHoi();
                ch.NoiDung = txtNoiDungCauHoi.Rtf;
                ch.IDChuong = IdDanhMuc;
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                ch.NgaySoan = DateTime.Now;
                ch.DoKho = IdMucDoNhanThuc;
                ch.IsSuDung = true;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                _business.AddNewCauHoi(ch);

                var cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.NoiDung = txtNoiDungCauTraLoi.Rtf;
                cauTraLoi.IDCauHoi = ch.Id;
                cauTraLoi.IsKhongDao = true;
                cauTraLoi.NgayTao = DateTime.Now;
                _business.AddNewCauTraLoi(cauTraLoi);
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
                var ch = new EX_CauHoi();
                ch.NoiDung = txtNoiDungCauHoi.Rtf;
                ch.IDChuong = IdDanhMuc;
                ch.IDLoaiCauHoi = IdLoaiCauHoi;
                ch.NgaySoan = DateTime.Now;
                ch.DoKho = IdMucDoNhanThuc;
                ch.IsKhongDao = ckbKhongDaoCauHoi.Checked;
                ch.IsSuDung = true;
                _business.UpdateCauHoi(IdCauHoiCurent, ch);

                var cauTraLoi = new EX_CauTraLoi();
                cauTraLoi.NoiDung = txtNoiDungCauTraLoi.Rtf;
                cauTraLoi.IDCauHoi = IdCauHoiCurent;
                cauTraLoi.IsKhongDao = true;
                cauTraLoi.NgayTao = DateTime.Now;
                _business.UpdateCauTraLoi(IdCauTraLoi, cauTraLoi);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool ValidateNoiDung()
        {
            if (txtNoiDungCauHoi.IsEmpty)
            {
                UICommon.ShowMsgWarningString("Bạn hãy nhập nội dung câu hỏi.");
                return false;
            }
            return true;
        }

        #endregion

        #region Private Methods

        private void InitializeData()
        {
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
            txtNoiDungCauHoi.GotFocus += txtNoiDungCauHoi_GotFocus;
            txtNoiDungCauTraLoi.GotFocus += txtNoiDungCauHoi_GotFocus;
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

        #endregion

        #region Events

        private void txtNoiDungCauHoi_GotFocus(object sender, EventArgs e)
        {
            CurrentControl = sender as EditorControl;
        }

        #endregion
    }
}
