using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SimpleTest.Controls
{
    public partial class CaptureCT : Form
    {
        #region Variable

        public delegate void captureEventDelegate(bool capture);
        public event captureEventDelegate OnCaptureEvent;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        private Capture frmCapture = null;
        ContextMenu m_menu = null;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private Form m_InstanceRef = null;
        public Form InstanceRef
        {
            get { return m_InstanceRef; }
            set { m_InstanceRef = value; }
        }
        #endregion

        #region Constructor

        public CaptureCT()
        {
            InitializeComponent();
        }

        #endregion

        #region Private

        private void DoCapture()
        {
            if ((frmCapture != null) && !frmCapture.Visible)
            {
                // clean up the screen cap form by closing and re-instantiating (quick down and dirty)

                frmCapture.Dispose();
                frmCapture = null;

                frmCapture = new Capture();
                frmCapture.InstanceRef = this;
            }
            else if (frmCapture == null)
            {
                frmCapture = new Capture();
                frmCapture.InstanceRef = this;
            }

            this.Hide();
            Application.DoEvents();
            frmCapture.OnCaptureEvent += frmCapture_OnCaptureEvent;
            if (frmCapture.Visible) { }
            else
                frmCapture.Show();

        }

        private void frmCapture_OnCaptureEvent(bool capture)
        {
            if (OnCaptureEvent != null)
                OnCaptureEvent(capture);
        }


        #endregion

        #region Event

        private void bttCaptureArea_Click(object sender, EventArgs e)
        {
            DoCapture();
        }

        private void CaptureCT_Load(object sender, EventArgs e)
        {
            System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
            Byte[] buffer = new byte[] { (byte)149 };
            string bullet = System.Text.Encoding.GetEncoding(1252).GetString(buffer);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}

