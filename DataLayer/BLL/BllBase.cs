using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;

namespace DataLayer.BLL
{
    public class BllBase
    {
        private DataLayer.DAL.DataEntities _context;
        public BllBase()
        {
            Context = new DAL.DataEntities();
        }

        public DataEntities Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public void CreateNewContext()
        {
            Context = new DAL.DataEntities();
        }

    }
}
