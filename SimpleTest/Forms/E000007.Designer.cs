namespace SimpleTest.Forms
{
    partial class E000007
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
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridChuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaChuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenChuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboPhan = new SimpleTest.Controls.LookUpEditEx();
            this.cboMonHoc = new SimpleTest.Controls.LookUpEditEx();
            this.cboKhoiLop = new SimpleTest.Controls.LookUpEditEx();
            this.txtMaChuong = new DevExpress.XtraEditors.TextEdit();
            this.txtTenChuong = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblKhoiLop = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoiLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoiLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.gridControl1.Location = new System.Drawing.Point(246, 0);
            this.gridControl1.MainView = this.gridChuong;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(861, 619);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridChuong});
            // 
            // gridChuong
            // 
            this.gridChuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhan,
            this.colMaChuong,
            this.colTenChuong,
            this.colStt,
            this.colGhiChu});
            this.gridChuong.GridControl = this.gridControl1;
            this.gridChuong.Name = "gridChuong";
            this.gridChuong.OptionsBehavior.Editable = false;
            this.gridChuong.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.gridChuong.OptionsSelection.MultiSelect = true;
            this.gridChuong.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridChuong.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridChuong.OptionsView.ShowGroupPanel = false;
            // 
            // colPhan
            // 
            this.colPhan.Caption = "Nội dung kiến thức";
            this.colPhan.FieldName = "TenDanhMucCha";
            this.colPhan.Name = "colPhan";
            this.colPhan.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPhan.Visible = true;
            this.colPhan.VisibleIndex = 1;
            this.colPhan.Width = 151;
            // 
            // colMaChuong
            // 
            this.colMaChuong.Caption = "Mã Đơn vị kiến thức";
            this.colMaChuong.FieldName = "MaDanhMuc";
            this.colMaChuong.Name = "colMaChuong";
            this.colMaChuong.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMaChuong.Visible = true;
            this.colMaChuong.VisibleIndex = 2;
            this.colMaChuong.Width = 119;
            // 
            // colTenChuong
            // 
            this.colTenChuong.Caption = "Tên Đơn vị kiến thức";
            this.colTenChuong.FieldName = "TenDanhMuc";
            this.colTenChuong.Name = "colTenChuong";
            this.colTenChuong.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTenChuong.Visible = true;
            this.colTenChuong.VisibleIndex = 3;
            this.colTenChuong.Width = 119;
            // 
            // colStt
            // 
            this.colStt.Caption = "Số thứ tự";
            this.colStt.FieldName = "STT";
            this.colStt.Name = "colStt";
            this.colStt.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colStt.Visible = true;
            this.colStt.VisibleIndex = 4;
            this.colStt.Width = 119;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 140;
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
            this.dockPanel1.ID = new System.Guid("85b25e43-8db1-4e64-a6c9-c47efc301797");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(246, 200);
            this.dockPanel1.Size = new System.Drawing.Size(246, 619);
            this.dockPanel1.Text = "Điều kiện lọc";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 46);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(239, 570);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboPhan);
            this.layoutControl1.Controls.Add(this.cboMonHoc);
            this.layoutControl1.Controls.Add(this.cboKhoiLop);
            this.layoutControl1.Controls.Add(this.txtMaChuong);
            this.layoutControl1.Controls.Add(this.txtTenChuong);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(495, 384, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(239, 570);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboPhan
            // 
            this.cboPhan.CategoryID = null;
            this.cboPhan.Location = new System.Drawing.Point(7, 108);
            this.cboPhan.Margin = new System.Windows.Forms.Padding(2);
            this.cboPhan.Name = "cboPhan";
            this.cboPhan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhan.Properties.Appearance.Options.UseFont = true;
            this.cboPhan.Properties.AutoHeight = false;
            this.cboPhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhan.Properties.NullText = "";
            this.cboPhan.Size = new System.Drawing.Size(225, 20);
            this.cboPhan.StyleController = this.layoutControl1;
            this.cboPhan.TabIndex = 4;
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.CategoryID = null;
            this.cboMonHoc.Location = new System.Drawing.Point(7, 68);
            this.cboMonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonHoc.Properties.Appearance.Options.UseFont = true;
            this.cboMonHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMonHoc.Properties.NullText = "";
            this.cboMonHoc.Size = new System.Drawing.Size(225, 20);
            this.cboMonHoc.StyleController = this.layoutControl1;
            this.cboMonHoc.TabIndex = 1;
            // 
            // cboKhoiLop
            // 
            this.cboKhoiLop.CategoryID = null;
            this.cboKhoiLop.Location = new System.Drawing.Point(7, 28);
            this.cboKhoiLop.Margin = new System.Windows.Forms.Padding(2);
            this.cboKhoiLop.Name = "cboKhoiLop";
            this.cboKhoiLop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhoiLop.Properties.Appearance.Options.UseFont = true;
            this.cboKhoiLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKhoiLop.Properties.NullText = "";
            this.cboKhoiLop.Size = new System.Drawing.Size(225, 20);
            this.cboKhoiLop.StyleController = this.layoutControl1;
            this.cboKhoiLop.TabIndex = 0;
            // 
            // txtMaChuong
            // 
            this.txtMaChuong.Location = new System.Drawing.Point(7, 148);
            this.txtMaChuong.Name = "txtMaChuong";
            this.txtMaChuong.Properties.MaxLength = 200;
            this.txtMaChuong.Size = new System.Drawing.Size(225, 20);
            this.txtMaChuong.StyleController = this.layoutControl1;
            this.txtMaChuong.TabIndex = 2;
            // 
            // txtTenChuong
            // 
            this.txtTenChuong.Location = new System.Drawing.Point(7, 188);
            this.txtTenChuong.Name = "txtTenChuong";
            this.txtTenChuong.Properties.MaxLength = 200;
            this.txtTenChuong.Size = new System.Drawing.Size(225, 20);
            this.txtTenChuong.StyleController = this.layoutControl1;
            this.txtTenChuong.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.lblKhoiLop,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(239, 570);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 200);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(229, 355);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenChuong;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 160);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(229, 40);
            this.layoutControlItem2.Text = "Tên Đơn vị kiến thức";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMaChuong;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(229, 40);
            this.layoutControlItem1.Text = "Mã Đơn vị kiến thức";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 13);
            // 
            // lblKhoiLop
            // 
            this.lblKhoiLop.Control = this.cboKhoiLop;
            this.lblKhoiLop.Location = new System.Drawing.Point(0, 0);
            this.lblKhoiLop.MaxSize = new System.Drawing.Size(0, 40);
            this.lblKhoiLop.MinSize = new System.Drawing.Size(114, 40);
            this.lblKhoiLop.Name = "lblKhoiLop";
            this.lblKhoiLop.Size = new System.Drawing.Size(229, 40);
            this.lblKhoiLop.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lblKhoiLop.Text = "Khối lớp";
            this.lblKhoiLop.TextLocation = DevExpress.Utils.Locations.Top;
            this.lblKhoiLop.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboMonHoc;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(114, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(229, 40);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Môn học";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cboPhan;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(103, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(229, 40);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Nội dung kiến thức";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(99, 13);
            // 
            // E000007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 619);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "E000007";
            this.Text = "E000007";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoiLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoiLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridChuong;
        private DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView noDocumentsView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtTenChuong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colMaChuong;
        private DevExpress.XtraGrid.Columns.GridColumn colTenChuong;
        private DevExpress.XtraGrid.Columns.GridColumn colStt;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.TextEdit txtMaChuong;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Controls.LookUpEditEx cboKhoiLop;
        private DevExpress.XtraLayout.LayoutControlItem lblKhoiLop;
        private Controls.LookUpEditEx cboMonHoc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colPhan;
        private Controls.LookUpEditEx cboPhan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}