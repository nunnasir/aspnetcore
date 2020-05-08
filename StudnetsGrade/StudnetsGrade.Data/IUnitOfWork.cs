using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
