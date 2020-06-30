using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
{
    class TemperatureService : ITemperatureService
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;
        public TemperatureService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public void CreateTemp(Temperature temperature)
        {
            _expenseUnitOfWork.TemperatureRepository.Add(temperature);
            _expenseUnitOfWork.Save();
        }
        
        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }
    }
}
