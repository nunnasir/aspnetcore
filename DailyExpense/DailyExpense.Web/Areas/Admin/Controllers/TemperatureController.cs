using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyExpense.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TemperatureController : Controller
    {
        public IActionResult Create()
        {
            var model = new CreateTempModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create([Bind(nameof(CreateTempModel.TempValue))] CreateTempModel model)
        {
            if(model.TempValue != null)
            {
                model.Create();
                //return RedirectToAction("Create");
            }
            
            return View(model);
        }
    }
}