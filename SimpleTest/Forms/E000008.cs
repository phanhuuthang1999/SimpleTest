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
    /// Thêm, sửa, xóa đơn vị kiến thức
    /// </summary>
    public partial class E000008 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();

        #endregion

        #region Constructor

        public E000008()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cboKhoiLop.EditValueChanged += CboKhoiLop_EditValueChanged;
            cboMonHoc.EditValueChanged += CboMonHoc_EditValueChanged;
            DataCommon.LoadDataCboKhoiLop(cboKhoiLop);
            DataCommon.LoadDataCboMonHoc(cboMonHoc, null);
            DataCommon.LoadDataCboPhan(cboPhan, null, null);
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
                    formText = "SAO CHÉP ĐƠN VỊ KIẾN THỨC";
                }
                else
                {
                    formText = "CẬP NHẬT ĐƠN VỊ KIẾN THỨC";
                }
            }
            else
            {
                formText = "THÊM ĐƠN VỊ KIẾN THỨC";
                CurrentObj = new EX_DanhMuc();
            }

            this.Text = formText;
            txtMaChuong.Focus();
        }

        #endregion

        #region Private

        private void SetData()
        {
            if (CurrentObj == null)
            {
                return;
            }
            if (CurrentObj.IDDanhMucCha.HasValue)
            {
                var phan = _bus.Context.EX_DanhMuc.FirstOrDefault(m => m.Id == CurrentObj.IDDanhMucCha);
                if (phan != null)
                {
                    cboPhan.CategoryID = phan.Id;
                    var mh = _bus.Context.EX_DanhMuc.FirstOrDefault(m => m.Id == phan.IDDanhMucCha);
                    cboMonHoc.CategoryID = mh.Id;
                    cboKhoiLop.CategoryID = mh.IDDanhMucCha;
                }
            }
            cboPhan.CategoryID = CurrentObj.IDDanhMucCha;
            txtStt.Text = CurrentObj.STT.ToString();
            txtMaChuong.Text = CurrentObj.MaDanhMuc;
            txtTenChuong.Text = CurrentObj.TenDanhMuc;
            txtGhiChu.Text = CurrentObj.GhiChu;

            if (CurrentObj.Id == 0)
            {
                return;
            }
        }

        private bool GetData()
        {
            #region Check data

            if (cboMonHoc.CategoryID == null && cboPhan.CategoryID == null)
            {
                UICommon.ShowMsgInfoString("Bạn phải chọn môn học hoặc nội dung kiến thức");
                if (cboMonHoc.CategoryID == null) cboMonHoc.Focus();
                else cboPhan.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaChuong.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập mã đơn vị kiến thức");
                txtMaChuong.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenChuong.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập tên đơn vị kiến thức");
                txtTenChuong.Focus();
                return false;
            }


            // Check exist
            if (_bus.IsDanhMucExist(txtMaChuong.Text.Trim(), CurrentObj == null ? 0 : CurrentObj.Id, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.DonViKienThuc))
            {
                UICommon.ShowMsgInfoString("Mã đơn vị kiến thức đã tồn tại");
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
            CurrentObj.IDDanhMucCha = cboPhan.CategoryID;
            CurrentObj.MaDanhMuc = txtMaChuong.Text;
            CurrentObj.TenDanhMuc = txtTenChuong.Text;
            CurrentObj.STT = stt;
            CurrentObj.GhiChu = txtGhiChu.Text;
            return true;
        }

        private int UpdateData()
        {
            if (GetData())
            {
                int res = _bus.UpdateDanhMuc(CurrentObj, DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc.DonViKienThuc);
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
            DataCommon.LoadDataCboPhan(cboPhan, cboKhoiLop.CategoryID, cboMonHoc.CategoryID);
        }

        private void CboMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            DataCommon.LoadDataCboPhan(cboPhan, cboKhoiLop.CategoryID, cboMonHoc.CategoryID);
        }

        #endregion

        #region Properties

        public EX_DanhMuc CurrentObj { get; set; }

        #endregion
    }
}