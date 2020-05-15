using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface IAccountService : IDisposable
    {
        (IList<Account> records, int total, int totalDisplay) GetAccounts(int pageIndex, int pageSize, string searchText, string sortText);
        void CreateAccount(Account account);
        void EditAccount(Account account);
        Account GetAccount(int id);
        Account DeleteAccount(int id);
    }
}
