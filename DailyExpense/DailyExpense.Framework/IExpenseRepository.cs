using DailyExpense.Data;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DailyExpense.Framework
{
    public interface IExpenseRepository : IRepository<Expense, Guid, FrameworkContext>
    {
        (IList<Expense> data, int total, int totalDisplay) GetExpenseList(
            Expression<Func<Expense, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>> include = null, 
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}
