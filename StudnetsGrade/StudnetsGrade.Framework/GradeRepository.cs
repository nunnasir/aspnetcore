using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class GradeRepository : Repository<StudentGrade, int, FrameworkContext>, IGradeRepository
    {
        public GradeRepository(FrameworkContext context) 
            : base(context)
        {
        }

        public IList<StudentGrade> GetAllStudentGrade()
        {
            IQueryable<StudentGrade> grades = _dbSet.Include(s => s.Subject).Include(s => s.Student);
            return grades.ToList();
        }
    }
}
