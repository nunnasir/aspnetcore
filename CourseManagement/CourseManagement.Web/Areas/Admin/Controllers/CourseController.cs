using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CourseManagement.Framework;
using CourseManagement.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CourseManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IConfiguration _configuration;
        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CourseModel model)
        {
            model.CreateCourse();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            var course = model.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(CourseModel model)
        {
            model.UpdateCourse();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = Startup.AutofacContainer.Resolve<CourseModel>();
            model.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        //public IActionResult GetCourse()
        //{
        //    var tableModel = new DataTablesAjaxRequestModel(Request);
        //    var model = Startup.AutofacContainer.Resolve<CourseModel>();
        //    var data = model.GetCourses(tableModel);
        //    return Json(data);
        //}
    }
}