using CourseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManagement.Framework
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) 
            : base(dbContext)
        {

        }
        public IList<Course> GetLatestCourse()
        {
            return Get(x => x.PublishedDate < DateTime.Now.AddDays(-7)).ToList();
        }

        public IList<Course> GetAllCourse()
        {
            return Get().ToList();
        }
        public void AddCourse(Course course) => Add(course);

        public Course GetCourseById(int id)
        {
            return GetById(id);
        }

        public void UpdateCourse(Course course)
        {
            Edit(course);
        }

        public void DeleteCourse(Course course)
        {
            Remove(course);
        }
    }
}
