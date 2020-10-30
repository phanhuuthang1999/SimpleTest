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
    /// Thêm, sửa, xóa danh mục
    /// </summary>
    public partial class E000011 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();
        private long _idDanhMucCha;
        private int? _idLoaiDanhMuc;

        #endregion

        #region Constructor

        public E000011(long idDanhMucCha, int? idLoaiDanhMuc)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _idDanhMucCha = idDanhMucCha;
            _idLoaiDanhMuc = idLoaiDanhMuc;
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
                    formText = "SAO CHÉP DANH MỤC";
                }
                else
                {
                    formText = "CẬP NHẬT DANH MỤC";
                }
            }
            else
            {
                formText = "THÊM DANH MỤC";
                CurrentObj = new EX_DanhMuc();
            }

            this.Text = formText;
            txtMaDanhMuc.Focus();
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
            txtMaDanhMuc.Text = CurrentObj.MaDanhMuc;
            txtTenDanhMuc.Text = CurrentObj.TenDanhMuc;
            txtGhiChu.Text = CurrentObj.GhiChu;

            if (CurrentObj.Id == 0)
            {
                return;
            }
        }

        private bool GetData()
        {
            #region Check data

            if (string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập mã danh mục");
                txtMaDanhMuc.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenDanhMuc.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập tên danh mục");
                txtTenDanhMuc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStt.Text))
            {
                UICommon.ShowMsgInfoString("Bạn chưa nhập STT");
                txtStt.Focus();
                return false;
            }

            // Check exist
            if (_bus.IsDanhMucExist(txtMaDanhMuc.Text.Trim(), CurrentObj == null ? 0 : CurrentObj.Id, _idDanhMucCha))
            {
                UICommon.ShowMsgInfoString("Mã danh mục đã tồn tại");
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
            CurrentObj.MaDanhMuc = txtMaDanhMuc.Text;
            CurrentObj.TenDanhMuc = txtTenDanhMuc.Text;
            CurrentObj.IDDanhMucCha = _idDanhMucCha;
            CurrentObj.IDLoaiDanhMuc = _idLoaiDanhMuc;
            CurrentObj.STT = stt;
            CurrentObj.GhiChu = txtGhiChu.Text;
            return true;
        }

        private int UpdateData()
        {
            if (GetData())
            {
                int res = _bus.UpdateDanhMuc(CurrentObj, (DataLayer.Common.LayerCommon.Enum_LoaiDanhMuc)_idLoaiDanhMuc);
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
                this.DialogResult = DialogResult.OK;
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