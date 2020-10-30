using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataLayer.BLL;

namespace SimpleTest.UserControls
{
    public partial class UC_MonHoc2 : DevExpress.XtraEditors.XtraUserControl
    {
        private DanhMucBll _bus = new DanhMucBll();
        public UC_MonHoc2()
        {
            InitializeComponent();

            gridControl.DataSource = _bus.GetDanhSachMonHoc(txtMaMonHoc.Text, txtTenMonHoc.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
