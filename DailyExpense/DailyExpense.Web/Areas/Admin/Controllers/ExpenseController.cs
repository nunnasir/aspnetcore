using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DailyExpense.Framework;
using DailyExpense.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateExpenseModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateExpenseModel.Description), 
            nameof(CreateExpenseModel.ExpenseDate), 
            nameof(CreateExpenseModel.AccountId),
            nameof(CreateExpenseModel.CategoryId), 
            nameof(CreateExpenseModel.Amount))] 
            CreateExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("New Expense create successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var model = new EditExpenseModel();
            model.LoadExpense(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditExpenseModel.Id),
            nameof(EditExpenseModel.Description),
            nameof(EditExpenseModel.CategoryId),
            nameof(EditExpenseModel.ExpenseDate),
            nameof(EditExpenseModel.AccountId),
            nameof(EditExpenseModel.Amount))]
            EditExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Expense successfully updated!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Expense updation failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult GetExpenses()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            var data = model.GetExpenses(tableModel);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExpense(Guid id)
        {
            if (ModelState.IsValid)
            {
                var model = new ExpenseModel();
                try
                {
                    var title = model.Delete(id);
                    model.Response = new ResponseModel("Expense deleted successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Expense deletion failed!", ResponseType.Failure);
                }
            }
            return RedirectToAction("Index");
        }

    }
}