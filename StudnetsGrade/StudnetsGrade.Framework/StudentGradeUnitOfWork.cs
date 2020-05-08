using Microsoft.EntityFrameworkCore;
using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class StudentGradeUnitOfWork : UnitOfWork, IStudentGradeUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public ISubjectRepository SubjectRepository { get; set; }
        public IGradeRepository GradeRepository { get; set; }

        public StudentGradeUnitOfWork(FrameworkContext context, 
            IStudentRepository studentRepository, 
            ISubjectRepository subjectRepository,
            IGradeRepository gradeRepository)
            : base(context)
        {
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
            GradeRepository = gradeRepository;
        }
    }
}
