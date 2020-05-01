using Autofac;
using Microsoft.AspNetCore.Mvc;
using StudentGrades.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGrades.web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            model.CreateStudent();
            return RedirectToAction("Create");
        }

    }
}
