using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SimpleTest.Common;
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
    public partial class E000015 : FormBase
    {
        #region Variable

        private CauHoiBll _busCauHoi = new CauHoiBll();
        private List<EX_CauHoi> _lstCauHoiRight = new List<EX_CauHoi>();

        #endregion

        #region Constructor

        public E000015()
        {
            InitializeComponent();
        }

        #endregion

        #region Private


        #endregion


    }
}
