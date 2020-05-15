using DailyExpense.Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class EditExpenseModel : ExpenseBaseModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Account Type")]
        public int AccountId { get; set; }
        [Required]
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Expense Amount")]
        public Double Amount { get; set; }
        [Required]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }

        public EditExpenseModel(IExpenseService expenseService) : base(expenseService) { }
        public EditExpenseModel() : base() { }

        public void Edit()
        {
            var expense = _expenseService.GetExpense(this.Id);
            expense.Id = this.Id;
            expense.ExpenseDate = this.ExpenseDate;
            expense.Description = this.Description;
            expense.CategoryId = this.CategoryId;
            expense.AccountId = this.AccountId;
            expense.Amount = this.Amount;

            _expenseService.EditExpense(expense);
        }

        public void LoadExpense(Guid id)
        {
            var expense = _expenseService.GetExpense(id);
            if(expense != null)
            {
                this.ExpenseDate = expense.ExpenseDate;
                this.Description = expense.Description;
                this.CategoryId = expense.CategoryId;
                this.AccountId = expense.AccountId;
                this.Amount = expense.Amount;
            }
        }

        public IList<SelectListItem> GetAccountList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _expenseService.GetAccounts())
            {
                var account = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(account);
            }
            return listItems;
        }

        public IList<SelectListItem> GetCategoryList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _expenseService.GetCategories())
            {
                var account = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(account);
            }
            return listItems;
        }

    }
}
