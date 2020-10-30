using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Common
{
    public static class Cache
    {
        #region Variable

        private static DataLayer.DAL.DataEntities _context = new DataLayer.DAL.DataEntities();


        #endregion

        #region Public

        public static void CreateNewContex()
        {
            Context = new DataEntities();
        }

        #endregion

        #region Properties

        public static DataEntities Context
        {
            get { return _context; }
            set { _context = value; }
        }

        #endregion

        #region CacheDanhMuc

        private static SortedList<string, dynamic> _cacheDanhMuc = new SortedList<string, dynamic>();
        private static DateTime? _dtServer = null;
        public static Action<Type> UpdatedDanhMuc = null;
        private static TimeSpan? _gioKhoaSo = null;
        public static Dictionary<string, List<object>> DataDanhMuc = new Dictionary<string, List<object>>();

        //private static List<Type> _commonCache = new List<Type>()
        //{
        //    typeof(View_ThongTin),
        //    typeof(View_Khoa),
        //    typeof(View_KhoaFull),
        //    typeof(View_BieuMau),

        //};

        #endregion
    }
}
