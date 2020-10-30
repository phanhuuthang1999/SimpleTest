using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleTest
{
    public partial class MainTest : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // 2 con trol hien thi ben trong
        XtraUserControl ucMonHoc;
        XtraUserControl uckl;

        #region Constructor

        public MainTest()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            tabbedView.DocumentProperties.AllowPin = true;
            documentManager1.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
        }

        private XtraUserControl CreateNewControl(XtraUserControl control, string text)
        {
            control.Dock = DockStyle.Fill;
            XtraUserControl result = new XtraUserControl();
            result.Controls.Add(control);
            result.Text = text;
            return result;
        }

        #endregion

        #region Event

        
        private void btnKhoiLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (uckl == null || uckl.IsDisposed)
            //{
            //    IEventAggregator ea = new EventAggregator.EventAggregator();
            //    uckl = CreateNewControl(new UC_KhoiLop(ea), "Danh mục khối lớp");
            //    tabbedView.AddDocument(uckl);
            //}
            //tabbedView.ActivateDocument(uckl);
        }

        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (ucMonHoc == null || ucMonHoc.IsDisposed)
            //{
            //    ucMonHoc = CreateNewControl(new UC_MonHoc(), "Danh mục môn học");
            //    tabbedView.AddDocument(ucMonHoc);
            //}
            //tabbedView.ActivateDocument(ucMonHoc);
        }

        #endregion

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void MainTest_Load(object sender, EventArgs e)
        {

        }
    }
}
