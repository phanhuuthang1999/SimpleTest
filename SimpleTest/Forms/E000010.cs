using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraTreeList.Nodes;
using SimpleTest.Common;
using SimpleTest.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataLayer.Common.LayerCommon;
using static SimpleTest.Common.StructEnum;

namespace SimpleTest.Forms
{
    /// <summary>
    /// Màn hình danh mục
    /// </summary>
    public partial class E000010 : FormBase
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();
        private ToolStriptButton tsbSaoChep;
        private EX_DanhMuc _currentNode;

        #endregion

        #region Constructor

        public E000010()
        {
            InitializeComponent();
            InitForm();

        }

        #endregion

        #region Private

        private void InitForm()
        {
            _bus = new DanhMucBll();

            tsbSaoChep = new ToolStriptButton();
            tsbSaoChep.Name = "tsbSaoChep";
            tsbSaoChep.Type = Common.StructEnum.Enum_ToolstripButtonType.SaoChep;
            tsbSaoChep.Caption = "Sao chép danh mục";
            Group.ItemLinks.Insert(4, tsbSaoChep);

            Group.ItemLinks.Remove(TsbTimKiem);
            TsbTimKiem.Caption = "Tìm kiếm danh mục";
            TsbThem.Caption = "Thêm danh mục";
            TsbSua.Caption = "Sửa danh mục";
            TsbXoa.Caption = "Xóa danh mục";

            TsbTimKiem.ItemClick += TsbTimKiem_ItemClick;
            TsbThem.ItemClick += TsbThem_ItemClick;
            TsbSua.ItemClick += TsbSua_ItemClick;
            TsbXoa.ItemClick += TsbXoa_ItemClick;
            tsbSaoChep.ItemClick += TsbSaoChep_ItemClick;

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
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            long idDanhMuc = 0;
            if (_currentNode != null)
            {
                idDanhMuc = _currentNode.Id;
            }

            var data = _bus.GetAllDanhMuc();
            treeList1.DataSource = data;
            treeList1.Refresh();
            treeList1.ExpandAll();

            // Clear luoi 
            if (idDanhMuc == 1) // Lưới không nhảy focus
            {
                SearchDataGrid(data.First().Id);
            }

            //Focus tree
            var selected_node = treeList1.FindNodeByFieldValue("Id", idDanhMuc);
            if (selected_node != null)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    treeList1.FocusedNode = selected_node;
                }));
            }

            SplashScreenManager.CloseForm(false);
        }

        private void SearchDataGrid(long idDanhMucCha)
        {
            gridControl1.DataSource = _bus.GetDanhMucCon(idDanhMucCha);
            gridControl1.Refresh();
        }

        private List<EX_DanhMuc> GetCheckRow()
        {
            var lstData = new List<EX_DanhMuc>();
            int[] rowHandles = this.gridView1.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0) return new List<EX_DanhMuc>();
            foreach (int rowHandle in rowHandles)
            {
                var item = gridView1.GetRow(rowHandle) as EX_DanhMuc;
                if (item != null)
                {
                    lstData.Add(item);
                }
            }
            return lstData;
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
            _currentNode = treeList1.GetDataRecordByNode(e.Node) as EX_DanhMuc;
            if (_currentNode != null)
            {
                SearchDataGrid(_currentNode.Id);
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

        private void TsbThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode.IDLoaiDanhMuc >= (int)Enum_LoaiDanhMuc.BaiHoc)
                {
                    UICommon.ShowMsgWarningString("Bạn không thể thêm danh mục mới");
                    return;
                }
                E000011 frm = new E000011(_currentNode.Id, (int)_currentNode.IDLoaiDanhMuc + 1);
                if (frm.ShowDialog() == DialogResult.OK)
                    SearchDataTree();
            }
        }

        private void TsbSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var danhMuc = gridView1.GetFocusedRow() as EX_DanhMuc;
            if (_currentNode != null && danhMuc != null)
            {
                E000011 frm = new E000011(_currentNode.Id, danhMuc.IDLoaiDanhMuc);
                frm.CurrentObj = danhMuc;
                if (frm.ShowDialog() == DialogResult.OK)
                    SearchDataTree();
            }
        }

        private void TsbSaoChep_ItemClick(object sender, ItemClickEventArgs e)
        {
            var danhMuc = gridView1.GetFocusedRow() as EX_DanhMuc;
            if (_currentNode != null && danhMuc != null)
            {
                E000011 frm = new E000011(_currentNode.Id, danhMuc.IDLoaiDanhMuc);
                var danhMucEdit = (EX_DanhMuc)UICommon.CloneObject(danhMuc);
                danhMucEdit.Id = 0;
                frm.CurrentObj = danhMucEdit;
                if (frm.ShowDialog() == DialogResult.OK)
                    SearchDataTree();
            }
        }

        private void TsbXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var lstCheck = GetCheckRow();
            if (lstCheck.Count > 0)
            {
                // Kiểm tra danh mục có chứa danh mục con
                var lstIdDanhMuc = lstCheck.Select(m => m.Id).ToList();
                if (_bus.CheckExistsDanhMucCon(lstIdDanhMuc))
                {
                    if (UICommon.ShowMsgQuestionString("Tồn tại danh mục có chứa danh mục con \nBạn có muốn xóa không?") != DialogResult.Yes) return;
                }
                else
                {
                    if (_bus.CheckDanhMucDangSuDung(lstIdDanhMuc))
                    {
                        UICommon.ShowMsgWarningString("Danh mục đang sử dụng. Bạn không thể xóa!");
                        return;
                    }
                    if (UICommon.ShowMsgQuestionString("Bạn muốn xóa danh mục?") != DialogResult.Yes) return;
                }

                // Xóa danh mục
                if (_bus.DeleteDanhMucAll(lstCheck.Select(m => m.Id).ToList()) > 0)
                {
                    UICommon.ShowMsgUpdateSuccess();
                    SearchDataTree();
                }
            }
            else
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn danh mục!");
            }
        }

        private void TsbTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchDataTree();
        }

        #endregion

        #endregion
    }
}
