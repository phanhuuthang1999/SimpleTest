using DevExpress.XtraBars.Ribbon;
using SimpleTest.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTest.Forms
{
    public partial class FormBase : DevExpress.XtraEditors.XtraForm
    {

        #region Variable

        #endregion

        #region Constructor

        public FormBase()
        {
            InitializeComponent();

            TsbTimKiem = new ToolStriptButton();
            TsbTimKiem.Name = "tsbTimKiem";
            TsbTimKiem.Type = Common.StructEnum.Enum_ToolstripButtonType.TimKiem;

            TsbThem = new ToolStriptButton();
            TsbThem.Name = "tsbThem";
            TsbThem.Type = Common.StructEnum.Enum_ToolstripButtonType.Them;

            TsbSua = new ToolStriptButton();
            TsbSua.Name = "tsbSua";
            TsbSua.Type = Common.StructEnum.Enum_ToolstripButtonType.Sua;

            TsbXoa = new ToolStriptButton();
            TsbXoa.Name = "tsbXoa";
            TsbXoa.Type = Common.StructEnum.Enum_ToolstripButtonType.Xoa;

            TsbDong = new ToolStriptButton();
            TsbDong.Name = "tsbDong";
            TsbDong.Type = Common.StructEnum.Enum_ToolstripButtonType.Dong;

            // Định nghĩa các nút trên form
            Group.Name = "rbgCn";
            Group.Text = "Chức năng chung";

            Group.ItemLinks.AddRange(new ToolStriptButton[] { TsbTimKiem, TsbThem, TsbSua, TsbXoa, TsbDong });

            #region AddEvent

            TsbDong.ItemClick += TsbDong_ItemClick;

            #endregion
        } 

        #endregion

        #region Event

        private void TsbDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Properties

        public ToolStriptButton TsbTimKiem { get; set; }
        public ToolStriptButton TsbThem { get; set; }
        public ToolStriptButton TsbSua { get; set; }
        public ToolStriptButton TsbXoa { get; set; }
        public ToolStriptButton TsbDong { get; set; }
        public RibbonPageGroup Group { get; set; } = new RibbonPageGroup();

        #endregion
    }
}
