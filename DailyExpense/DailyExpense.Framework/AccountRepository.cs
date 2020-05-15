using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class AccountRepository : Repository<Account, int, FrameworkContext>, IAccountRepository
    {
        public AccountRepository(FrameworkContext context) : base(context) { }

    }
}
