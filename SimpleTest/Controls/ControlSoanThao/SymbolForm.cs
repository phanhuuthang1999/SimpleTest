using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTest.Forms
{
    /// <summary>
    /// TrongNghia
    /// 17/10/2018
    /// </summary>
    public partial class SymbolForm : FormBase
    {
        #region Variable

        public delegate void OnSelectSymbol();
        public event OnSelectSymbol OnSelectedSymbol;

        private char[] _specialSymbols = new char[]
        {
            '\u03b1','\u03b2','\u03b3','\u03b4','\u03b5','\u03b6','\u03b7','\u03b8','\u03b9','\u03ba','\u03bb','\u03bc','\u03be',
            '\u03c0','\u03c1','\u03c2','\u03c3','\u03c4','\u03c5','\u03c6','\u03c7','\u03c8','\u03c9','\u03f4','\u03f5','\u03f6','\u03a0',
            '\u0393','\u0394','\u039f','\u03a6','\u0398','\u039b','\u039e','\u03a9','\u03d2','\u03d5','\u03ed','\u03a3',
            '≡','±','≤','≥','÷','≈','√','∞','¥'
        };

        #endregion

        #region Constructor

        public SymbolForm()
        {
            InitializeComponent();

            #region Symbol

            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Leave += flowLayoutPanel1_Leave;
            for (int i = 0; i < _specialSymbols.Count(); i++)
            {
                Button button = new Button();
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(0);
                button.Text = _specialSymbols[i].ToString();
                button.Font = new Font(button.Font.FontFamily, 11F, FontStyle.Regular);
                button.Size = new Size(25, 25);
                button.Tag = i;
                button.Click += Symbol_Click;

                if ((i + 1) % 8 == 0) flowLayoutPanel1.SetFlowBreak(button, true);

                flowLayoutPanel1.Controls.Add(button);
            }

            #endregion
        }

        #endregion

        #region Event

        private void Symbol_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Clipboard.SetText(_specialSymbols[Convert.ToInt32(button?.Tag)].ToString());
            OnSelectedSymbol?.Invoke();
        }

        private void flowLayoutPanel1_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

