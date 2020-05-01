using StudentGrades.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public interface IStudentGradeUnitOfWork : IUnitOfWork
    {
        IStudentRepository StudentRepository { get; set; }
    }
}
