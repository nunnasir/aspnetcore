using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface IExpenseUnitOfWork : IUnitOfWork
    {
        IAccountRepository AccountRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IExpenseRepository ExpenseRepository { get; set; }
    }
}
