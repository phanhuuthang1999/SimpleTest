using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataLayer.DAL;
using DataLayer.BLL;
using SimpleTest.Common;
using DevExpress.XtraEditors.Controls;
using SimpleTest.Controls;

namespace SimpleTest.Forms
{
    /// <summary>
    /// Thêm, sửa, xóa nội dung kiến thức
    /// </summary>
    public partial class E000006 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();

        #endregion

        #region Constructor

        public E000006()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cboKhoiLop.EditValueChanged += CboKhoiLop_EditValueChanged;
            DataCommon.LoadDataCboKhoiLop(cboKhoiLop);
            DataCommon.LoadDataCboMonHoc(cboMonHoc, null);
        }

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SetData();

            string formText = "";
            if (CurrentObj != null)
            {
                if (CurrentObj.Id == 0)
                {
                    formText = "SAO CHÉP NỘI DUNG KIẾN THỨC";
                }
                else
                {
                    formText = "CẬP NHẬT NỘI DUNG KIẾN THỨC";
                }
            }
            else
            {
                formText = "THÊM NỘI DUNG KIẾN THỨC";
                CurrentObj = new EX_DanhMuc();
            }

            this.Text = formText;
            txtMaPhan.Focus();
        }

        #endregion

        #region Private

        private void SetData()
        {
            if (CurrentObj == null)
            {
                return;
            }
            var mh = _bus.Context.EX_DanhMuc.FirstOrDefault(m => m.Id == CurrentObj.IDDanhMucCha);
            if (mh != null)
                cboKhoiLop.CategoryID = mh.IDDanhMucCha;
            cboMonHoc.CategoryID = CurrentObj.IDDanhMucCha;
            txtStt.Text = CurrentObj.STT.ToString();
            txtMaPhan.Text = CurrentObj.MaDanhMuc;
            txtTenPhan.Text = CurrentObj.TenDanhMuc;
            txtGhiChu.Text = CurrentObj.GhiChu;

            if (CurrentObj.Id == 0)
            {
                return;
            }
        }

        private bool GetData()
        {
            #region Check data

            if (cboMonHoc.CategoryID == null)
            {
                UICommon.ShowMsgInfoString("Bạn chưa chọn môn học");
                cboMonHoc.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaPhan.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập mã nội dung kiến thức");
                txtMaPhan.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenPhan.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập tên nội dung kiến thức");
                txtTenPhan.Focus();
                return false;
            }


            // Check exist
            if (_bus.IsDanhMucExist(txtMaPhan.Text.Trim(), CurrentObj == null ? 0 : CurrentObj.Id, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.NoiDungKienThuc))
            {
                UICommon.ShowMsgInfoString("Mã nội dung kiến thức đã tồn tại");
                return false;
            }

            #endregion

            int? stt = null;
            if (!string.IsNullOrEmpty(txtStt.Text))
            {
                stt = Convert.ToInt32(txtStt.Text);
            }

            if (CurrentObj == null)
            {
                CurrentObj = new EX_DanhMuc();
            }
            CurrentObj.IDDanhMucCha = cboMonHoc.CategoryID;
            CurrentObj.MaDanhMuc = txtMaPhan.Text;
            CurrentObj.TenDanhMuc = txtTenPhan.Text;
            CurrentObj.STT = stt;
            CurrentObj.GhiChu = txtGhiChu.Text;
            return true;
        }

        private int UpdateData()
        {
            if (GetData())
            {
                int res = _bus.UpdateDanhMuc(CurrentObj, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.NoiDungKienThuc);
                if (res > 0)
                {
                    UICommon.ShowMsgUpdateSuccess();
                }
                else
                {
                    UICommon.ShowMsgSplashPanelUnComplete();
                }
                return res;
            }
            return 0;
        }


        #endregion

        #region Event

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (UpdateData() > 0)
            {
                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CboKhoiLop_EditValueChanged(object sender, EventArgs e)
        {
            DataCommon.LoadDataCboMonHoc(cboMonHoc, cboKhoiLop.CategoryID);
        }

        #endregion

        #region Properties

        public EX_DanhMuc CurrentObj { get; set; }

        #endregion
    }
}