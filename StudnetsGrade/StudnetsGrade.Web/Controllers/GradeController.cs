using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using StudnetsGrade.Web.Models;

namespace StudnetsGrade.Web.Controllers
{
    public class GradeController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<GradeModel>();
            var grades = model.GetAllGrades();
            return View(grades);
        }

        public IActionResult Create()
        {
            var model = new CreateGradeModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGradeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateGrade();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View(model);
                }
            }
            return View(model);
        }
    }
}