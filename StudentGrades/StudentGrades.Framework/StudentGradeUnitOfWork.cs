using Microsoft.EntityFrameworkCore;
using StudentGrades.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class StudentGradeUnitOfWork : UnitOfWork, IStudentGradeUnitOfWork
    {
        public StudentGradeUnitOfWork(DbContext dbContext, IStudentRepository studentRepository) : base(dbContext)
        {
            StudentRepository = studentRepository;
        }

        public IStudentRepository StudentRepository { get; set; }
    }
}
