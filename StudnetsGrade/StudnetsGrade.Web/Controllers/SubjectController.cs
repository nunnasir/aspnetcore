using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using StudnetsGrade.Web.Models;

namespace StudnetsGrade.Web.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<SubjectModel>();
            var subjects = model.GetAllSubject();
            return View(subjects);
        }

        public IActionResult Create()
        {
            var model = new CreateSubjectModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateSubjectModel.Name), nameof(CreateSubjectModel.RegistrationOpen))] CreateSubjectModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateSubject();
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