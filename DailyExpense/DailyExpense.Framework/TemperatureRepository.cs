using DailyExpense.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    public class TemperatureRepository : Repository<Temperature, int, FrameworkContext>, ITemperatureRepository
    {
        public TemperatureRepository(FrameworkContext context) : base(context) { }

    }
}
