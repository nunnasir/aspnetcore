using CourseManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public interface ICourseRepository : IRepository<Course>
    {
        IList<Course> GetLatestCourse();

        IList<Course> GetAllCourse();
        void AddCourse(Course course);
        Course GetCourseById(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
