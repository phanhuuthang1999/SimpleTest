using System.Windows.Forms;

namespace SimpleTest.Controls
{
    partial class UcTuLuanDon
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtNoiDungCauHoi = new SimpleTest.Controls.EditorControl();
            this.pmtTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbKhongDaoCauHoi = new System.Windows.Forms.CheckBox();
            this.pmtTitleLabel2 = new System.Windows.Forms.Label();
            this.pmtTitleLabel1 = new System.Windows.Forms.Label();
            this.secTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNoiDungCauTraLoi = new SimpleTest.Controls.EditorControl();
            this.pmtTableLayoutPanel1.SuspendLayout();
            this.secTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtNoiDungCauHoi
            // 
            this.txtNoiDungCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDungCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungCauHoi.EditorBackColor = System.Drawing.Color.White;
            this.txtNoiDungCauHoi.EditorFont = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoi.EditorForeColor = System.Drawing.Color.Black;
            this.txtNoiDungCauHoi.EnableAutoDragDrop = true;
            this.txtNoiDungCauHoi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtNoiDungCauHoi.IsEnableUnderlineKey = true;
            this.txtNoiDungCauHoi.Location = new System.Drawing.Point(8, 35);
            this.txtNoiDungCauHoi.Name = "txtNoiDungCauHoi";
            this.txtNoiDungCauHoi.Size = new System.Drawing.Size(1060, 232);
            this.txtNoiDungCauHoi.TabIndex = 12;
            this.txtNoiDungCauHoi.Text = "";
            // 
            // pmtTableLayoutPanel1
            // 
            this.pmtTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.pmtTableLayoutPanel1.ColumnCount = 2;
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.Controls.Add(this.ckbKhongDaoCauHoi, 1, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.pmtTitleLabel2, 0, 0);
            this.pmtTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTableLayoutPanel1.Location = new System.Drawing.Point(5, 0);
            this.pmtTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.pmtTableLayoutPanel1.Name = "pmtTableLayoutPanel1";
            this.pmtTableLayoutPanel1.RowCount = 1;
            this.pmtTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.Size = new System.Drawing.Size(1066, 32);
            this.pmtTableLayoutPanel1.TabIndex = 8;
            // 
            // ckbKhongDaoCauHoi
            // 
            this.ckbKhongDaoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbKhongDaoCauHoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbKhongDaoCauHoi.Location = new System.Drawing.Point(878, 3);
            this.ckbKhongDaoCauHoi.Name = "ckbKhongDaoCauHoi";
            this.ckbKhongDaoCauHoi.Size = new System.Drawing.Size(185, 26);
            this.ckbKhongDaoCauHoi.TabIndex = 7;
            this.ckbKhongDaoCauHoi.Text = "Không đảo câu hỏi";
            // 
            // pmtTitleLabel2
            // 
            this.pmtTitleLabel2.AutoSize = true;
            this.pmtTitleLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel2.Location = new System.Drawing.Point(3, 0);
            this.pmtTitleLabel2.Name = "pmtTitleLabel2";
            this.pmtTitleLabel2.Size = new System.Drawing.Size(869, 32);
            this.pmtTitleLabel2.TabIndex = 0;
            this.pmtTitleLabel2.Text = "Câu hỏi";
            this.pmtTitleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmtTitleLabel1
            // 
            this.pmtTitleLabel1.AutoSize = true;
            this.pmtTitleLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel1.Location = new System.Drawing.Point(8, 270);
            this.pmtTitleLabel1.Name = "pmtTitleLabel1";
            this.pmtTitleLabel1.Size = new System.Drawing.Size(1060, 26);
            this.pmtTitleLabel1.TabIndex = 4;
            this.pmtTitleLabel1.Text = "Câu trả lời";
            this.pmtTitleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // secTableLayoutPanel1
            // 
            this.secTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.secTableLayoutPanel1.ColumnCount = 2;
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.secTableLayoutPanel1.Controls.Add(this.pmtTitleLabel1, 1, 2);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTableLayoutPanel1, 1, 0);
            this.secTableLayoutPanel1.Controls.Add(this.txtNoiDungCauHoi, 1, 1);
            this.secTableLayoutPanel1.Controls.Add(this.txtNoiDungCauTraLoi, 1, 3);
            this.secTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.secTableLayoutPanel1.Name = "secTableLayoutPanel1";
            this.secTableLayoutPanel1.RowCount = 5;
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.secTableLayoutPanel1.Size = new System.Drawing.Size(1071, 539);
            this.secTableLayoutPanel1.TabIndex = 1;
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
            this.txtNoiDungCauTraLoi.Location = new System.Drawing.Point(8, 299);
            this.txtNoiDungCauTraLoi.Name = "txtNoiDungCauTraLoi";
            this.txtNoiDungCauTraLoi.Size = new System.Drawing.Size(1060, 232);
            this.txtNoiDungCauTraLoi.TabIndex = 13;
            this.txtNoiDungCauTraLoi.Text = "";
            // 
            // UcTuLuanDon
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secTableLayoutPanel1);
            this.Name = "UcTuLuanDon";
            this.Size = new System.Drawing.Size(1071, 539);
            this.pmtTableLayoutPanel1.ResumeLayout(false);
            this.pmtTableLayoutPanel1.PerformLayout();
            this.secTableLayoutPanel1.ResumeLayout(false);
            this.secTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }        

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private EditorControl txtNoiDungCauHoi;
        private TableLayoutPanel pmtTableLayoutPanel1;
        private CheckBox ckbKhongDaoCauHoi;
        private Label pmtTitleLabel2;
        private Label pmtTitleLabel1;
        private TableLayoutPanel secTableLayoutPanel1;
        private EditorControl txtNoiDungCauTraLoi;
    }
}
