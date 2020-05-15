using Autofac;
using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class AccountBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IAccountService _accountService;
        public AccountBaseModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountBaseModel()
        {
            _accountService = Startup.AutofacContainer.Resolve<IAccountService>();
        }

        public void Dispose()
        {
            _accountService?.Dispose();
        }
    }
}
