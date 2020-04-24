using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManagement.Framework
{
    public class CourseService : ICourseService
    {
        private ICourseUnitOfWork _courseUnitOfWork;
        public CourseService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }
        public (IList<Course> records, int total, int totalDisplay) GetCourses(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _courseUnitOfWork.CourseRepository.Get().ToList();
            return (result, 0, 0);
        }

        public IList<Course> GetAllCourse()
        {
            var result = _courseUnitOfWork.CourseRepository.GetAllCourse();
            return result;
        }

        public void AddCourse(Course course) {
            _courseUnitOfWork.CourseRepository.AddCourse(course);
            _courseUnitOfWork.Save();
        }

        public Course GetCourseById(int id)
        {
            return _courseUnitOfWork.CourseRepository.GetById(id);
        }

        public void UpdateCourse(Course course)
        {
            _courseUnitOfWork.CourseRepository.UpdateCourse(course);
            _courseUnitOfWork.Save();
        }

        public void DeleteCourse(Course course)
        {
            _courseUnitOfWork.CourseRepository.DeleteCourse(course);
            _courseUnitOfWork.Save();
        }
    }
}
