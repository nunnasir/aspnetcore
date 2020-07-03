using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyExpense.Web.Areas.Admin.Models;
using Membership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private readonly RoleManager _roleManager;
        public DashboardController(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }


        [AllowAnonymous]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new Membership.Entities.Role("Administrator"));
            await _roleManager.CreateAsync(new Membership.Entities.Role("Superuser"));
            return View();
        }
    }
}