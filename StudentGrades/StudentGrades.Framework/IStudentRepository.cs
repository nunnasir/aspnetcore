using StudentGrades.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public interface IStudentRepository : IRepository<Student, int, FrameworkContext>
    {

    }
}
