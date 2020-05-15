using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class AccountModel : AccountBaseModel
    {
        public AccountModel(IAccountService accountService) : base(accountService) { }
        public AccountModel() : base() { }

        internal object GetAccounts(DataTableAjaxRequestModel tableModel)
        {
            var data = _accountService.GetAccounts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(int id)
        {
            var deleteAccount = _accountService.DeleteAccount(id);
            return deleteAccount.Name;
        }

    }
}
