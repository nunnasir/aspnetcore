using System;

namespace DailyExpense.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
