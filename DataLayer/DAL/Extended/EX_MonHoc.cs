using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public partial class EX_MonHoc
    {
        private string _maKhoiLop = "";
        private string _tenKhoiLop = "";
        [NotMapped]
        public string MaKhoiLop { get { return _maKhoiLop; } set { _maKhoiLop = value; } }
        [NotMapped]
        public string TenKhoiLop { get { return _tenKhoiLop; } set { _tenKhoiLop = value; } }

        public void GetThongTinKhoiLop()
        {
            var kl = Cache.Context.EX_KhoiLop.FirstOrDefault(m => m.Id == IDKhoiLop);
            if (kl != null)
            {
                MaKhoiLop = kl.MaKhoiLop;
                TenKhoiLop = kl.TenKhoiLop;
            }
        }
    }
}
