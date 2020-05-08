using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public AdminBaseModel()
        {
            MenuModel = new MenuModel();
            MenuModel.MenuItems = new List<MenuItem>
            {
                new MenuItem {Title = "Student", Url = "/Student"},
                new MenuItem {Title = "Subject", Url = "/Subject"},
                new MenuItem {Title = "StudentGrade", Url = "/Grade"},
            };
        }
    }
}
