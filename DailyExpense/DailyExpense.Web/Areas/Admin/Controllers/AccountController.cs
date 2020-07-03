using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DailyExpense.Framework;
using DailyExpense.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<AccountModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateAccountModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateAccountModel.Name))] CreateAccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("New account Type Create Successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("New account creation failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditAccountModel();
            model.LoadAccount(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditAccountModel.Id), nameof(EditAccountModel.Name))] EditAccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Account Type Successfully updated!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicateException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Account update failed!", ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult GetAccounts()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<AccountModel>();
            var data = model.GetAccounts(tableModel);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAccount(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new AccountModel();
                try
                {
                    var title = model.Delete(id);
                    model.Response = new ResponseModel($"Account Type {title} sussessfully deleted!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Account Deletion Failed!", ResponseType.Failure);
                }
            }
            return RedirectToAction("Index");
        }

    }
}