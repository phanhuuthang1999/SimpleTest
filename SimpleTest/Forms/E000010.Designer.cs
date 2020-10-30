namespace SimpleTest.Forms
{
    partial class E000010
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E000010));
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDanhMuc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDanhMuc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDanhMuc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDDanhMucCha = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDLoaiDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSTT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGhiChu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ClientControl = this.gridControl1;
            this.documentManager1.View = this.noDocumentsView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.noDocumentsView1,
            this.tabbedView1});
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(454, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(648, 644);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDanhMuc2,
            this.colTenDanhMuc2,
            this.colLoaiDanhMuc2,
            this.colSTT2,
            this.colGhiChu2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            // 
            // colMaDanhMuc2
            // 
            this.colMaDanhMuc2.Caption = "Mã danh mục";
            this.colMaDanhMuc2.FieldName = "MaDanhMuc";
            this.colMaDanhMuc2.Name = "colMaDanhMuc2";
            this.colMaDanhMuc2.Visible = true;
            this.colMaDanhMuc2.VisibleIndex = 1;
            // 
            // colTenDanhMuc2
            // 
            this.colTenDanhMuc2.Caption = "Tên danh mục";
            this.colTenDanhMuc2.FieldName = "TenDanhMuc";
            this.colTenDanhMuc2.Name = "colTenDanhMuc2";
            this.colTenDanhMuc2.Visible = true;
            this.colTenDanhMuc2.VisibleIndex = 2;
            // 
            // colLoaiDanhMuc2
            // 
            this.colLoaiDanhMuc2.Caption = "Loại danh mục";
            this.colLoaiDanhMuc2.FieldName = "TenLoaiDanhMuc";
            this.colLoaiDanhMuc2.Name = "colLoaiDanhMuc2";
            this.colLoaiDanhMuc2.Visible = true;
            this.colLoaiDanhMuc2.VisibleIndex = 4;
            // 
            // colSTT2
            // 
            this.colSTT2.Caption = "STT";
            this.colSTT2.FieldName = "STT";
            this.colSTT2.Name = "colSTT2";
            this.colSTT2.Visible = true;
            this.colSTT2.VisibleIndex = 3;
            // 
            // colGhiChu2
            // 
            this.colGhiChu2.Caption = "Ghi chú";
            this.colGhiChu2.FieldName = "GhiChu";
            this.colGhiChu2.Name = "colGhiChu2";
            this.colGhiChu2.Visible = true;
            this.colGhiChu2.VisibleIndex = 5;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("6cb19ba1-4248-451b-8179-6fe4f720aa4c");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(454, 200);
            this.dockPanel1.Size = new System.Drawing.Size(454, 644);
            this.dockPanel1.Text = "Danh mục";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(445, 617);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(445, 617);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.treeList1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Transparent;
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.treeList1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colIDDanhMucCha,
            this.colMaDanhMuc,
            this.colTenDanhMuc,
            this.colIDLoaiDanhMuc,
            this.colSTT,
            this.colGhiChu});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(391, 433, 252, 276);
            this.treeList1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(2, 2);
            this.treeList1.Margin = new System.Windows.Forms.Padding(0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.treeList1.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.ParentFieldName = "IDDanhMucCha";
            this.treeList1.RowHeight = 25;
            this.treeList1.SelectImageList = this.imageCollection1;
            this.treeList1.Size = new System.Drawing.Size(441, 613);
            this.treeList1.TabIndex = 4;
            this.treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colIDDanhMucCha
            // 
            this.colIDDanhMucCha.FieldName = "IDDanhMucCha";
            this.colIDDanhMucCha.Name = "colIDDanhMucCha";
            this.colIDDanhMucCha.OptionsColumn.AllowSort = false;
            // 
            // colMaDanhMuc
            // 
            this.colMaDanhMuc.Caption = "Mã danh mục";
            this.colMaDanhMuc.FieldName = "MaDanhMuc";
            this.colMaDanhMuc.Name = "colMaDanhMuc";
            this.colMaDanhMuc.OptionsColumn.AllowEdit = false;
            this.colMaDanhMuc.Width = 100;
            // 
            // colTenDanhMuc
            // 
            this.colTenDanhMuc.Caption = "Tên danh mục";
            this.colTenDanhMuc.FieldName = "TenDanhMuc";
            this.colTenDanhMuc.Name = "colTenDanhMuc";
            this.colTenDanhMuc.OptionsColumn.AllowEdit = false;
            this.colTenDanhMuc.OptionsColumn.AllowSort = false;
            this.colTenDanhMuc.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colTenDanhMuc.Visible = true;
            this.colTenDanhMuc.VisibleIndex = 0;
            this.colTenDanhMuc.Width = 136;
            // 
            // colIDLoaiDanhMuc
            // 
            this.colIDLoaiDanhMuc.FieldName = "IDLoaiDanhMuc";
            this.colIDLoaiDanhMuc.Name = "colIDLoaiDanhMuc";
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            this.colSTT.Width = 82;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.Width = 82;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "home");
            this.imageCollection1.Images.SetKeyName(1, "1");
            this.imageCollection1.Images.SetKeyName(2, "2");
            this.imageCollection1.Images.SetKeyName(3, "3");
            this.imageCollection1.Images.SetKeyName(4, "4");
            this.imageCollection1.Images.SetKeyName(5, "5");
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(445, 617);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeList1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(445, 617);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // E000010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 644);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "E000010";
            this.Text = "E000010";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView noDocumentsView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDDanhMucCha;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDLoaiDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSTT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGhiChu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDanhMuc2;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDanhMuc2;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDanhMuc2;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT2;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu2;
    }
}