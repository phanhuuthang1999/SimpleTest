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

namespace SimpleTest.Forms
{
    /// <summary>
    /// Thêm, sửa, xóa khối lớp
    /// </summary>
    public partial class E000002 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();

        #endregion

        #region Constructor

        public E000002()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
                    formText = "SAO CHÉP KHỐI LỚP";
                }
                else
                {
                    formText = "CẬP NHẬT KHỐI LỚP";
                }
            }
            else
            {
                formText = "THÊM KHỐI LỚP";
                CurrentObj = new EX_DanhMuc();
            }

            this.Text = formText;
            txtMaKhoiLop.Focus();
        }

        #endregion

        #region Private

        private void SetData()
        {
            if (CurrentObj == null)
            {
                return;
            }

            txtStt.Text = CurrentObj.STT.ToString();
            txtMaKhoiLop.Text = CurrentObj.MaDanhMuc;
            txtTenKhoiLop.Text = CurrentObj.TenDanhMuc;
            txtGhiChu.Text = CurrentObj.GhiChu;

            if (CurrentObj.Id == 0)
            {
                return;
            }
        }

        private bool GetData()
        {
            #region Check data

            if (string.IsNullOrEmpty(txtMaKhoiLop.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập mã khối lớp");
                txtMaKhoiLop.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenKhoiLop.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập tên khối lớp");
                txtTenKhoiLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStt.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập STT");
                txtStt.Focus();
                return false;
            }

            // Check exist
            if (_bus.IsDanhMucExist(txtMaKhoiLop.Text.Trim(), CurrentObj == null ? 0 : CurrentObj.Id, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.KhoiLop))
            {
                UICommon.ShowMsgInfoString("Mã khối lớp đã tồn tại");
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
            CurrentObj.MaDanhMuc = txtMaKhoiLop.Text;
            CurrentObj.TenDanhMuc = txtTenKhoiLop.Text;
            CurrentObj.STT = stt;
            CurrentObj.GhiChu = txtGhiChu.Text;
            return true;
        }

        private int UpdateData()
        {
            if (GetData())
            {
                int res = _bus.UpdateDanhMuc(CurrentObj, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.KhoiLop);
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