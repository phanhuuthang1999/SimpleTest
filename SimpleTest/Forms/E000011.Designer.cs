namespace SimpleTest.Forms
{
    partial class E000011
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelEx1 = new SimpleTest.Controls.LabelEx();
            this.txtTenDanhMuc = new PMT.EMS.Controls.TextBoxEx();
            this.txtMaDanhMuc = new PMT.EMS.Controls.TextBoxEx();
            this.labelEx2 = new SimpleTest.Controls.LabelEx();
            this.labelEx4 = new SimpleTest.Controls.LabelEx();
            this.txtGhiChu = new PMT.EMS.Controls.TextBoxEx();
            this.labelEx3 = new SimpleTest.Controls.LabelEx();
            this.txtStt = new PMT.EMS.Controls.TextBoxEx();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.labelEx1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTenDanhMuc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMaDanhMuc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelEx2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelEx4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelEx3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStt, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 163);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.BackColor = System.Drawing.Color.Transparent;
            this.labelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx1.IsRequired = true;
            this.labelEx1.Location = new System.Drawing.Point(2, 2);
            this.labelEx1.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(235, 20);
            this.labelEx1.TabIndex = 0;
            this.labelEx1.Text = "Mã danh mục";
            this.labelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDanhMuc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTenDanhMuc, 3);
            this.txtTenDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDanhMuc.Location = new System.Drawing.Point(2, 76);
            this.txtTenDanhMuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.OnlyNumberEnter = false;
            this.txtTenDanhMuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanhMuc.Properties.Appearance.Options.UseFont = true;
            this.txtTenDanhMuc.Properties.AutoHeight = false;
            this.txtTenDanhMuc.Properties.MaxLength = 200;
            this.txtTenDanhMuc.Size = new System.Drawing.Size(375, 22);
            this.txtTenDanhMuc.TabIndex = 5;
            // 
            // txtMaDanhMuc
            // 
            this.txtMaDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaDanhMuc.Location = new System.Drawing.Point(2, 26);
            this.txtMaDanhMuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDanhMuc.Name = "txtMaDanhMuc";
            this.txtMaDanhMuc.OnlyNumberEnter = false;
            this.txtMaDanhMuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDanhMuc.Properties.Appearance.Options.UseFont = true;
            this.txtMaDanhMuc.Properties.AutoHeight = false;
            this.txtMaDanhMuc.Properties.MaxLength = 50;
            this.txtMaDanhMuc.Size = new System.Drawing.Size(235, 22);
            this.txtMaDanhMuc.TabIndex = 1;
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.BackColor = System.Drawing.Color.Transparent;
            this.labelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx2.IsRequired = true;
            this.labelEx2.Location = new System.Drawing.Point(2, 52);
            this.labelEx2.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(235, 20);
            this.labelEx2.TabIndex = 4;
            this.labelEx2.Tag = "";
            this.labelEx2.Text = "Tên danh mục";
            this.labelEx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.BackColor = System.Drawing.Color.Transparent;
            this.labelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx4.IsRequired = false;
            this.labelEx4.Location = new System.Drawing.Point(2, 102);
            this.labelEx4.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(235, 20);
            this.labelEx4.TabIndex = 6;
            this.labelEx4.Tag = "";
            this.labelEx4.Text = "Ghi chú";
            this.labelEx4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(2, 126);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.OnlyNumberEnter = false;
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.AutoHeight = false;
            this.txtGhiChu.Properties.MaxLength = 200;
            this.txtGhiChu.Size = new System.Drawing.Size(375, 22);
            this.txtGhiChu.TabIndex = 7;
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.BackColor = System.Drawing.Color.Transparent;
            this.labelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx3.IsRequired = true;
            this.labelEx3.Location = new System.Drawing.Point(261, 2);
            this.labelEx3.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(116, 20);
            this.labelEx3.TabIndex = 2;
            this.labelEx3.Tag = "";
            this.labelEx3.Text = "Số thứ tự";
            this.labelEx3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStt
            // 
            this.txtStt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStt.Location = new System.Drawing.Point(261, 26);
            this.txtStt.Margin = new System.Windows.Forms.Padding(2);
            this.txtStt.Name = "txtStt";
            this.txtStt.OnlyNumberEnter = true;
            this.txtStt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStt.Properties.Appearance.Options.UseFont = true;
            this.txtStt.Properties.AutoHeight = false;
            this.txtStt.Properties.MaxLength = 9;
            this.txtStt.Size = new System.Drawing.Size(116, 22);
            this.txtStt.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(214, 205);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(295, 205);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // E000011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 238);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "E000011";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "THÊM DANH MỤC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.LabelEx labelEx1;
        private PMT.EMS.Controls.TextBoxEx txtMaDanhMuc;
        private PMT.EMS.Controls.TextBoxEx txtTenDanhMuc;
        private Controls.LabelEx labelEx2;
        private Controls.LabelEx labelEx3;
        private PMT.EMS.Controls.TextBoxEx txtStt;
        private Controls.LabelEx labelEx4;
        private PMT.EMS.Controls.TextBoxEx txtGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
    }
}