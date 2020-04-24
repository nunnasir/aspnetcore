using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseManagement.Web.Areas.Admin.Models;

namespace CourseManagement.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}