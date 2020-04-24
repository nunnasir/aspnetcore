using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public interface ICourseService
    {
        (IList<Course> records, int total, int totalDisplay) GetCourses(int pageIndex, 
                                                                        int pageSize, 
                                                                        string searchText, 
                                                                        string sortText);
        void AddCourse(Course course);
        IList<Course> GetAllCourse();
        Course GetCourseById(int id);

        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
