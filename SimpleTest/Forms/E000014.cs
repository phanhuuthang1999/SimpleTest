using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Localization;
using SimpleTest.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Forms
{
    /// <summary>
    /// Danh sách câu hỏi
    /// </summary>
    public partial class E000014 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();
        private CauHoiBll _busCauHoi = new CauHoiBll();
        private EX_DanhMuc _currentNode;
        private EX_CauHoi _currentCauHoi;
        private bool _firstLoad;
        #endregion

        #region Constructor

        public E000014()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            #region Tsb

            TsbTimKiem.Caption = "Tìm kiếm";
            TsbThem.Caption = "Thêm câu hỏi";
            TsbSua.Caption = "Sửa câu hỏi";
            TsbXoa.Caption = "Xóa câu hỏi";

            TsbTimKiem.ItemClick += TsbTimKiem_ItemClick;
            TsbThem.ItemClick += TsbThem_ItemClick;
            TsbSua.ItemClick += TsbSua_ItemClick;
            TsbXoa.ItemClick += TsbXoa_ItemClick;

            #endregion

            #region Cbo

            DataCommon.LoadDataDoKho(cboMucDoNhanThuc);
            DataCommon.LoadDataLoaiCauHoi(cboLoaiCauHoi);

            #endregion

            #region TreeList

            treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;

            SearchDataTree();

            treeList1.GetSelectImage += TreeList1_GetSelectImage;
            treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
            treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;

            treeList1.Columns["TenDanhMuc"].SortMode = ColumnSortMode.Custom;
            treeList1.CustomColumnSort += TreeList1_CustomColumnSort;


            #endregion

            #region Grid

            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;

            #endregion
        }

        private void SearchDataTree()
        {
            long idDanhMuc = 0;
            if (_currentNode != null) idDanhMuc = _currentNode.Id;
            var data = _bus.GetDanhMucCountSoLuongCauHoi(cboLoaiCauHoi.CategoryID, cboMucDoNhanThuc.CategoryID);
            treeList1.DataSource = data;
            treeList1.Refresh();
            treeList1.ExpandAll();

            //Focus tree
            var selected_node = treeList1.FindNodeByFieldValue("Id", idDanhMuc);
            if (selected_node != null)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    treeList1.FocusedNode = selected_node;
                }));
            }
        }

        private List<EX_CauHoi> GetCheckRow()
        {
            var lstData = new List<EX_CauHoi>();
            int[] rowHandles = this.gridView1.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0) return new List<EX_CauHoi>();
            foreach (int rowHandle in rowHandles)
            {
                var item = gridView1.GetRow(rowHandle) as EX_CauHoi;
                if (item != null)
                {
                    lstData.Add(item);
                }
            }
            return lstData;
        }

        private void LoadCauHoi(EX_CauHoi pCauHoi)
        {
            if (dockPanel2.CanFocus)
            {
                if (_firstLoad)
                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                if (pCauHoi != null)
                {
                    ucDisplayCauHoi1.LoadCauhoi(ConvertForDisplays.HienThiCauHoi((int)pCauHoi.Id), true, ucDisplayCauHoi1.Width, pCauHoi.STT);
                }
                else
                {
                    ucDisplayCauHoi1.Clear();
                }
                if (_firstLoad)
                    SplashScreenManager.CloseForm(false);
            }
        }

        #endregion

        #region Event

        #region Treelist

        private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            foreach (DXMenuItem item in e.Menu.Items)
            {
                string caption = TreeListLocalizer.Active.GetLocalizedString(TreeListStringId.MenuColumnColumnCustomization);
                if (item.Caption == caption)
                {
                    item.Visible = false;
                }
            }
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_firstLoad)
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            _currentNode = treeList1.GetDataRecordByNode(e.Node) as EX_DanhMuc;
            if (_currentNode != null)
            {
                gridControl1.DataSource = new List<EX_CauHoi>();
                gridControl1.DataSource = _busCauHoi.GetDanhSachCauHoi(_currentNode.Id, cboLoaiCauHoi.CategoryID, cboMucDoNhanThuc.CategoryID);
                gridControl1.Refresh();
            }
            if (_firstLoad)
                SplashScreenManager.CloseForm(false);
            _firstLoad = true;
        }

        private void TreeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            switch (e.Node.Level)
            {
                case 0:
                    e.NodeImageIndex = 0;
                    break;
                case 1:
                    e.NodeImageIndex = 1;
                    break;
                case 2:
                    e.NodeImageIndex = 2;
                    break;
                case 3:
                    e.NodeImageIndex = 3;
                    break;
                case 4:
                    e.NodeImageIndex = 4;
                    break;
                default:
                    e.NodeImageIndex = 5;
                    break;
            }
        }

        private void TreeList1_CustomColumnSort(object sender, DevExpress.XtraTreeList.CustomColumnSortEventArgs e)
        {
            if (e.Column.FieldName == "TenDanhMuc")
            {
                object val1 = e.Node1["STT"];
                object val2 = e.Node2["STT"];
                e.Result = Comparer.Default.Compare(val1, val2);
            }
        }

        #endregion       

        #region Tsb

        private void TsbXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var lstCheck = GetCheckRow();
            if (lstCheck.Count == 0)
            {
                UICommon.ShowMsgInfoString("Bạn chưa chọn câu hỏi cần xóa!");
                return;
            }

            var lstIdCauHoi = lstCheck.Select(m => m.Id).ToList();
            // Check câu hỏi đang sử dụng
            var lstCauHoiSuDung = _busCauHoi.CheckCauHoiDangDuocSuDung(lstIdCauHoi);
            if (lstCauHoiSuDung.Count > 0)
            {
                if (UICommon.ShowMsgQuestionString("Tồn tại câu hỏi đang được sử dụng. Bạn có muốn tiếp tục không?") != DialogResult.Yes) return;
            }
            else
            {
                if (UICommon.ShowMsgQuestionString("Bạn muốn xóa danh sách câu hỏi đang chọn?") != DialogResult.Yes) return;
            }

            if (_busCauHoi.XoaAllCauHoi(lstIdCauHoi) > 0)
            {
                TsbTimKiem.PerformClick();
            }
        }

        private void TsbSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentCauHoi = gridView1.GetFocusedRow() as EX_CauHoi;
            if (_currentCauHoi != null)
            {
                E000012 frm = new E000012();
                if (_currentCauHoi.IsCauHoiCha ?? false)
                {
                    frm.IsCauHoiCha = true;
                    frm.IdCauHoiCha = _currentCauHoi.Id;
                    frm.Mode = ModeForm.CapNhat;
                    frm.ShowDialog();
                }
                else
                {
                    frm.IdCauHoi = _currentCauHoi.Id;
                    frm.CurentCauHoi = _currentCauHoi;
                    frm.Mode = ModeForm.CapNhat;
                    frm.ShowDialog();
                }
            }
        }

        private void TsbThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            var frmCauHoi = new E000012();
            frmCauHoi.IdDanhMuc = _currentNode?.Id;
            frmCauHoi.ShowDialog();
            if (frmCauHoi != null)
            {
                frmCauHoi.Dispose();
            }
            SplashScreenManager.CloseForm(false);
        }

        private void TsbTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchDataTree();
            gridControl1.DataSource = new List<EX_CauHoi>();
            gridControl1.Refresh();
        }

        #endregion

        #region Grid

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _currentCauHoi = gridView1.GetFocusedRow() as EX_CauHoi;
            if (_currentCauHoi != null)
            {
                LoadCauHoi(_currentCauHoi);
            }
        }        

        #endregion

        #endregion
    }
}
