using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public partial class EX_Chuong
    {
        private string _maMonHoc = "";
        private string _tenMonHoc = "";
        private string _maPhan = "";
        private string _tenPhan = "";

        [NotMapped]
        public string MaMonHoc { get { return _maMonHoc; } set { _maMonHoc = value; } }
        [NotMapped]
        public string TenMonHoc { get { return _tenMonHoc; } set { _tenMonHoc = value; } }
        [NotMapped]
        public string MaPhan { get { return _maPhan; } set { _maPhan = value; } }
        [NotMapped]
        public string TenPhan { get { return _tenPhan; } set { _tenPhan = value; } }

        public void GetThongTinPhan()
        {
            var ph = Cache.Context.EX_Phan.FirstOrDefault(m => m.Id == IDPhan);
            if (ph != null)
            {
                MaPhan = ph.MaPhan;
                TenPhan = ph.TenPhan;
            }
        }

        public void GetThongTinMonHoc()
        {
            var ph = Cache.Context.EX_MonHoc.FirstOrDefault(m => m.Id == IDMonHoc);
            if (ph != null)
            {
                MaMonHoc = ph.MaMonHoc;
                TenMonHoc = ph.TenMonHoc;
            }
        }
    }
}
