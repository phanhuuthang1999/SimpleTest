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
using SimpleTest.Controls;
using DataLayer.BLL;
using DevExpress.XtraSplashScreen;
using DataLayer.DAL;
using SimpleTest.Common;

namespace SimpleTest.Forms
{
    /// <summary>
    /// Danh mục đơn vị kiến thức
    /// </summary>
    public partial class E000007 : FormBase
    {
        #region Variable

        private DanhMucBll _business;
        private ToolStriptButton tsbSaoChep;

        #endregion

        #region Constructor

        public E000007()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            _business = new DanhMucBll();

            tsbSaoChep = new ToolStriptButton();
            tsbSaoChep.Name = "tsbSaoChep";
            tsbSaoChep.Type = Common.StructEnum.Enum_ToolstripButtonType.SaoChep;
            tsbSaoChep.Caption = "Sao chép đơn vị kiến thức";
            Group.ItemLinks.Insert(4, tsbSaoChep);

            TsbTimKiem.Caption = "Tìm kiếm đơn vị kiến thức";
            TsbThem.Caption = "Thêm đơn vị kiến thức";
            TsbSua.Caption = "Sửa đơn vị kiến thức";
            TsbXoa.Caption = "Xóa đơn vị kiến thức";

            TsbTimKiem.ItemClick += TsbTimKiem_ItemClick;
            TsbThem.ItemClick += TsbThem_ItemClick;
            TsbSua.ItemClick += TsbSua_ItemClick;
            TsbXoa.ItemClick += TsbXoa_ItemClick;
            tsbSaoChep.ItemClick += TsbSaoChep_ItemClick;

            cboKhoiLop.EditValueChanged += CboKhoiLop_EditValueChanged;
            cboMonHoc.EditValueChanged += CboMonHoc_EditValueChanged;

            DataCommon.LoadDataCboKhoiLop(cboKhoiLop);
            DataCommon.LoadDataCboMonHoc(cboMonHoc, null);
            DataCommon.LoadDataCboPhan(cboPhan, null, null);

        }        

        private List<EX_DanhMuc> GetCheckRow()
        {
            var lstData = new List<EX_DanhMuc>();
            int[] rowHandles = this.gridChuong.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0) return new List<EX_DanhMuc>();
            foreach (int rowHandle in rowHandles)
            {
                var item = gridChuong.GetRow(rowHandle) as EX_DanhMuc;
                if (item != null)
                {
                    lstData.Add(item);
                }
            }
            return lstData;
        }

        #endregion

        #region Event

        private void TsbTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            var data = _business.GetDanhSachChuong(cboKhoiLop.CategoryID, cboMonHoc.CategoryID, cboPhan.CategoryID, null, txtMaChuong.Text, txtTenChuong.Text);
            gridControl1.DataSource = data;
            SplashScreenManager.CloseForm(false);
        }

        private void TsbSaoChep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rc = gridChuong.GetFocusedRow() as EX_DanhMuc;
            if (rc != null)
            {
                E000008 frm = new E000008();
                var kl = (EX_DanhMuc)UICommon.CloneObject(rc);
                kl.Id = 0;
                frm.CurrentObj = kl;
                frm.ShowDialog();
                TsbTimKiem.PerformClick();
            }
        }

        private void TsbXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lstCheck = GetCheckRow();
            if (lstCheck.Count > 0)
            {
                if (UICommon.ShowMsgQuestionString("Bạn muốn xóa đơn vị kiến thức?") == DialogResult.Yes)
                {
                    if (_business.DeleteDanhMucCurrent(lstCheck.Select(m => m.Id).ToList()) > 0)
                    {
                        UICommon.ShowMsgUpdateSuccess();
                        TsbTimKiem.PerformClick();
                    }
                }
            }
            else
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn đơn vị kiến thức!");
            }
        }

        private void TsbSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rc = gridChuong.GetFocusedRow() as EX_DanhMuc;
            if (rc != null)
            {
                E000008 frm = new E000008();
                frm.CurrentObj = rc;
                frm.ShowDialog();
                TsbTimKiem.PerformClick();
            }
        }

        private void TsbThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            E000008 frm = new E000008();
            frm.ShowDialog();
            TsbTimKiem.PerformClick();
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
    }
}