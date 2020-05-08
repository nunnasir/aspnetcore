using System;

namespace StudnetsGrade.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
