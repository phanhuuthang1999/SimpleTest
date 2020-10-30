using DevExpress.XtraBars;
using SimpleTest.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleTest.Common.StructEnum;

namespace SimpleTest.Controls
{
    public partial class ToolStriptButton : BarButtonItem
    {
        #region Private

        private Enum_ToolstripButtonType _type = Enum_ToolstripButtonType.None;
        private PermissionTypes _permissionType = PermissionTypes.TOOLSTRIPTYPE;

        #endregion

        #region Constructor

        public ToolStriptButton()
        {
            InitializeComponent();
        }

        #endregion

        #region Private

        private void SetImage(Enum_ToolstripButtonType type)
        {
            if (type == Enum_ToolstripButtonType.None)
            {
                this.ImageOptions.Image = null;
                this.ImageOptions.LargeImage = null;
                return;
            }

            this.ImageOptions.LargeImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("tsb" + type.ToString());
            this.ImageOptions.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("tsb" + type.ToString() + "_16");
        }

        private void SetCaptionText(Enum_ToolstripButtonType type)
        {
            this.Caption = type.GetDescription();
        }

        #endregion


        #region Properties


        [DefaultValue(Enum_ToolstripButtonType.None)]
        public Enum_ToolstripButtonType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                SetImage(_type);
                SetCaptionText(_type);
            }
        }

        public PermissionTypes PermissionType
        {
            get { return _permissionType; }
            set { _permissionType = value; }
        }

        #endregion
    }
}
