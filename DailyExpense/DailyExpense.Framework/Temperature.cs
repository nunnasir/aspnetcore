using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class Temperature : IEntity<int>
    {
        public int Id { get; set; }
        public string TempValue { get; set; }
        public int Status { get; set; }
    }
}
