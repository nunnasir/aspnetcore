using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class SubjectService : ISubjectService
    {
        private IStudentGradeUnitOfWork _studentGradeUnitOfWork;
        public SubjectService(IStudentGradeUnitOfWork studentGradeUnitOfWork)
        {
            _studentGradeUnitOfWork = studentGradeUnitOfWork;
        }

        public void CreateSubject(Subject subject)
        {
            var count = _studentGradeUnitOfWork.SubjectRepository.GetCount(x => x.Name == subject.Name);
            if (count > 0)
                throw new DuplicateException("Subject Name Already Exists", subject.Name);
            _studentGradeUnitOfWork.SubjectRepository.add(subject);
            _studentGradeUnitOfWork?.Save();
        }

        public void Dispose()
        {
            _studentGradeUnitOfWork?.Dispose();
        }

        public List<Subject> GetAllSubject()
        {
            return _studentGradeUnitOfWork.SubjectRepository.GetAll().ToList() ;
        }
    }
}
