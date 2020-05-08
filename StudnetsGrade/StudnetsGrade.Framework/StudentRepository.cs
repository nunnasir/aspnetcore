using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class StudentRepository : Repository<Student, int, FrameworkContext>, IStudentRepository
    {
        public StudentRepository(FrameworkContext dbContext) 
            : base(dbContext)
        {
        }

    }
}
