using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class StudentService : IStudentServices, IDisposable
    {
        private IStudentGradeUnitOfWork _studentGradeUnitOfWork;

        public StudentService(IStudentGradeUnitOfWork studentGradeUnitOfWork)
        {
            _studentGradeUnitOfWork = studentGradeUnitOfWork;
        }
        public void CreateStudent(Student student)
        {
            _studentGradeUnitOfWork.StudentRepository.Add(student);
            _studentGradeUnitOfWork.Save();
        }

        public void Dispose()
        {
            _studentGradeUnitOfWork?.Dispose();
        }
    }
}
