using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class ExpenseModel : ExpenseBaseModel
    {
        public ExpenseModel(IExpenseService expenseService) : base(expenseService) { }
        public ExpenseModel() : base() { }

        internal object GetExpenses(DataTableAjaxRequestModel tableModel)
        {
            var data = _expenseService.GetExpenses(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "ExpenseDate", "Account", "Description", "Category", "Amount" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.ExpenseDate.ToString("dd/MM/yyyy"),
                            record.Account.Name,
                            record.Description,
                            record.Category.Name,
                            record.Amount.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(Guid id)
        {
            var deleteExpense = _expenseService.DeleteExpense(id);
            return deleteExpense.Description;
        }

    }
}
