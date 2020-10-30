using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public partial class EX_Phan
    {
        private string _maMonHoc = "";
        private string _tenMonHoc = "";
        private string _maKhoiLop = "";
        private string _tenKhoiLop = "";
        [NotMapped]
        public string MaMonHoc
        {
            get { return _maMonHoc; }
            set { _maMonHoc = value; }
        }
        [NotMapped]
        public string TenMonHoc
        {
            get { return _tenMonHoc; }
            set { _tenMonHoc = value; }
        }
        [NotMapped]
        public string MaKhoiLop
        {
            get { return _maKhoiLop; }
            set { _maKhoiLop = value; }
        }
        [NotMapped]
        public string TenKhoiLop { get { return _tenKhoiLop; } set { _tenKhoiLop = value; } }

        public void GetThongTinMonHoc()
        {
            var mh = Cache.Context.EX_MonHoc.FirstOrDefault(m => m.Id == IDMonHoc);
            if (mh != null)
            {
                mh.GetThongTinKhoiLop();
                MaKhoiLop = mh.MaKhoiLop;
                TenKhoiLop = mh.TenKhoiLop;
                MaMonHoc = mh.MaMonHoc;
                TenMonHoc = mh.TenMonHoc;
            }
        }
    }
}
