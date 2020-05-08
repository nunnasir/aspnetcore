using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class StudentService : IStudentService, IDisposable
    {
        private IStudentGradeUnitOfWork _studentGradeUnitOfWork;
        public StudentService(IStudentGradeUnitOfWork studentGradeUnitOfWork)
        {
            _studentGradeUnitOfWork = studentGradeUnitOfWork;
        }

        public void CreateStudent(Student student)
        {
            var emailCount = _studentGradeUnitOfWork.StudentRepository.GetCount(x => x.Email == student.Email);
            var userCount = _studentGradeUnitOfWork.StudentRepository.GetCount(x => x.Username == student.Username);
            if (emailCount > 0)
                throw new DuplicateException("Student Email Already Exists", student.Email);
            if (userCount > 0)
                throw new DuplicateException("Student Username Already Exists", student.Username);

            _studentGradeUnitOfWork.StudentRepository.add(student);
            _studentGradeUnitOfWork?.Save();
        }

        public List<Student> GetAllStudent()
        {
            var students = _studentGradeUnitOfWork.StudentRepository.GetAll().ToList();
            return students;
        }

        public void Dispose()
        {
            _studentGradeUnitOfWork?.Dispose();
        }
    }
}
