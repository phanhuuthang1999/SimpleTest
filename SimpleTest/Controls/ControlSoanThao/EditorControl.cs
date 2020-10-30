using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleTest.Controls
{
    public partial class EditorControl : RichTextBox
    {
        #region Variable

        private Font _defaultFont = new Font("Times New Roman", 12, FontStyle.Regular);
        private Font _defaultSubFont = new Font("Times New Roman", 8, FontStyle.Regular);
        private bool _isEnableUnderlineKey = true;

        #endregion

        #region Constructor

        public EditorControl():base()
        {
            InitializeComponent();
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Font = _defaultFont;
            this.BorderStyle = BorderStyle.None;
            this.EnableAutoDragDrop = true;
            this.AutoWordSelection = false;
            this.SelectionIndent = 5;
            mnCopy.Click += MnCopy_Click;
            mnCut.Click += MnCut_Click;
            mnPaste.Click += MnPaste_Click;
            mnDelete.Click += MnDelete_Click;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(On_KeyPress);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);

        #endregion

        #region Protectted

        #region Border 1

        //private const UInt32 WM_PAINT = 0x000F;
        //private const UInt32 WM_USER = 0x0400;
        //private const UInt32 EM_SETBKGNDCOLOR = (WM_USER + 67);
        //private const UInt32 WM_KILLFOCUS = 0x0008;

        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    base.WndProc(ref m);

        //    Graphics g = Graphics.FromHwnd(Handle);
        //    Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
        //    Pen p = new Pen(SystemColors.Highlight, 1);

        //    if (m.Msg == WM_PAINT)
        //    {
        //        if (this.Enabled == true)
        //        {

        //            if (this.Focused)
        //            {
        //                g.DrawRectangle(p, bounds);
        //            }

        //            else
        //            {
        //                g.DrawRectangle(SystemPens.ControlDark, bounds);
        //            }

        //        }
        //        else
        //        {
        //            g.FillRectangle(Brushes.White, bounds);
        //            g.DrawRectangle(SystemPens.Control, bounds);
        //        }
        //    }

        //    if (m.Msg == EM_SETBKGNDCOLOR) //color disabled background
        //    {
        //        Invalidate();
        //    }

        //    if (m.Msg == WM_KILLFOCUS) //set border back to normal on lost focus
        //    {
        //        Invalidate();
        //    }
        //}

        #endregion

        #region Border2

        NativeMethods.RECT borderRect;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_NCPAINT: // the border painting is done here.
                    WmNcpaint(ref m);
                    break;
                case NativeMethods.WM_NCCALCSIZE: // the size of the client area is calcuated here.
                    WmNccalcsize(ref m);
                    break;
                case NativeMethods.WM_THEMECHANGED: // Updates styles when the theme is changing.
                    UpdateStyles();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Calculates the size of the window frame and client area of the RichTextBox
        /// </summary>
        private void WmNccalcsize(ref Message m)
        {
            // let the richtextbox control draw the scrollbar if necessary.
            base.WndProc(ref m);

            // we visual styles are not enabled and BorderStyle is not Fixed3D then we have nothing more to do.
            if (!this.RenderWithVisualStyles())
                return;

            // contains detailed information about WM_NCCALCSIZE message
            NativeMethods.NCCALCSIZE_PARAMS par = new NativeMethods.NCCALCSIZE_PARAMS();

            // contains the window frame RECT
            NativeMethods.RECT windowRect;

            if (m.WParam == IntPtr.Zero) // LParam points to a RECT struct
            {
                windowRect = (NativeMethods.RECT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.RECT));
            }
            else // LParam points to a NCCALCSIZE_PARAMS struct
            {
                par = (NativeMethods.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));
                windowRect = par.rgrc0;
            }

            // contains the client area of the control
            NativeMethods.RECT contentRect;

            // get the DC
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // open theme data
            IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // find out how much space the borders needs
            if (NativeMethods.GetThemeBackgroundContentRect(hTheme, hDC, NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL
                , ref windowRect
                , out contentRect) == NativeMethods.S_OK)
            {
                // shrink the client area the make more space for containing text.
                contentRect.Inflate(-1, -1);

                // remember the space of the borders
                this.borderRect = new NativeMethods.RECT(contentRect.Left - windowRect.Left
                    , contentRect.Top - windowRect.Top
                    , windowRect.Right - contentRect.Right
                    , windowRect.Bottom - contentRect.Bottom);

                // update LParam of the message with the new client area
                if (m.WParam == IntPtr.Zero)
                {
                    Marshal.StructureToPtr(contentRect, m.LParam, false);
                }
                else
                {
                    par.rgrc0 = contentRect;
                    Marshal.StructureToPtr(par, m.LParam, false);
                }

                // force the control to redraw it´s client area
                m.Result = new IntPtr(NativeMethods.WVR_REDRAW);
            }

            // release theme data handle
            NativeMethods.CloseThemeData(hTheme);

            // release DC
            NativeMethods.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// The border painting is done here.
        /// </summary>
        private void WmNcpaint(ref Message m)
        {
            base.WndProc(ref m);

            if (!this.RenderWithVisualStyles())
            {
                return;
            }

            /////////////////////////////////////////////////////////////////////////////
            // Get the DC of the window frame and paint the border using uxTheme API´s
            /////////////////////////////////////////////////////////////////////////////

            // set the part id to TextBox
            int partId = NativeMethods.EP_EDITTEXT;

            // set the state id of the current TextBox
            int stateId;
            if (this.Enabled)
                if (this.ReadOnly)
                    stateId = NativeMethods.ETS_READONLY;
                else
                    stateId = NativeMethods.ETS_NORMAL;
            else
                stateId = NativeMethods.ETS_DISABLED;

            // define the windows frame rectangle of the TextBox
            NativeMethods.RECT windowRect;
            NativeMethods.GetWindowRect(this.Handle, out windowRect);
            windowRect.Right -= windowRect.Left; windowRect.Bottom -= windowRect.Top;
            windowRect.Top = windowRect.Left = 0;

            // get the device context of the window frame
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // define a rectangle inside the borders and exclude it from the DC
            NativeMethods.RECT clientRect = windowRect;
            clientRect.Left += this.borderRect.Left;
            clientRect.Top += this.borderRect.Top;
            clientRect.Right -= this.borderRect.Right;
            clientRect.Bottom -= this.borderRect.Bottom;
            NativeMethods.ExcludeClipRect(hDC, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);

            // open theme data
            IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // make sure the background is updated when transparent background is used.
            if (NativeMethods.IsThemeBackgroundPartiallyTransparent(hTheme
                , NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL) != 0)
            {
                NativeMethods.DrawThemeParentBackground(this.Handle, hDC, ref windowRect);
            }

            // draw background
            NativeMethods.DrawThemeBackground(hTheme, hDC, partId, stateId, ref windowRect, IntPtr.Zero);

            // close theme data
            NativeMethods.CloseThemeData(hTheme);

            // release dc
            NativeMethods.ReleaseDC(this.Handle, hDC);

            // we have processed the message so set the result to zero
            m.Result = IntPtr.Zero;
        }

        /// <summary>
        /// Returns true, when visual styles are enabled in this application.
        /// </summary>
        private bool VisualStylesEnabled()
        {
            // Check if RenderWithVisualStyles property is available in the Application class (New feature in NET 2.0)
            Type t = typeof(Application);
            System.Reflection.PropertyInfo pi = t.GetProperty("RenderWithVisualStyles");

            if (pi == null)
            {
                // NET 1.1
                OperatingSystem os = System.Environment.OSVersion;
                if (os.Platform == PlatformID.Win32NT && (((os.Version.Major == 5) && (os.Version.Minor >= 1)) || (os.Version.Major > 5)))
                {
                    NativeMethods.DLLVersionInfo version = new NativeMethods.DLLVersionInfo();
                    version.cbSize = Marshal.SizeOf(typeof(NativeMethods.DLLVersionInfo));
                    if (NativeMethods.DllGetVersion(ref version) == 0)
                    {
                        return (version.dwMajorVersion > 5) && NativeMethods.IsThemeActive() && NativeMethods.IsAppThemed();
                    }
                }

                return false;
            }
            else
            {
                // NET 2.0
                bool result = (bool)pi.GetValue(null, null);
                return result;
            }
        }

        /// <summary>
        /// Return true, when this control should render with visual styles.
        /// </summary>
        /// <returns></returns>
        private bool RenderWithVisualStyles()
        {
            return this.BorderStyle == BorderStyle.FixedSingle && this.VisualStylesEnabled();
        }

        /// <summary>
        /// Update the control parameters.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;

                // remove the Fixed3D border style
                if (this.RenderWithVisualStyles() && (p.ExStyle & NativeMethods.WS_EX_CLIENTEDGE) == NativeMethods.WS_EX_CLIENTEDGE)
                    p.ExStyle ^= NativeMethods.WS_EX_CLIENTEDGE;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    p.ClassName = "RICHEDIT50W";
                }
                return p;
            }
        }

        #endregion

        #endregion

        #region Private

        #endregion

        #region Public

        public bool IsBold()
        {
            if (this.CanFocus && this.SelectionFont != null)
                return this.SelectionFont.Bold;
            else
                return false;
        }

        public void Bold()
        {
            if (this.SelectionFont == null) return;
            Font new1, old1;
            old1 = this.SelectionFont;
            if (old1.Bold)
                new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Bold);

            this.SelectionFont = new1;
            this.Focus();
        }

        public bool IsItalic()
        {
            if (this.CanFocus && this.SelectionFont != null)
                return this.SelectionFont.Italic;
            else
                return false;
        }

        public void Italic()
        {
            Font new1, old1;
            old1 = this.SelectionFont;
            if (old1.Italic)
                new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Italic);

            this.SelectionFont = new1;
            this.Focus();
        }

        public bool IsUnderline()
        {
            if (this.CanFocus && this.SelectionFont != null)
                return this.SelectionFont.Underline;
            else
                return false;
        }

        public void Underline()
        {
            Font new1, old1;
            old1 = this.SelectionFont;
            if (old1 != null)
            {
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);

                this.SelectionFont = new1;
                this.Focus();
            }
        }

        public bool IsJustifyLeft()
        {
            if (this.CanFocus && this.SelectionLength > 0)
                return this.SelectionAlignment == HorizontalAlignment.Left;
            return false;
        }

        public void JustifyLeft()
        {
            if (this.SelectionAlignment != HorizontalAlignment.Left)
                this.SelectionAlignment = HorizontalAlignment.Left;
        }

        public bool IsJustifyRight()
        {
            if (this.CanFocus && this.SelectionLength > 0)
                return this.SelectionAlignment == HorizontalAlignment.Right;
            return false;
        }

        public void JustifyRight()
        {
            if (this.SelectionAlignment == HorizontalAlignment.Right)
                this.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.SelectionAlignment = HorizontalAlignment.Right;
        }

        public bool IsJustifyCenter()
        {
            if (this.CanFocus && this.SelectionLength > 0)
                return this.SelectionAlignment == HorizontalAlignment.Center;
            return false;
        }

        public void JustifyCenter()
        {
            if (this.SelectionAlignment == HorizontalAlignment.Center)
                this.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.SelectionAlignment = HorizontalAlignment.Center;
        }

        public bool IsSubscript()
        {
            return this.SelectionCharOffset < 0;
        }

        public void Subscript()
        {
            if (this.SelectionCharOffset >= 0)
            {
                this.SelectionFont = _defaultSubFont;
                this.SelectionCharOffset = -5;
            }
            else
            {
                this.SelectionFont = _defaultFont;
                this.SelectionCharOffset = 0;
            }
        }

        public bool IsSuperscript()
        {
            return this.SelectionCharOffset > 0;
        }

        public void Superscript()
        {
            if (this.SelectionCharOffset <= 0)
            {
                this.SelectionFont = _defaultSubFont;
                this.SelectionCharOffset = 5;
            }
            else
            {
                this.SelectionFont = _defaultFont;
                this.SelectionCharOffset = 0;
            }
        }

        public void InsertImage()
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Images |*.bmp;*.jpg;*.png;*.gif;*.ico";
            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                Clipboard.SetImage(img);
                this.Paste();
                this.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        public void InsertImageClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                var image = Clipboard.GetImage();
                if (image != null)
                {
                    this.Paste();
                    this.Focus();
                }
            }
        }

        #endregion

        #region Properties

        public Font EditorFont
        {
            get
            {
                var fontN = this.SelectionFont;
                if (fontN == null) return null;
                return fontN;
            }
            set
            {
                if (value != null)
                    this.SelectionFont = value;
                else
                    this.SelectionFont = _defaultFont;
            }
        }

        public Color EditorForeColor
        {
            get
            {
                return this.SelectionColor;
            }
            set
            {
                this.SelectionColor = value;
            }
        }

        public Color EditorBackColor
        {
            get
            {
                return this.SelectionBackColor;
            }
            set
            {
                this.SelectionBackColor = value;
            }
        }

        //public string HTML
        //{
        //    get { return GetHTML(); }
        //}

        public bool IsEmpty
        {
            get { return this.Text.Length == 0 && !this.Rtf.Contains(@"\object") && !this.Rtf.Contains(@"\pic"); }

        }

        //[Browsable(true)]
        //public bool ShowMenuEdit
        //{
        //    set
        //    {
        //        if (value)
        //        {
        //            this.mnEdit.Visible = true;
        //            this.toolStripSeparator5.Visible = true;
        //        }
        //        else
        //        {
        //            this.mnEdit.Visible = false;
        //            this.toolStripSeparator5.Visible = false;
        //        }
        //    }
        //}

        [Browsable(true)]
        public bool ShowContexMenu
        {
            set
            {
                if (value) this.ContextMenuStrip = contextMenuStrip1;
                else this.ContextMenuStrip = null;
            }
        }

        [Browsable(true)]
        public bool IsEnableUnderlineKey
        {
            get { return _isEnableUnderlineKey; }
            set { _isEnableUnderlineKey = value; }
        }

        #endregion

        #region Event

        #region ContextMenu

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!this.Enabled || this.ReadOnly)
            {
                mnCut.Enabled = mnDelete.Enabled = mnPaste.Enabled = false;
            }
            else
            {
                mnCut.Enabled = this.SelectionLength > 0;
                mnDelete.Enabled = this.SelectionLength > 0;
                mnPaste.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
                //mnEdit.Enabled = true;
            }
            mnCopy.Enabled = this.SelectionLength > 0;
        }

        private void MnEdit_Click(object sender, EventArgs e)
        {
            //EditDataEx frm = new EditDataEx(this.Rtf);
            //if (frm.ShowDialog() == DialogResult.Yes)
            //{
            //    this.Rtf = frm.RTF;
            //}
            //frm.Dispose();
        }

        private void MnDelete_Click(object sender, EventArgs e)
        {
            this.SelectedText = "";
        }

        private void MnPaste_Click(object sender, EventArgs e)
        {
            this.Paste(DataFormats.GetFormat("Text"));
        }

        private void MnCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void MnCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        #endregion

        #region Keyboard Handler

        private void On_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.B:
                        this.Bold();
                        break;
                    case Keys.I:
                        this.Italic();
                        break;
                    case Keys.S:
                        e.Handled = true;
                        break;
                    case Keys.U:
                        if (IsEnableUnderlineKey)
                            Underline();
                        else
                            e.Handled = true;
                        break;
                    case Keys.OemMinus:
                        e.Handled = true;
                        break;
                }
            }

            if (e.KeyCode == Keys.Tab)
                this.SelectedText = "\t";
        }

        private void On_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 9)
                e.Handled = true; // Stops Ctrl+I from inserting a tab (char HT) into the richtextbox
        }

        #endregion

        #endregion
    }

    #region Navigate

    internal sealed class NativeMethods
    {
        static NativeMethods()
        {
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("gdi32.dll")]
        public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect);


        [StructLayout(LayoutKind.Sequential)]
        public struct DLLVersionInfo
        {
            public int cbSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformID;
        }

        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsAppThemed();

        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsThemeActive();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern int DllGetVersion(ref DLLVersionInfo version);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 CloseThemeData(IntPtr hTheme);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
            int iStateId, ref RECT pRect, IntPtr pClipRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static int IsThemeBackgroundPartiallyTransparent(IntPtr hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc
            , int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref RECT pRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
            int iStateId, ref RECT pRect, ref RECT pClipRect);

        public const int S_OK = 0x0;

        public const int EP_EDITTEXT = 1;
        public const int ETS_DISABLED = 4;
        public const int ETS_NORMAL = 1;
        public const int ETS_READONLY = 6;

        public const int WM_THEMECHANGED = 0x031A;
        public const int WM_NCPAINT = 0x85;
        public const int WM_NCCALCSIZE = 0x83;

        public const int WS_EX_CLIENTEDGE = 0x200;
        public const int WVR_HREDRAW = 0x100;
        public const int WVR_VREDRAW = 0x200;
        public const int WVR_REDRAW = (WVR_HREDRAW | WVR_VREDRAW);

        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0, rgrc1, rgrc2;
            public IntPtr lppos;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left_, int top_, int right_, int bottom_)
            {
                Left = left_;
                Top = top_;
                Right = right_;
                Bottom = bottom_;
            }

            public int Height { get { return Bottom - Top + 1; } }
            public int Width { get { return Right - Left + 1; } }
            public Size Size { get { return new Size(Width, Height); } }

            public Point Location { get { return new Point(Left, Top); } }

            // Handy method for converting to a System.Drawing.Rectangle
            public Rectangle ToRectangle()
            { return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }

            public void Inflate(int width, int height)
            {
                this.Left -= width;
                this.Top -= height;
                this.Right += width;
                this.Bottom += height;
            }

            public override int GetHashCode()
            {
                return Left ^ ((Top << 13) | (Top >> 0x13))
                    ^ ((Width << 0x1a) | (Width >> 6))
                    ^ ((Height << 7) | (Height >> 0x19));
            }

            #region Operator overloads

            public static implicit operator Rectangle(RECT rect)
            {
                return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }

            public static implicit operator RECT(Rectangle rect)
            {
                return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }

            #endregion
        }
    }

    #endregion
}
