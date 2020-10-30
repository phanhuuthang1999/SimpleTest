using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    public class MenuBll : BllBase
    {
        public List<HT_Page> GetAllPage()
        {
            return Context.HT_Page.Where(m => m.IsVisible ?? false).ToList();
        }

        public List<HT_Group> GetAllGroup()
        {
            return Context.HT_Group.Where(m => m.IsVisible ?? false).ToList();
        }

        public List<HT_Form> GetAllForm()
        {
            return Context.HT_Form.Where(m => m.IsVisible ?? false).ToList();
        }
    }
}
