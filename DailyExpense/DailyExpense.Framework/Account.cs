using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class Account : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Expense> Expenses { get; set; }
    }
}
