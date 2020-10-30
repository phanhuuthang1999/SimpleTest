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
    /// Thêm, sửa, xóa môn học
    /// </summary>
    public partial class E000004 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();

        #endregion

        #region Constructor

        public E000004()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            DataCommon.LoadDataCboKhoiLop(cboKhoiLop);
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
                    formText = "SAO CHÉP MÔN HỌC";
                }
                else
                {
                    formText = "CẬP NHẬT MÔN HỌC";
                }
            }
            else
            {
                formText = "THÊM MÔN HỌC";
                CurrentObj = new EX_DanhMuc();
            }

            this.Text = formText;
            txtMaMonHoc.Focus();
        }

        #endregion

        #region Private

        private void SetData()
        {
            if (CurrentObj == null)
            {
                return;
            }
            cboKhoiLop.CategoryID = CurrentObj.IDDanhMucCha;
            txtStt.Text = CurrentObj.STT.ToString();
            txtMaMonHoc.Text = CurrentObj.MaDanhMuc;
            txtTenMonHoc.Text = CurrentObj.TenDanhMuc;
            txtGhiChu.Text = CurrentObj.GhiChu;

            if (CurrentObj.Id == 0)
            {
                return;
            }
        }

        private bool GetData()
        {
            #region Check data

            if (cboKhoiLop.CategoryID == null)
            {
                UICommon.ShowMsgInfoString("Bạn chưa chọn khối lớp");
                cboKhoiLop.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaMonHoc.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập mã môn học");
                txtMaMonHoc.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenMonHoc.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập tên môn học");
                txtTenMonHoc.Focus();
                return false;
            }
            

            // Check exist
            if (_bus.IsDanhMucExist(txtMaMonHoc.Text.Trim(), CurrentObj == null ? 0 : CurrentObj.Id, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.MonHoc))
            {
                UICommon.ShowMsgInfoString("Mã môn học đã tồn tại");
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
            CurrentObj.IDDanhMucCha = cboKhoiLop.CategoryID;
            CurrentObj.MaDanhMuc = txtMaMonHoc.Text;
            CurrentObj.TenDanhMuc = txtTenMonHoc.Text;
            CurrentObj.STT = stt;
            CurrentObj.GhiChu = txtGhiChu.Text;
            return true;
        }

        private int UpdateData()
        {
            if (GetData())
            {
                int res = _bus.UpdateDanhMuc(CurrentObj, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.MonHoc);
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

        #endregion

        #region Properties

        public EX_DanhMuc CurrentObj { get; set; }

        #endregion
    }
}