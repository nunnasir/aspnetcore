using Microsoft.EntityFrameworkCore.Query;
using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface IGradeRepository : IRepository<StudentGrade, int, FrameworkContext>
    {
        IList<StudentGrade> GetAllStudentGrade();
    }
}
