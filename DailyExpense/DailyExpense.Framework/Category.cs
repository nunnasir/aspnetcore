using DailyExpense.Data;
using System;
using System.Collections.Generic;

namespace DailyExpense.Framework
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Expense> Expenses { get; set; }
    }
}
