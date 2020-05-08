using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class DuplicateException : Exception
    {
        public string DuplicateItemName { get; private set; }
        public DuplicateException(string message, string itemName)
        {
            DuplicateItemName = itemName;
        }
    }
}
