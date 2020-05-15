using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CreateAccountModel : AccountBaseModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public CreateAccountModel(IAccountService accountService) : base(accountService) { }
        public CreateAccountModel() : base() { }
        
        public void Create()
        {
            var account = new Account
            {
                Name = this.Name
            };
            _accountService.CreateAccount(account);
        }
        
    }
}
