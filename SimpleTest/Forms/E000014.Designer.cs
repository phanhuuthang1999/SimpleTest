namespace SimpleTest.Forms
{
    partial class E000014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E000014));
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTTCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDungText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLoaiCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDoKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCauHoiCha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboLoaiCauHoi = new SimpleTest.Controls.LookUpEditEx();
            this.labelEx1 = new SimpleTest.Controls.LabelEx();
            this.labelEx2 = new SimpleTest.Controls.LabelEx();
            this.cboMucDoNhanThuc = new SimpleTest.Controls.LookUpEditEx();
            this.labelEx3 = new SimpleTest.Controls.LabelEx();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDDanhMucCha = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDLoaiDanhMuc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSTT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGhiChu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTongSoLuong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSoLuongDon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucDisplayCauHoi1 = new PMT.EXAM.DISPLAY.UCDisplayCauHoi();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.colDanhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiCauHoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMucDoNhanThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ClientControl = this.groupControl1;
            this.documentManager1.View = this.noDocumentsView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.noDocumentsView1,
            this.tabbedView1});
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(410, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(611, 678);
            this.groupControl1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(607, 674);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTTCauHoi,
            this.colIdCauHoi,
            this.colNoiDungText,
            this.colTenLoaiCauHoi,
            this.colTenDoKho,
            this.colIsCauHoiCha,
            this.colDanhMuc});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            // 
            // colSTTCauHoi
            // 
            this.colSTTCauHoi.Caption = "STT";
            this.colSTTCauHoi.FieldName = "STT";
            this.colSTTCauHoi.Name = "colSTTCauHoi";
            this.colSTTCauHoi.Visible = true;
            this.colSTTCauHoi.VisibleIndex = 1;
            // 
            // colIdCauHoi
            // 
            this.colIdCauHoi.Caption = "ID Câu hỏi";
            this.colIdCauHoi.FieldName = "Id";
            this.colIdCauHoi.Name = "colIdCauHoi";
            this.colIdCauHoi.Visible = true;
            this.colIdCauHoi.VisibleIndex = 2;
            // 
            // colNoiDungText
            // 
            this.colNoiDungText.Caption = "Nội dung text";
            this.colNoiDungText.FieldName = "NoiDungText";
            this.colNoiDungText.Name = "colNoiDungText";
            this.colNoiDungText.Visible = true;
            this.colNoiDungText.VisibleIndex = 3;
            // 
            // colTenLoaiCauHoi
            // 
            this.colTenLoaiCauHoi.Caption = "Tên loại câu hỏi";
            this.colTenLoaiCauHoi.FieldName = "TenLoaiCauHoi";
            this.colTenLoaiCauHoi.Name = "colTenLoaiCauHoi";
            this.colTenLoaiCauHoi.Visible = true;
            this.colTenLoaiCauHoi.VisibleIndex = 7;
            // 
            // colTenDoKho
            // 
            this.colTenDoKho.Caption = "Mức độ nhận thức";
            this.colTenDoKho.FieldName = "TenDoKho";
            this.colTenDoKho.Name = "colTenDoKho";
            this.colTenDoKho.Visible = true;
            this.colTenDoKho.VisibleIndex = 4;
            // 
            // colIsCauHoiCha
            // 
            this.colIsCauHoiCha.Caption = "Câu hỏi nhóm";
            this.colIsCauHoiCha.FieldName = "IsCauHoiCha";
            this.colIsCauHoiCha.Name = "colIsCauHoiCha";
            this.colIsCauHoiCha.Visible = true;
            this.colIsCauHoiCha.VisibleIndex = 5;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
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
            this.dockPanel1.ID = new System.Guid("a27cc4a8-1781-4403-815f-8530b9ef7904");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(410, 200);
            this.dockPanel1.Size = new System.Drawing.Size(410, 678);
            this.dockPanel1.Text = "Điều kiện lọc";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 46);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(403, 629);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cboLoaiCauHoi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelEx1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEx2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboMucDoNhanThuc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelEx3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.treeList1, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 629);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cboLoaiCauHoi
            // 
            this.cboLoaiCauHoi.CategoryID = null;
            this.cboLoaiCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiCauHoi.Location = new System.Drawing.Point(2, 26);
            this.cboLoaiCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoaiCauHoi.Name = "cboLoaiCauHoi";
            this.cboLoaiCauHoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiCauHoi.Properties.Appearance.Options.UseFont = true;
            this.cboLoaiCauHoi.Properties.AutoHeight = false;
            this.cboLoaiCauHoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiCauHoi.Properties.NullText = "";
            this.cboLoaiCauHoi.Size = new System.Drawing.Size(399, 22);
            this.cboLoaiCauHoi.TabIndex = 1;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.BackColor = System.Drawing.Color.Transparent;
            this.labelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx1.IsRequired = false;
            this.labelEx1.Location = new System.Drawing.Point(2, 2);
            this.labelEx1.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(399, 20);
            this.labelEx1.TabIndex = 0;
            this.labelEx1.Text = "Loại câu hỏi";
            this.labelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.BackColor = System.Drawing.Color.Transparent;
            this.labelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx2.IsRequired = false;
            this.labelEx2.Location = new System.Drawing.Point(2, 52);
            this.labelEx2.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(399, 20);
            this.labelEx2.TabIndex = 0;
            this.labelEx2.Text = "Mức độ nhận thức";
            this.labelEx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMucDoNhanThuc
            // 
            this.cboMucDoNhanThuc.CategoryID = null;
            this.cboMucDoNhanThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMucDoNhanThuc.Location = new System.Drawing.Point(2, 76);
            this.cboMucDoNhanThuc.Margin = new System.Windows.Forms.Padding(2);
            this.cboMucDoNhanThuc.Name = "cboMucDoNhanThuc";
            this.cboMucDoNhanThuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMucDoNhanThuc.Properties.Appearance.Options.UseFont = true;
            this.cboMucDoNhanThuc.Properties.AutoHeight = false;
            this.cboMucDoNhanThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMucDoNhanThuc.Properties.NullText = "";
            this.cboMucDoNhanThuc.Size = new System.Drawing.Size(399, 22);
            this.cboMucDoNhanThuc.TabIndex = 1;
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.BackColor = System.Drawing.Color.Transparent;
            this.labelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx3.IsRequired = false;
            this.labelEx3.Location = new System.Drawing.Point(2, 102);
            this.labelEx3.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(399, 20);
            this.labelEx3.TabIndex = 0;
            this.labelEx3.Text = "Danh mục";
            this.labelEx3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.colGhiChu,
            this.colTongSoLuong,
            this.colSoLuongDon});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(391, 433, 252, 276);
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(2, 126);
            this.treeList1.Margin = new System.Windows.Forms.Padding(2);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "IDDanhMucCha";
            this.treeList1.RowHeight = 25;
            this.treeList1.SelectImageList = this.imageCollection1;
            this.treeList1.Size = new System.Drawing.Size(399, 501);
            this.treeList1.TabIndex = 5;
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
            this.colTenDanhMuc.Width = 261;
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
            // colTongSoLuong
            // 
            this.colTongSoLuong.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colTongSoLuong.AppearanceCell.Options.UseForeColor = true;
            this.colTongSoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.colTongSoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTongSoLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTongSoLuong.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTongSoLuong.Caption = "Tổng SL";
            this.colTongSoLuong.FieldName = "TongSoLuong";
            this.colTongSoLuong.Name = "colTongSoLuong";
            this.colTongSoLuong.OptionsColumn.AllowEdit = false;
            this.colTongSoLuong.Visible = true;
            this.colTongSoLuong.VisibleIndex = 1;
            this.colTongSoLuong.Width = 71;
            // 
            // colSoLuongDon
            // 
            this.colSoLuongDon.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colSoLuongDon.AppearanceCell.Options.UseForeColor = true;
            this.colSoLuongDon.AppearanceCell.Options.UseTextOptions = true;
            this.colSoLuongDon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuongDon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoLuongDon.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuongDon.Caption = "SL";
            this.colSoLuongDon.FieldName = "SoLuongCauHoi";
            this.colSoLuongDon.Name = "colSoLuongDon";
            this.colSoLuongDon.OptionsColumn.AllowEdit = false;
            this.colSoLuongDon.Visible = true;
            this.colSoLuongDon.VisibleIndex = 2;
            this.colSoLuongDon.Width = 49;
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
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.ID = new System.Guid("15d0f458-e02a-4d93-8ec5-6ce87632fa85");
            this.dockPanel2.Location = new System.Drawing.Point(1021, 0);
            this.dockPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(683, 200);
            this.dockPanel2.Size = new System.Drawing.Size(683, 678);
            this.dockPanel2.Text = "Nội dung câu hỏi";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.ucDisplayCauHoi1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 46);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(676, 629);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // ucDisplayCauHoi1
            // 
            this.ucDisplayCauHoi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDisplayCauHoi1.Location = new System.Drawing.Point(0, 0);
            this.ucDisplayCauHoi1.Name = "ucDisplayCauHoi1";
            this.ucDisplayCauHoi1.Size = new System.Drawing.Size(676, 629);
            this.ucDisplayCauHoi1.TabIndex = 0;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // colDanhMuc
            // 
            this.colDanhMuc.Caption = "Danh mục";
            this.colDanhMuc.FieldName = "TenDanhMuc";
            this.colDanhMuc.Name = "colDanhMuc";
            this.colDanhMuc.Visible = true;
            this.colDanhMuc.VisibleIndex = 6;
            // 
            // E000014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 678);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "E000014";
            this.Text = "Danh sách câu hỏi";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiCauHoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMucDoNhanThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView noDocumentsView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private PMT.EXAM.DISPLAY.UCDisplayCauHoi ucDisplayCauHoi1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.LookUpEditEx cboLoaiCauHoi;
        private Controls.LabelEx labelEx1;
        private Controls.LabelEx labelEx2;
        private Controls.LookUpEditEx cboMucDoNhanThuc;
        private Controls.LabelEx labelEx3;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDDanhMucCha;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDLoaiDanhMuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSTT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGhiChu;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTongSoLuong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSoLuongDon;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDungText;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoaiCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn colSTTCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoKho;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCauHoiCha;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMuc;
    }
}