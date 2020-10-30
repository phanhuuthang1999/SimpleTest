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
    /// Danh mục nội dung kiến thức
    /// </summary>
    public partial class E000005 : FormBase
    {
        #region Variable

        private DanhMucBll _business;
        private ToolStriptButton tsbSaoChep;

        #endregion

        #region Constructor

        public E000005()
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
            tsbSaoChep.Caption = "Sao chép nội dung kiến thức";
            Group.ItemLinks.Insert(4, tsbSaoChep);

            TsbTimKiem.Caption = "Tìm kiếm nội dung kiến thức";
            TsbThem.Caption = "Thêm nội dung kiến thức";
            TsbSua.Caption = "Sửa nội dung kiến thức";
            TsbXoa.Caption = "Xóa nội dung kiến thức";

            TsbTimKiem.ItemClick += TsbTimKiem_ItemClick;
            TsbThem.ItemClick += TsbThem_ItemClick;
            TsbSua.ItemClick += TsbSua_ItemClick;
            TsbXoa.ItemClick += TsbXoa_ItemClick;
            tsbSaoChep.ItemClick += TsbSaoChep_ItemClick;

            cboKhoiLop.EditValueChanged += CboKhoiLop_EditValueChanged;

            DataCommon.LoadDataCboKhoiLop(cboKhoiLop);
            DataCommon.LoadDataCboMonHoc(cboMonHoc, null);

        }

        private List<EX_DanhMuc> GetCheckRow()
        {
            var lstData = new List<EX_DanhMuc>();
            int[] rowHandles = this.gridPhan.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0) return new List<EX_DanhMuc>();
            foreach (int rowHandle in rowHandles)
            {
                var item = gridPhan.GetRow(rowHandle) as EX_DanhMuc;
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
            var data = _business.GetDanhSachPhan(cboKhoiLop.CategoryID, cboMonHoc.CategoryID, null, txtMaPhan.Text, txtTenPhan.Text);
            gridControl1.DataSource = data;
            SplashScreenManager.CloseForm(false);
        }

        private void TsbSaoChep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rc = gridPhan.GetFocusedRow() as EX_DanhMuc;
            if (rc != null)
            {
                E000006 frm = new E000006();
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
                if (UICommon.ShowMsgQuestionString("Bạn muốn xóa nội dung kiến thức?") == DialogResult.Yes)
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
                UICommon.ShowMsgWarningString("Bạn chưa chọn nội dung kiến thức!");
            }
        }

        private void TsbSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rc = gridPhan.GetFocusedRow() as EX_DanhMuc;
            if (rc != null)
            {
                E000006 frm = new E000006();
                frm.CurrentObj = rc;
                frm.ShowDialog();
                TsbTimKiem.PerformClick();
            }
        }

        private void TsbThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            E000006 frm = new E000006();
            frm.ShowDialog();
            TsbTimKiem.PerformClick();
        }

        private void CboKhoiLop_EditValueChanged(object sender, EventArgs e)
        {
            DataCommon.LoadDataCboMonHoc(cboMonHoc, cboKhoiLop.CategoryID);
        }

        #endregion
    }
}