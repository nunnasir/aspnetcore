using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DailyExpense.Framework;
using DailyExpense.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public CategoryController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateCategoryModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateCategoryModel.Name), nameof(CreateCategoryModel.ImageFile))] CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/Category/", fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    model.ImageFile.CopyToAsync(stream);
                    

                    model.Create(fileName);
                    model.Response = new ResponseModel($"Category {model.Name} Create Successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Category Creation Failed!", ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditCategoryModel();
            model.LoadCategory(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditCategoryModel.Id), nameof(EditCategoryModel.Name))] EditCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel($"Category {model.Name} Updated Successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Category Update Failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult GetCategories()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            var data = model.GetCategories(tableModel);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CategoryModel();
                try
                {
                    var title = model.Delete(id);
                    model.Response = new ResponseModel($"Caategory {title} Successfully Deleted!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Category Delete failed!", ResponseType.Failure);
                }
            }
            return RedirectToAction("Index");
        }

    }
}