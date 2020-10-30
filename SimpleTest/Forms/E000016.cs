using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    /// Thêm đề thi thủ công
    /// </summary>
    public partial class E000016 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();
        private CauHoiBll _busCauHoi = new CauHoiBll();
        private EX_DanhMuc _currentNode;
        private EX_CauHoi _currentCauHoi;
        private bool _firstLoad;
        private List<EX_CauHoi> _lstCauHoiSelect = new List<EX_CauHoi>();
        private bool _isChangeNode = false;
        #endregion

        #region Constructor

        public E000016()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            #region Tsb

            Group.ItemLinks.Remove(TsbThem);
            Group.ItemLinks.Remove(TsbSua);
            Group.ItemLinks.Remove(TsbXoa);

            TsbTimKiem.Caption = "Tìm kiếm câu hỏi";
            TsbTimKiem.ItemClick += TsbTimKiem_ItemClick;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnLocCauHoi.Click += BtnLocCauHoi_Click;
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
                _isChangeNode = false;
                BeginInvoke(new MethodInvoker(() =>
                {
                    treeList1.FocusedNode = selected_node;

                }));
                // Hạn chế tìm lại dữ liệu
                if (!_isChangeNode) SearchDataGrid(idDanhMuc, cboLoaiCauHoi.CategoryID, cboMucDoNhanThuc.CategoryID);
            }
        }

        private void SearchDataGrid(long idCauHoi, long? idLoaiCauHoi, long? idMucDoNhanThuc)
        {
            gridControl1.DataSource = new List<EX_CauHoi>();
            var data = _busCauHoi.GetDanhSachCauHoi(idCauHoi, idLoaiCauHoi, idMucDoNhanThuc);
            // Loc lai nhung cau hoi da chon
            data = data.Where(m => !_lstCauHoiSelect.Select(o => o.Id).Contains(m.Id)).ToList();
            gridControl1.DataSource = data;
            gridControl1.Refresh();
        }

        private List<EX_CauHoi> GetCheckRow(GridView gridView)
        {
            var lstData = new List<EX_CauHoi>();
            if (gridView != null)
            {
                int[] rowHandles = gridView.GetSelectedRows();
                if (rowHandles == null || rowHandles.Length == 0) return new List<EX_CauHoi>();
                foreach (int rowHandle in rowHandles)
                {
                    var item = gridView.GetRow(rowHandle) as EX_CauHoi;
                    if (item != null)
                    {
                        lstData.Add(item);
                    }
                }
            }
            return lstData;
        }

        #endregion

        #region Event

        #region Treelist

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_firstLoad)
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            _currentNode = treeList1.GetDataRecordByNode(e.Node) as EX_DanhMuc;
            if (_currentNode != null)
            {
                SearchDataGrid(_currentNode.Id, cboLoaiCauHoi.CategoryID, cboMucDoNhanThuc.CategoryID);
                _isChangeNode = true;
            }
            if (_firstLoad)
                SplashScreenManager.CloseForm(false);
            _firstLoad = true;
        }

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

        private void TsbTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchDataTree();
        }

        #endregion

        #region Button

        private void BtnLocCauHoi_Click(object sender, EventArgs e)
        {
            SearchDataTree();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var lstCheck = GetCheckRow(gridView2);
            if (lstCheck.Count > 0)
            {
                _lstCauHoiSelect = _lstCauHoiSelect.Where(m => !lstCheck.Select(o => o.Id).Contains(m.Id)).ToList();
                gridControlRight.DataSource = _lstCauHoiSelect;
                gridControlRight.Refresh();

                TsbTimKiem.PerformClick();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var lstCheck = GetCheckRow(gridView1);
            if (lstCheck.Count > 0)
            {
                lstCheck = lstCheck.Where(m => !_lstCauHoiSelect.Select(o => o.Id).Contains(m.Id)).ToList();
                _lstCauHoiSelect = _lstCauHoiSelect.Concat(lstCheck).ToList();
                gridControlRight.DataSource = _lstCauHoiSelect;
                gridControlRight.Refresh();

                TsbTimKiem.PerformClick();
            }
        }

        #endregion

        #endregion
    }
}
