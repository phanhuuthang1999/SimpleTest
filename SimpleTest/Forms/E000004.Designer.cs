﻿namespace SimpleTest.Forms
{
    partial class E000004
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
            this.txtTenMonHoc = new PMT.EMS.Controls.TextBoxEx();
            this.txtMaMonHoc = new PMT.EMS.Controls.TextBoxEx();
            this.labelEx2 = new SimpleTest.Controls.LabelEx();
            this.labelEx4 = new SimpleTest.Controls.LabelEx();
            this.txtGhiChu = new PMT.EMS.Controls.TextBoxEx();
            this.labelEx3 = new SimpleTest.Controls.LabelEx();
            this.txtStt = new PMT.EMS.Controls.TextBoxEx();
            this.labelEx5 = new SimpleTest.Controls.LabelEx();
            this.cboKhoiLop = new SimpleTest.Controls.LookUpEditEx();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMonHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMonHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoiLop.Properties)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.labelEx1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenMonHoc, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtMaMonHoc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelEx2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelEx4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelEx3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtStt, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelEx5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboKhoiLop, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 215);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.BackColor = System.Drawing.Color.Transparent;
            this.labelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx1.IsRequired = true;
            this.labelEx1.Location = new System.Drawing.Point(2, 52);
            this.labelEx1.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(235, 20);
            this.labelEx1.TabIndex = 2;
            this.labelEx1.Text = "Mã môn học";
            this.labelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenMonHoc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTenMonHoc, 3);
            this.txtTenMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenMonHoc.Location = new System.Drawing.Point(2, 126);
            this.txtTenMonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenMonHoc.Name = "txtTenMonHoc";
            this.txtTenMonHoc.OnlyNumberEnter = false;
            this.txtTenMonHoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMonHoc.Properties.Appearance.Options.UseFont = true;
            this.txtTenMonHoc.Properties.AutoHeight = false;
            this.txtTenMonHoc.Properties.MaxLength = 200;
            this.txtTenMonHoc.Size = new System.Drawing.Size(375, 22);
            this.txtTenMonHoc.TabIndex = 7;
            // 
            // txtMaMonHoc
            // 
            this.txtMaMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaMonHoc.Location = new System.Drawing.Point(2, 76);
            this.txtMaMonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaMonHoc.Name = "txtMaMonHoc";
            this.txtMaMonHoc.OnlyNumberEnter = false;
            this.txtMaMonHoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMonHoc.Properties.Appearance.Options.UseFont = true;
            this.txtMaMonHoc.Properties.AutoHeight = false;
            this.txtMaMonHoc.Properties.MaxLength = 50;
            this.txtMaMonHoc.Size = new System.Drawing.Size(235, 22);
            this.txtMaMonHoc.TabIndex = 3;
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.BackColor = System.Drawing.Color.Transparent;
            this.labelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx2.IsRequired = true;
            this.labelEx2.Location = new System.Drawing.Point(2, 102);
            this.labelEx2.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(235, 20);
            this.labelEx2.TabIndex = 6;
            this.labelEx2.Tag = "";
            this.labelEx2.Text = "Tên môn học";
            this.labelEx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.BackColor = System.Drawing.Color.Transparent;
            this.labelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx4.IsRequired = false;
            this.labelEx4.Location = new System.Drawing.Point(2, 152);
            this.labelEx4.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(235, 20);
            this.labelEx4.TabIndex = 8;
            this.labelEx4.Tag = "";
            this.labelEx4.Text = "Ghi chú";
            this.labelEx4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(2, 176);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.OnlyNumberEnter = false;
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.AutoHeight = false;
            this.txtGhiChu.Properties.MaxLength = 200;
            this.txtGhiChu.Size = new System.Drawing.Size(375, 22);
            this.txtGhiChu.TabIndex = 9;
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.BackColor = System.Drawing.Color.Transparent;
            this.labelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx3.IsRequired = false;
            this.labelEx3.Location = new System.Drawing.Point(261, 52);
            this.labelEx3.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(116, 20);
            this.labelEx3.TabIndex = 4;
            this.labelEx3.Tag = "";
            this.labelEx3.Text = "Số thứ tự";
            this.labelEx3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStt
            // 
            this.txtStt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStt.Location = new System.Drawing.Point(261, 76);
            this.txtStt.Margin = new System.Windows.Forms.Padding(2);
            this.txtStt.Name = "txtStt";
            this.txtStt.OnlyNumberEnter = true;
            this.txtStt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStt.Properties.Appearance.Options.UseFont = true;
            this.txtStt.Properties.AutoHeight = false;
            this.txtStt.Properties.MaxLength = 9;
            this.txtStt.Size = new System.Drawing.Size(116, 22);
            this.txtStt.TabIndex = 5;
            // 
            // labelEx5
            // 
            this.labelEx5.AutoSize = true;
            this.labelEx5.BackColor = System.Drawing.Color.Transparent;
            this.labelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEx5.IsRequired = true;
            this.labelEx5.Location = new System.Drawing.Point(2, 2);
            this.labelEx5.Margin = new System.Windows.Forms.Padding(2);
            this.labelEx5.Name = "labelEx5";
            this.labelEx5.Size = new System.Drawing.Size(235, 20);
            this.labelEx5.TabIndex = 0;
            this.labelEx5.Text = "Khối lớp";
            this.labelEx5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhoiLop
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboKhoiLop, 3);
            this.cboKhoiLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhoiLop.Location = new System.Drawing.Point(2, 26);
            this.cboKhoiLop.Margin = new System.Windows.Forms.Padding(2);
            this.cboKhoiLop.Name = "cboKhoiLop";
            this.cboKhoiLop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhoiLop.Properties.Appearance.Options.UseFont = true;
            this.cboKhoiLop.Properties.AutoHeight = false;
            this.cboKhoiLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKhoiLop.Properties.NullText = "";
            this.cboKhoiLop.Size = new System.Drawing.Size(375, 22);
            this.cboKhoiLop.TabIndex = 10;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(214, 257);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(295, 257);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // E000004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 290);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "E000004";
            this.Text = "THÊM MÔN HỌC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMonHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMonHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoiLop.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.LabelEx labelEx1;
        private PMT.EMS.Controls.TextBoxEx txtMaMonHoc;
        private PMT.EMS.Controls.TextBoxEx txtTenMonHoc;
        private Controls.LabelEx labelEx2;
        private Controls.LabelEx labelEx3;
        private PMT.EMS.Controls.TextBoxEx txtStt;
        private Controls.LabelEx labelEx4;
        private PMT.EMS.Controls.TextBoxEx txtGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private Controls.LabelEx labelEx5;
        private Controls.LookUpEditEx cboKhoiLop;
    }
}