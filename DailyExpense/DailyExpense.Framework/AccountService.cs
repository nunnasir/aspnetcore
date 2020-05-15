using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class AccountService : IAccountService
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;

        public AccountService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public void CreateAccount(Account account)
        {
            var count = _expenseUnitOfWork.AccountRepository.GetCount(a => a.Name == account.Name);
            if (count > 0)
                throw new DuplicateException("Account title already exist!", account.Name);
            _expenseUnitOfWork.AccountRepository.Add(account);
            _expenseUnitOfWork.Save();
        }

        public Account DeleteAccount(int id)
        {
            var account = _expenseUnitOfWork.AccountRepository.GetById(id);
            _expenseUnitOfWork.AccountRepository.Remove(account);
            _expenseUnitOfWork.Save();
            return account;
        }

        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }

        public void EditAccount(Account account)
        {
            var count = _expenseUnitOfWork.AccountRepository.GetCount(a => a.Name == account.Name && a.Id != account.Id);
            if (count > 0)
                throw new DuplicateException("Account title already exist!", account.Name);
            _expenseUnitOfWork.AccountRepository.Edit(account);
            _expenseUnitOfWork.Save();
        }

        public Account GetAccount(int id)
        {
            return _expenseUnitOfWork.AccountRepository.GetById(id);
        }

        public (IList<Account> records, int total, int totalDisplay) GetAccounts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _expenseUnitOfWork.AccountRepository.GetDynamic(a => a.Name.Contains(searchText), sortText, "", pageIndex, pageSize, false);
            else
                return _expenseUnitOfWork.AccountRepository.GetDynamic(null, sortText, "", pageIndex, pageSize, false);
        }
    }
}
