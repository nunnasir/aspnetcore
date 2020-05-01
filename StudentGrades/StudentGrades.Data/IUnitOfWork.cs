using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
