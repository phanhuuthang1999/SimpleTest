using System.Drawing;
using System.ComponentModel;

namespace SimpleTest.Controls
{
    public class LabelEx : System.Windows.Forms.Label
    {
        private bool _isRequired = false;

        public LabelEx()
        {
            this.BackColor = Color.Transparent;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.AutoSize = false;
            this.Margin = new System.Windows.Forms.Padding(2);
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_isRequired)
            {
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    // Font
                    Font font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                    float width = e.Graphics.MeasureString(this.Text, this.Font).Width + 12;

                    // Create new string format
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Center;

                    // Draw string
                    e.Graphics.DrawString("*", font, brush, new RectangleF(0, 0, width, this.Height), format);
                }
            }
        }
    }
}
