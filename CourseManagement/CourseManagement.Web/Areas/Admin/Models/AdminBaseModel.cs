using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public AdminBaseModel()
        {
            MenuModel = new MenuModel();
        }
        public MenuModel MenuModel { get; set; }
    }
}
