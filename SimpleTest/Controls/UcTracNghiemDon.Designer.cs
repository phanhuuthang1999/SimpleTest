using System.Windows.Forms;

namespace SimpleTest.Controls
{
    partial class UcTracNghiemDon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.secTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pmtTableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pmtTitleLabel4 = new System.Windows.Forms.Label();
            this.btnThemCauTraLoi = new DevExpress.XtraEditors.SimpleButton();
            this.pmtTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbKhongDaoCauHoi = new System.Windows.Forms.CheckBox();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.txtCtrlNoiDungCauHoi = new SimpleTest.Controls.EditorControl();
            this.tblPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pmtPanelRoot = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.secTableLayoutPanel1.SuspendLayout();
            this.pmtTableLayoutPanel3.SuspendLayout();
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
            this.secTableLayoutPanel1.Controls.Add(this.pmtTableLayoutPanel3, 1, 2);
            this.secTableLayoutPanel1.Controls.Add(this.pmtTableLayoutPanel1, 1, 0);
            this.secTableLayoutPanel1.Controls.Add(this.txtCtrlNoiDungCauHoi, 1, 1);
            this.secTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.secTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.secTableLayoutPanel1.Name = "secTableLayoutPanel1";
            this.secTableLayoutPanel1.RowCount = 3;
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.secTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.secTableLayoutPanel1.Size = new System.Drawing.Size(1069, 295);
            this.secTableLayoutPanel1.TabIndex = 1;
            // 
            // pmtTableLayoutPanel3
            // 
            this.pmtTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.pmtTableLayoutPanel3.ColumnCount = 3;
            this.pmtTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.pmtTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.pmtTableLayoutPanel3.Controls.Add(this.pmtTitleLabel4, 0, 0);
            this.pmtTableLayoutPanel3.Controls.Add(this.btnThemCauTraLoi, 1, 0);
            this.pmtTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTableLayoutPanel3.Location = new System.Drawing.Point(5, 262);
            this.pmtTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.pmtTableLayoutPanel3.Name = "pmtTableLayoutPanel3";
            this.pmtTableLayoutPanel3.RowCount = 1;
            this.pmtTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel3.Size = new System.Drawing.Size(1064, 33);
            this.pmtTableLayoutPanel3.TabIndex = 0;
            // 
            // pmtTitleLabel4
            // 
            this.pmtTitleLabel4.AutoSize = true;
            this.pmtTitleLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTitleLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pmtTitleLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.pmtTitleLabel4.Location = new System.Drawing.Point(3, 0);
            this.pmtTitleLabel4.Name = "pmtTitleLabel4";
            this.pmtTitleLabel4.Size = new System.Drawing.Size(898, 33);
            this.pmtTitleLabel4.TabIndex = 0;
            this.pmtTitleLabel4.Text = "Câu trả lời";
            this.pmtTitleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThemCauTraLoi
            // 
            this.btnThemCauTraLoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCauTraLoi.Appearance.Options.UseFont = true;
            this.btnThemCauTraLoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemCauTraLoi.ImageOptions.Image = global::SimpleTest.Properties.Resources.add_16x16;
            this.btnThemCauTraLoi.Location = new System.Drawing.Point(906, 2);
            this.btnThemCauTraLoi.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.btnThemCauTraLoi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnThemCauTraLoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemCauTraLoi.Name = "btnThemCauTraLoi";
            this.btnThemCauTraLoi.Size = new System.Drawing.Size(82, 29);
            this.btnThemCauTraLoi.TabIndex = 1;
            this.btnThemCauTraLoi.Text = "Thêm";
            // 
            // pmtTableLayoutPanel1
            // 
            this.pmtTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.pmtTableLayoutPanel1.ColumnCount = 2;
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pmtTableLayoutPanel1.Controls.Add(this.ckbKhongDaoCauHoi, 1, 0);
            this.pmtTableLayoutPanel1.Controls.Add(this.lblCauHoi, 0, 0);
            this.pmtTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtTableLayoutPanel1.Location = new System.Drawing.Point(5, 0);
            this.pmtTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.pmtTableLayoutPanel1.Name = "pmtTableLayoutPanel1";
            this.pmtTableLayoutPanel1.RowCount = 1;
            this.pmtTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pmtTableLayoutPanel1.Size = new System.Drawing.Size(1064, 30);
            this.pmtTableLayoutPanel1.TabIndex = 0;
            // 
            // ckbKhongDaoCauHoi
            // 
            this.ckbKhongDaoCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbKhongDaoCauHoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbKhongDaoCauHoi.Location = new System.Drawing.Point(932, 3);
            this.ckbKhongDaoCauHoi.Name = "ckbKhongDaoCauHoi";
            this.ckbKhongDaoCauHoi.Size = new System.Drawing.Size(129, 24);
            this.ckbKhongDaoCauHoi.TabIndex = 7;
            this.ckbKhongDaoCauHoi.Text = "Không đảo câu hỏi";
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCauHoi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCauHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.lblCauHoi.Location = new System.Drawing.Point(3, 0);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(923, 30);
            this.lblCauHoi.TabIndex = 0;
            this.lblCauHoi.Text = "Câu hỏi";
            this.lblCauHoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtCtrlNoiDungCauHoi.IsEnableUnderlineKey = true;
            this.txtCtrlNoiDungCauHoi.Location = new System.Drawing.Point(8, 33);
            this.txtCtrlNoiDungCauHoi.Name = "txtCtrlNoiDungCauHoi";
            this.txtCtrlNoiDungCauHoi.Size = new System.Drawing.Size(1058, 226);
            this.txtCtrlNoiDungCauHoi.TabIndex = 9;
            this.txtCtrlNoiDungCauHoi.Text = "";
            // 
            // tblPanelMain
            // 
            this.tblPanelMain.AutoScroll = true;
            this.tblPanelMain.AutoSize = true;
            this.tblPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.tblPanelMain.ColumnCount = 1;
            this.tblPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelMain.Controls.Add(this.pmtPanelRoot, 0, 1);
            this.tblPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelMain.Location = new System.Drawing.Point(0, 295);
            this.tblPanelMain.Name = "tblPanelMain";
            this.tblPanelMain.RowCount = 2;
            this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblPanelMain.Size = new System.Drawing.Size(1069, 169);
            this.tblPanelMain.TabIndex = 2;
            // 
            // pmtPanelRoot
            // 
            this.pmtPanelRoot.BackColor = System.Drawing.Color.Transparent;
            this.pmtPanelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pmtPanelRoot.Location = new System.Drawing.Point(3, 8);
            this.pmtPanelRoot.Name = "pmtPanelRoot";
            this.pmtPanelRoot.Size = new System.Drawing.Size(1063, 158);
            this.pmtPanelRoot.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UcTracNghiemDon
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblPanelMain);
            this.Controls.Add(this.secTableLayoutPanel1);
            this.Name = "UcTracNghiemDon";
            this.Size = new System.Drawing.Size(1069, 464);
            this.secTableLayoutPanel1.ResumeLayout(false);
            this.pmtTableLayoutPanel3.ResumeLayout(false);
            this.pmtTableLayoutPanel3.PerformLayout();
            this.pmtTableLayoutPanel1.ResumeLayout(false);
            this.pmtTableLayoutPanel1.PerformLayout();
            this.tblPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private TableLayoutPanel secTableLayoutPanel1;
        private TableLayoutPanel pmtTableLayoutPanel1;
        private CheckBox ckbKhongDaoCauHoi;
        private Label lblCauHoi;
        private TableLayoutPanel tblPanelMain;
        private Panel pmtPanelRoot;
        private TableLayoutPanel pmtTableLayoutPanel3;
        private Label pmtTitleLabel4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private EditorControl txtCtrlNoiDungCauHoi;
        private DevExpress.XtraEditors.SimpleButton btnThemCauTraLoi;
    }
}
