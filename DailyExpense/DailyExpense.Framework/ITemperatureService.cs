using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public interface ITemperatureService : IDisposable
    {
        void CreateTemp(Temperature temperature);
    }
}
