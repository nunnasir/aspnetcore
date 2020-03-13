using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProductManagement.web.Areas.Admin.Models;

namespace ProductManagement.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new ProductsModel(_configuration);

            model.MenuModel = new MenuModel();

            return View(model);
        }

        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductsModel(_configuration);
            var data = model.GetProducts(tableModel);

            return Json(data);
        }
    }
}