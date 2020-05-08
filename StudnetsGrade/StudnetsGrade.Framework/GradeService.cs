using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class GradeService : IGradeService
    {
        IStudentGradeUnitOfWork _studentGradeUnitOfWork;
        public GradeService(IStudentGradeUnitOfWork studentGradeUnitOfWork)
        {
            _studentGradeUnitOfWork = studentGradeUnitOfWork;
        }
        public void CreateStudentGrade(StudentGrade studentGrade)
        {
            _studentGradeUnitOfWork.GradeRepository.add(studentGrade);
            _studentGradeUnitOfWork?.Save();
        }

        public void Dispose()
        {
            _studentGradeUnitOfWork?.Dispose();
        }

        public List<StudentGrade> GetAllStudentGrades()
        {
            return _studentGradeUnitOfWork.GradeRepository.GetAllStudentGrade().ToList();
        }

        public List<Student> GetStudents()
        {
            return _studentGradeUnitOfWork.StudentRepository.GetAll().ToList();
        }

        public List<Subject> GetSubjects()
        {
            return _studentGradeUnitOfWork.SubjectRepository.GetAll().ToList();
        }
    }
}
