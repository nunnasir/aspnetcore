using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;

        public ExpenseService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public void CreateExpense(Expense expense)
        {
            _expenseUnitOfWork.ExpenseRepository.Add(expense);
            _expenseUnitOfWork.Save();
        }

        public Expense DeleteExpense(Guid id)
        {
            var expense = _expenseUnitOfWork.ExpenseRepository.GetById(id);
            _expenseUnitOfWork.ExpenseRepository.Remove(expense);
            _expenseUnitOfWork.Save();
            return expense;
        }

        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }

        public void EditExpense(Expense expense)
        {
            _expenseUnitOfWork.ExpenseRepository.Edit(expense);
            _expenseUnitOfWork.Save();
        }

        public Expense GetExpense(Guid id)
        {
            return _expenseUnitOfWork.ExpenseRepository.GetById(id);
        }

        public (IList<Expense> records, int total, int totalDisplay) GetExpenses(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _expenseUnitOfWork.ExpenseRepository.GetExpenseList(
                    e => e.Description.Contains(searchText) || e.Category.Name.Contains(searchText) || e.Account.Name.Contains(searchText),
                    sortText, e => e.Include(a => a.Account).Include(c => c.Category), pageIndex, pageSize, false);
            else
                return _expenseUnitOfWork.ExpenseRepository.GetExpenseList(null, sortText, 
                    e => e.Include(a => a.Account).Include(c => c.Category), 
                    pageIndex, pageSize, false);

        }

        public IList<Account> GetAccounts()
        {
            return _expenseUnitOfWork.AccountRepository.GetAll();
        }

        public IList<Category> GetCategories()
        {
            return _expenseUnitOfWork.CategoryRepository.GetAll();
        }

    }
}
