using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface IStudentGradeUnitOfWork : IUnitOfWork
    {
        IStudentRepository StudentRepository { get; set; }
        ISubjectRepository SubjectRepository { get; set; }
        IGradeRepository GradeRepository { get; set; }

    }
}
