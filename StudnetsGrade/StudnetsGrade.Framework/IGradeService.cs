using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface IGradeService : IDisposable
    {
        void CreateStudentGrade(StudentGrade studentGrade);
        List<StudentGrade> GetAllStudentGrades();
        List<Student> GetStudents();
        List<Subject> GetSubjects();
    }
}
