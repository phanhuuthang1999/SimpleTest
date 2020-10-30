using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using System;

namespace SimpleTest.Controls
{
    public class LookUpEditEx : LookUpEdit
    {
        public LookUpEditEx()
        {
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LookUpEditEx1";
            this.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Properties.Appearance.Options.UseFont = true;
            this.Properties.AutoHeight = false;
            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Size = new System.Drawing.Size(200, 22);
            this.Properties.NullText = "";
            this.KeyUp += LookUpEditEx_KeyUp;
        }

        private void LookUpEditEx_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Back || e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                this.EditValue = null;
                e.Handled = true;
            }
        }

        public void SetData<T>(List<T> lstData, List<LookUpEditItem> pLstColumn, string pDisplayMember, string pValueMember)
        {
            var lstColumnAdd = new List<LookUpColumnInfo>();
            pLstColumn.ForEach(m => lstColumnAdd.Add(new LookUpColumnInfo(m.ColumnName, m.ColumnCaption)));
            this.Properties.Columns.Clear();
            this.Properties.Columns.AddRange(lstColumnAdd.ToArray());

            this.Properties.DataSource = lstData;
            this.Properties.DisplayMember = pDisplayMember;
            this.Properties.ValueMember = pValueMember;
        }

        public long? CategoryID
        {
            get
            {
                if (this.EditValue == null) return null;
                return Convert.ToInt32(this.EditValue);
            }
            set { this.EditValue = (long?)value; }
        }

    }

    public class LookUpEditItem
    {
        public string ColumnName { get; set; }
        public string ColumnCaption { get; set; }
    }


}
