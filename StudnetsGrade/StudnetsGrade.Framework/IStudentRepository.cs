using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface IStudentRepository : IRepository<Student, int, FrameworkContext>
    {

    }
}
