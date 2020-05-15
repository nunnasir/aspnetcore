using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class EditAccountModel : AccountBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public EditAccountModel(IAccountService accountService) : base(accountService) { }
        public EditAccountModel() : base() { }

        public void Edit()
        {
            var account = _accountService.GetAccount(this.Id);
            account.Id = this.Id;
            account.Name = this.Name;

            _accountService.EditAccount(account);
        }

        public void LoadAccount(int id)
        {
            var account = _accountService.GetAccount(id);
            if(account != null)
            {
                this.Id = account.Id;
                this.Name = account.Name;
            }
        }

    }
}
