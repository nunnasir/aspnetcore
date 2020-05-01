using StudentGrades.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class StudentRepository : Repository<Student, int, FrameworkContext>, IStudentRepository
    {
        public StudentRepository(FrameworkContext context) : base(context)
        {
        }



    }
}
