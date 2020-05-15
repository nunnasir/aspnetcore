using DailyExpense.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class ExpenseUnitOfWork : UnitOfWork, IExpenseUnitOfWork
    {
        public IAccountRepository AccountRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IExpenseRepository ExpenseRepository { get; set; }
        
        public ExpenseUnitOfWork(FrameworkContext dbContext, 
            IAccountRepository accountRepository, 
            ICategoryRepository categoryRepository, 
            IExpenseRepository expenseRepository) 
            : base(dbContext)
        {
            AccountRepository = accountRepository;
            CategoryRepository = categoryRepository;
            ExpenseRepository = expenseRepository;
        }
    }
}
