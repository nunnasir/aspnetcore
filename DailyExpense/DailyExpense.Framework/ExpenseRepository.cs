using DailyExpense.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Dynamic.Core;

namespace DailyExpense.Framework
{
    public class ExpenseRepository : Repository<Expense, Guid, FrameworkContext>, IExpenseRepository
    {
        public ExpenseRepository(FrameworkContext context) : base(context) { }

        public (IList<Expense> data, int total, int totalDisplay) GetExpenseList(
            Expression<Func<Expense, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Expense>, IIncludableQueryable<Expense, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<Expense> query = _dbSet;
            var total = query.Count();
            var totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            if(include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
        }



    }
}
