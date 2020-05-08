using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using StudnetsGrade.Web.Models;

namespace StudnetsGrade.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<StudentModel>();
            var students = model.GetAllStudent();
            return View(students);
        }

        public IActionResult Create()
        {
            var model = new CreateStudentModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind(nameof(CreateStudentModel.Name), nameof(CreateStudentModel.Username), nameof(CreateStudentModel.Email))] CreateStudentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateStudent();
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