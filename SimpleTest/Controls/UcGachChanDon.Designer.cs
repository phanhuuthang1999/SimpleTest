using System.Windows.Forms;

namespace SimpleTest.Controls
{
    partial class UcGachChanDon
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
            this.pmtTitleLabel4 = new System.Windows.Forms.Label();
            this.pmtTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbKhongDaoCauHoi = new System.Windows.Forms.CheckBox();
            this.pmtTitleLabel2 = new System.Windows.Forms.Label();
            this.txtCtrlNoiDungCauHoi = new SimpleTest.Controls.EditorControl();
            this.tblPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pmtPanelRoot = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.secTableLayoutPanel1.SuspendLayout();
            this.pmtTableLayoutPanel1.SuspendLayout();
            this.tblPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // secTableLayoutPanel1
            // 
            this.secTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.secTableLayoutPanel1.ColumnCount = 2;
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.secTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.secTableLayoutPanel1.Controls.Add(this.pmtTitleLabel4, 1, 2);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTableLayoutPanel1, 1, 0);
            this.secTableLayoutPanel1.Controls.Add(this.txtCtrlNoiDungCauHoi, 1, 1);
            this.secTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.secTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.secTableLayoutPanel1.Name = "secTableLayoutPanel1";
            this.secTableLayoutPanel1.RowCount = 3;
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.secTableLayoutPanel1.Size = new System.Drawing.Size(1082, 353);
            this.secTableLayoutPanel1.TabIndex = 1;
            // 
            // pmtTitleLabel4
            // 
            this.pmtTitleLabel4.AutoSize = true;
            this.pmtTitleLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel4.Location = new System.Drawing.Point(8, 320);
            this.pmtTitleLabel4.Name = "pmtTitleLabel4";
            this.pmtTitleLabel4.Size = new System.Drawing.Size(1071, 33);
            this.pmtTitleLabel4.TabIndex = 12;
            this.pmtTitleLabel4.Text = "Câu trả lời";
            this.pmtTitleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pmtTableLayoutPanel1
            // 
            this.pmtTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.pmtTableLayoutPanel1.ColumnCount = 2;
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
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
            this.pmtTableLayoutPanel1.Size = new System.Drawing.Size(1077, 26);
            this.pmtTableLayoutPanel1.TabIndex = 7;
            // 
            // ckbKhongDaoCauHoi
            // 
            this.ckbKhongDaoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbKhongDaoCauHoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbKhongDaoCauHoi.Location = new System.Drawing.Point(940, 2);
            this.ckbKhongDaoCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.ckbKhongDaoCauHoi.Name = "ckbKhongDaoCauHoi";
            this.ckbKhongDaoCauHoi.Size = new System.Drawing.Size(135, 22);
            this.ckbKhongDaoCauHoi.TabIndex = 7;
            this.ckbKhongDaoCauHoi.Text = "Không đảo câu hỏi";
            // 
            // pmtTitleLabel2
            // 
            this.pmtTitleLabel2.AutoSize = true;
            this.pmtTitleLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel2.Location = new System.Drawing.Point(2, 2);
            this.pmtTitleLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.pmtTitleLabel2.Name = "pmtTitleLabel2";
            this.pmtTitleLabel2.Size = new System.Drawing.Size(934, 22);
            this.pmtTitleLabel2.TabIndex = 0;
            this.pmtTitleLabel2.Text = "Câu hỏi";
            this.pmtTitleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCtrlNoiDungCauHoi
            // 
            this.txtCtrlNoiDungCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtrlNoiDungCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCtrlNoiDungCauHoi.EditorBackColor = System.Drawing.Color.White;
            this.txtCtrlNoiDungCauHoi.EditorFont = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCtrlNoiDungCauHoi.EditorForeColor = System.Drawing.Color.Black;
            this.txtCtrlNoiDungCauHoi.EnableAutoDragDrop = true;
            this.txtCtrlNoiDungCauHoi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCtrlNoiDungCauHoi.IsEnableUnderlineKey = false;
            this.txtCtrlNoiDungCauHoi.Location = new System.Drawing.Point(8, 29);
            this.txtCtrlNoiDungCauHoi.Name = "txtCtrlNoiDungCauHoi";
            this.txtCtrlNoiDungCauHoi.Size = new System.Drawing.Size(1071, 288);
            this.txtCtrlNoiDungCauHoi.TabIndex = 10;
            this.txtCtrlNoiDungCauHoi.Text = "";
            // 
            // tblPanelMain
            // 
            this.tblPanelMain.AutoScroll = true;
            this.tblPanelMain.AutoSize = true;
            this.tblPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.tblPanelMain.ColumnCount = 3;
            this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelMain.Controls.Add(this.pmtPanelRoot, 0, 1);
            this.tblPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelMain.Location = new System.Drawing.Point(0, 353);
            this.tblPanelMain.Name = "tblPanelMain";
            this.tblPanelMain.RowCount = 2;
            this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblPanelMain.Size = new System.Drawing.Size(1082, 188);
            this.tblPanelMain.TabIndex = 2;
            // 
            // pmtPanelRoot
            // 
            this.pmtPanelRoot.BackColor = System.Drawing.Color.Transparent;
            this.tblPanelMain.SetColumnSpan(this.pmtPanelRoot, 3);
            this.pmtPanelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtPanelRoot.Location = new System.Drawing.Point(3, 8);
            this.pmtPanelRoot.Name = "pmtPanelRoot";
            this.pmtPanelRoot.Size = new System.Drawing.Size(1076, 177);
            this.pmtPanelRoot.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UcGachChanDon
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblPanelMain);
            this.Controls.Add(this.secTableLayoutPanel1);
            this.Name = "UcGachChanDon";
            this.Size = new System.Drawing.Size(1082, 541);
            this.secTableLayoutPanel1.ResumeLayout(false);
            this.secTableLayoutPanel1.PerformLayout();
            this.pmtTableLayoutPanel1.ResumeLayout(false);
            this.pmtTableLayoutPanel1.PerformLayout();
            this.tblPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private TableLayoutPanel secTableLayoutPanel1;
        private TableLayoutPanel tblPanelMain;
        private Panel pmtPanelRoot;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private TableLayoutPanel pmtTableLayoutPanel1;
        private CheckBox ckbKhongDaoCauHoi;
        private Label pmtTitleLabel2;
        private EditorControl txtCtrlNoiDungCauHoi;
        private Label pmtTitleLabel4;
    }
}
