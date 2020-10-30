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
using EventAggregator;

namespace SimpleTest.UserControls
{
    public partial class UC_KhoiLop : DevExpress.XtraEditors.XtraUserControl, ISubscriber<Button>
    {
        public UC_KhoiLop(IEventAggregator subscriber)
        {
            InitializeComponent();
            subscriber.SubsribeEvent(this);
            EventAggregator = subscriber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EventAggregator != null)
                this.EventAggregator.PublishEvent(button1);
        }

        public void OnEventHandler(Button e)
        {
            label1.Text = "Dang hiển thị nút" + e.Text;
        }

        public IEventAggregator EventAggregator
        {
            get;
            set;
        }
    }
}
