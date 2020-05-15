using Autofac;
using DailyExpense.Framework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response), 
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>()
                {
                    {
                        new MenuItem
                        {
                            Title = "Category",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem { Title = "View Categories", Url = "/Admin/Category" },
                                new MenuChildItem { Title = "Create Categories", Url = "/Admin/Category/Create" },
                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title = "Account Type",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem { Title = "View Account Types", Url = "/Admin/Account" },
                                new MenuChildItem { Title = "Create Account Type", Url = "/Admin/Account/Create" },
                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title = "Daily Expense",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem { Title = "View Expense", Url = "/Admin/Expense" },
                                new MenuChildItem { Title = "Create Expense", Url = "/Admin/Expense/Create" },
                            }
                        }
                    }
                }
            };
        }
    }
}
