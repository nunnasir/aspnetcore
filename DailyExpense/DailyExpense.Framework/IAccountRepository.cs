using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface IAccountRepository : IRepository<Account, int, FrameworkContext>
    {

    }
}
