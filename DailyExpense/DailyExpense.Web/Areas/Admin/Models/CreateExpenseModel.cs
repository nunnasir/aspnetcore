using DailyExpense.Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CreateExpenseModel : ExpenseBaseModel
    {
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
        
        public CreateExpenseModel(IExpenseService expenseService) : base(expenseService) 
        {
            if (ExpenseDate == null)
                ExpenseDate = DateTime.Now;
        }
        public CreateExpenseModel() : base() 
        {
            if(ExpenseDate == null)
                ExpenseDate = DateTime.Now;
        }
        

        public void Create()
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                ExpenseDate = this.ExpenseDate,
                Description = this.Description,
                AccountId = this.AccountId,
                CategoryId = this.CategoryId,
                Amount = this.Amount,
            };
            _expenseService.CreateExpense(expense);
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
