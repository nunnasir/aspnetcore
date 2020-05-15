using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface IExpenseService : IDisposable
    {
        (IList<Expense> records, int total, int totalDisplay) GetExpenses(int pageIndex, int pageSize, string searchText, string sortText);
        void CreateExpense(Expense expense);
        void EditExpense(Expense expense);
        Expense GetExpense(Guid id);
        Expense DeleteExpense(Guid id);
        IList<Account> GetAccounts();
        IList<Category> GetCategories();
    }
}
