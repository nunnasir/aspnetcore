using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class Expense : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
