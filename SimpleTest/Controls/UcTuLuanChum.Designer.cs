using System.Windows.Forms;

namespace SimpleTest.Controls
{
    partial class UcTuLuanChum
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.secTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pmtTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoCauHoi = new System.Windows.Forms.TextBox();
            this.pmtLabel2 = new System.Windows.Forms.Label();
            this.pmtLabel3 = new System.Windows.Forms.Label();
            this.ckbKhongDaoCauHoi = new System.Windows.Forms.CheckBox();
            this.cboChonCauHoi = new SimpleTest.Controls.LookUpEditEx();
            this.btnTaoCauHoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaCauHoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.pmtTitleLabel2 = new System.Windows.Forms.Label();
            this.pmtTitleLabel3 = new System.Windows.Forms.Label();
            this.pmtTitleLabel4 = new System.Windows.Forms.Label();
            this.txtNoiDungCauHoiCha = new SimpleTest.Controls.EditorControl();
            this.txtNoiDungCauHoiCon = new SimpleTest.Controls.EditorControl();
            this.txtNoiDungCauTraLoi = new SimpleTest.Controls.EditorControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.secTableLayoutPanel1.SuspendLayout();
            this.pmtTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboChonCauHoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // secTableLayoutPanel1
            // 
            this.secTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.secTableLayoutPanel1.ColumnCount = 2;
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.secTableLayoutPanel1.Controls.Add(this.pmtTableLayoutPanel1, 1, 2);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTitleLabel2, 0, 5);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTitleLabel3, 1, 0);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTitleLabel4, 1, 4);
            this.secTableLayoutPanel1.Controls.Add(this.txtNoiDungCauHoiCha, 1, 1);
            this.secTableLayoutPanel1.Controls.Add(this.txtNoiDungCauHoiCon, 1, 3);
            this.secTableLayoutPanel1.Controls.Add(this.txtNoiDungCauTraLoi, 1, 5);
            this.secTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.secTableLayoutPanel1.Name = "secTableLayoutPanel1";
            this.secTableLayoutPanel1.RowCount = 6;
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.secTableLayoutPanel1.Size = new System.Drawing.Size(1071, 539);
            this.secTableLayoutPanel1.TabIndex = 1;
            // 
            // pmtTableLayoutPanel1
            // 
            this.pmtTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.pmtTableLayoutPanel1.ColumnCount = 14;
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pmtTableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.txtSoCauHoi, 2, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.pmtLabel2, 1, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.pmtLabel3, 5, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.ckbKhongDaoCauHoi, 12, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.cboChonCauHoi, 6, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.btnTaoCauHoi, 3, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.btnXoaCauHoi, 8, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.btnThem, 10, 0);
            this.pmtTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTableLayoutPanel1.Location = new System.Drawing.Point(5, 178);
            this.pmtTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.pmtTableLayoutPanel1.Name = "pmtTableLayoutPanel1";
            this.pmtTableLayoutPanel1.RowCount = 1;
            this.pmtTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.Size = new System.Drawing.Size(1066, 26);
            this.pmtTableLayoutPanel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Câu hỏi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoCauHoi
            // 
            this.txtSoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoCauHoi.Location = new System.Drawing.Point(409, 2);
            this.txtSoCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoCauHoi.Name = "txtSoCauHoi";
            this.txtSoCauHoi.Size = new System.Drawing.Size(56, 22);
            this.txtSoCauHoi.TabIndex = 2;
            this.txtSoCauHoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pmtLabel2
            // 
            this.pmtLabel2.AutoSize = true;
            this.pmtLabel2.BackColor = System.Drawing.Color.Transparent;
            this.pmtLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.pmtLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pmtLabel2.Location = new System.Drawing.Point(335, 2);
            this.pmtLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.pmtLabel2.Name = "pmtLabel2";
            this.pmtLabel2.Size = new System.Drawing.Size(70, 22);
            this.pmtLabel2.TabIndex = 1;
            this.pmtLabel2.Text = "Số câu hỏi";
            this.pmtLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmtLabel3
            // 
            this.pmtLabel3.AutoSize = true;
            this.pmtLabel3.BackColor = System.Drawing.Color.Transparent;
            this.pmtLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtLabel3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.pmtLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pmtLabel3.Location = new System.Drawing.Point(554, 2);
            this.pmtLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.pmtLabel3.Name = "pmtLabel3";
            this.pmtLabel3.Size = new System.Drawing.Size(49, 22);
            this.pmtLabel3.TabIndex = 4;
            this.pmtLabel3.Text = "Câu hỏi";
            this.pmtLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbKhongDaoCauHoi
            // 
            this.ckbKhongDaoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbKhongDaoCauHoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbKhongDaoCauHoi.Location = new System.Drawing.Point(902, 2);
            this.ckbKhongDaoCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.ckbKhongDaoCauHoi.Name = "ckbKhongDaoCauHoi";
            this.ckbKhongDaoCauHoi.Size = new System.Drawing.Size(125, 22);
            this.ckbKhongDaoCauHoi.TabIndex = 8;
            this.ckbKhongDaoCauHoi.Text = "Không đảo";
            // 
            // cboChonCauHoi
            // 
            this.cboChonCauHoi.CategoryID = null;
            this.cboChonCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChonCauHoi.Location = new System.Drawing.Point(607, 2);
            this.cboChonCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.cboChonCauHoi.Name = "cboChonCauHoi";
            this.cboChonCauHoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChonCauHoi.Properties.Appearance.Options.UseFont = true;
            this.cboChonCauHoi.Properties.AutoHeight = false;
            this.cboChonCauHoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChonCauHoi.Properties.NullText = "";
            this.cboChonCauHoi.Size = new System.Drawing.Size(116, 22);
            this.cboChonCauHoi.TabIndex = 9;
            // 
            // btnTaoCauHoi
            // 
            this.btnTaoCauHoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoCauHoi.Appearance.Options.UseFont = true;
            this.btnTaoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoCauHoi.ImageOptions.Image = global::SimpleTest.Properties.Resources.apply_16x16;
            this.btnTaoCauHoi.Location = new System.Drawing.Point(470, 3);
            this.btnTaoCauHoi.Name = "btnTaoCauHoi";
            this.btnTaoCauHoi.Size = new System.Drawing.Size(64, 20);
            this.btnTaoCauHoi.TabIndex = 10;
            this.btnTaoCauHoi.Text = "Tạo";
            // 
            // btnXoaCauHoi
            // 
            this.btnXoaCauHoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCauHoi.Appearance.Options.UseFont = true;
            this.btnXoaCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoaCauHoi.ImageOptions.Image = global::SimpleTest.Properties.Resources.cancel_16x16;
            this.btnXoaCauHoi.Location = new System.Drawing.Point(737, 3);
            this.btnXoaCauHoi.Name = "btnXoaCauHoi";
            this.btnXoaCauHoi.Size = new System.Drawing.Size(64, 20);
            this.btnXoaCauHoi.TabIndex = 11;
            this.btnXoaCauHoi.Text = "Xóa";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.ImageOptions.Image = global::SimpleTest.Properties.Resources.add_16x161;
            this.btnThem.Location = new System.Drawing.Point(818, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(64, 20);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            // 
            // pmtTitleLabel2
            // 
            this.pmtTitleLabel2.AutoSize = true;
            this.pmtTitleLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel2.Location = new System.Drawing.Point(3, 385);
            this.pmtTitleLabel2.Name = "pmtTitleLabel2";
            this.pmtTitleLabel2.Size = new System.Drawing.Size(1, 154);
            this.pmtTitleLabel2.TabIndex = 19;
            this.pmtTitleLabel2.Text = "Câu hỏi";
            this.pmtTitleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmtTitleLabel3
            // 
            this.pmtTitleLabel3.AutoSize = true;
            this.pmtTitleLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel3.Location = new System.Drawing.Point(8, 0);
            this.pmtTitleLabel3.Name = "pmtTitleLabel3";
            this.pmtTitleLabel3.Size = new System.Drawing.Size(1060, 26);
            this.pmtTitleLabel3.TabIndex = 4;
            this.pmtTitleLabel3.Text = "Câu hỏi cha";
            this.pmtTitleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmtTitleLabel4
            // 
            this.pmtTitleLabel4.AutoSize = true;
            this.pmtTitleLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel4.Location = new System.Drawing.Point(8, 356);
            this.pmtTitleLabel4.Name = "pmtTitleLabel4";
            this.pmtTitleLabel4.Size = new System.Drawing.Size(1060, 29);
            this.pmtTitleLabel4.TabIndex = 7;
            this.pmtTitleLabel4.Text = "Câu trả lời";
            this.pmtTitleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoiDungCauHoiCha
            // 
            this.txtNoiDungCauHoiCha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDungCauHoiCha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungCauHoiCha.EditorBackColor = System.Drawing.Color.White;
            this.txtNoiDungCauHoiCha.EditorFont = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoiCha.EditorForeColor = System.Drawing.Color.Black;
            this.txtNoiDungCauHoiCha.EnableAutoDragDrop = true;
            this.txtNoiDungCauHoiCha.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoiCha.IsEnableUnderlineKey = true;
            this.txtNoiDungCauHoiCha.Location = new System.Drawing.Point(8, 29);
            this.txtNoiDungCauHoiCha.Name = "txtNoiDungCauHoiCha";
            this.txtNoiDungCauHoiCha.Size = new System.Drawing.Size(1060, 146);
            this.txtNoiDungCauHoiCha.TabIndex = 16;
            this.txtNoiDungCauHoiCha.Text = "";
            // 
            // txtNoiDungCauHoiCon
            // 
            this.txtNoiDungCauHoiCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDungCauHoiCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungCauHoiCon.EditorBackColor = System.Drawing.Color.White;
            this.txtNoiDungCauHoiCon.EditorFont = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoiCon.EditorForeColor = System.Drawing.Color.Black;
            this.txtNoiDungCauHoiCon.EnableAutoDragDrop = true;
            this.txtNoiDungCauHoiCon.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoiCon.IsEnableUnderlineKey = true;
            this.txtNoiDungCauHoiCon.Location = new System.Drawing.Point(8, 207);
            this.txtNoiDungCauHoiCon.Name = "txtNoiDungCauHoiCon";
            this.txtNoiDungCauHoiCon.Size = new System.Drawing.Size(1060, 146);
            this.txtNoiDungCauHoiCon.TabIndex = 17;
            this.txtNoiDungCauHoiCon.Text = "";
            // 
            // txtNoiDungCauTraLoi
            // 
            this.txtNoiDungCauTraLoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDungCauTraLoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungCauTraLoi.EditorBackColor = System.Drawing.Color.White;
            this.txtNoiDungCauTraLoi.EditorFont = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauTraLoi.EditorForeColor = System.Drawing.Color.Black;
            this.txtNoiDungCauTraLoi.EnableAutoDragDrop = true;
            this.txtNoiDungCauTraLoi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauTraLoi.IsEnableUnderlineKey = true;
            this.txtNoiDungCauTraLoi.Location = new System.Drawing.Point(8, 388);
            this.txtNoiDungCauTraLoi.Name = "txtNoiDungCauTraLoi";
            this.txtNoiDungCauTraLoi.Size = new System.Drawing.Size(1060, 148);
            this.txtNoiDungCauTraLoi.TabIndex = 18;
            this.txtNoiDungCauTraLoi.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UcTuLuanChum
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secTableLayoutPanel1);
            this.Name = "UcTuLuanChum";
            this.Size = new System.Drawing.Size(1071, 539);
            this.secTableLayoutPanel1.ResumeLayout(false);
            this.secTableLayoutPanel1.PerformLayout();
            this.pmtTableLayoutPanel1.ResumeLayout(false);
            this.pmtTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboChonCauHoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel secTableLayoutPanel1;
        private Label pmtTitleLabel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Label pmtTitleLabel4;
        private EditorControl txtNoiDungCauHoiCha;
        private EditorControl txtNoiDungCauHoiCon;
        private EditorControl txtNoiDungCauTraLoi;
        private Label pmtTitleLabel2;
        private TableLayoutPanel pmtTableLayoutPanel1;
        private Label label1;
        private TextBox txtSoCauHoi;
        private Label pmtLabel2;
        private Label pmtLabel3;
        private CheckBox ckbKhongDaoCauHoi;
        private LookUpEditEx cboChonCauHoi;
        private DevExpress.XtraEditors.SimpleButton btnTaoCauHoi;
        private DevExpress.XtraEditors.SimpleButton btnXoaCauHoi;
        private DevExpress.XtraEditors.SimpleButton btnThem;
    }
}
