using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class DuplicateException : Exception
    {
        public string DuplicateItemName { get; private set; }
        public DuplicateException(string message, string itemName) : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}
