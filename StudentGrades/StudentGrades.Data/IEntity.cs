using System;

namespace StudentGrades.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
