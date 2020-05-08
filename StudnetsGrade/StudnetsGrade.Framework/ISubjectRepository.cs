using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface ISubjectRepository : IRepository<Subject, int, FrameworkContext>
    {
    }
}
