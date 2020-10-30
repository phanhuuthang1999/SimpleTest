using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
namespace PMT.EMS.Controls
{
    [System.Diagnostics.DebuggerNonUserCode()]
    public class TextBoxEx : DevExpress.XtraEditors.TextEdit
    {
        private bool _onlyNumberEnter = false;       

        #region Contructors

        public TextBoxEx()
        {
            this.Margin = new Padding(2);
            this.Properties.AutoHeight = false;
            this.Size = new System.Drawing.Size(300, 22);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        #endregion

        #region Override Methods

        protected override void OnSizeChanged(System.EventArgs e)
        {
            if (this.BorderStyle != DevExpress.XtraEditors.Controls.BorderStyles.Default)
            {
                //this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //this.BorderColor = ControlsSettings.BorderColor;
            }

            base.OnSizeChanged(e);
        }

        protected override void OnBindingContextChanged(System.EventArgs e)
        {
            foreach (System.Windows.Forms.Binding bin in this.DataBindings)
            {
                // Binding text
                if (bin.PropertyName == "Text")
                {
                    // Set null value is empty string
                    bin.NullValue = "";
                }
            }

            base.OnBindingContextChanged(e);
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text) &&
                e.KeyChar == ' ')
            {
                e.Handled = true;
            }

            if (_onlyNumberEnter == true)
            {
                if (char.IsLetter(e.KeyChar) ||
                    char.IsSymbol(e.KeyChar) ||
                    char.IsWhiteSpace(e.KeyChar) ||
                    char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            base.OnKeyPress(e);
        }

        #endregion

        #region Properties

        public override string Text
        {
            get
            {
                return base.Text.TrimEnd().TrimStart();
            }
            set
            {
                base.Text = value;
            }
        }

        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;

                this.BackColor = value ? System.Drawing.SystemColors.Control : System.Drawing.SystemColors.Window;
            }
        }

        [Browsable(true)]
        [Category("Number Only")]
        public bool OnlyNumberEnter
        {
            get { return _onlyNumberEnter; }
            set { _onlyNumberEnter = value; }
        }

        #endregion
    }
}
