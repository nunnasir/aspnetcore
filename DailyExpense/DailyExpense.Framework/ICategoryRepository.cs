using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface ICategoryRepository : IRepository<Category, int, FrameworkContext>
    {

    }
}
