using Autofac;
using CourseManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.Areas.Admin.Models
{
    public class CourseModel : AdminBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }

        private readonly ICourseService _courseService;

        public CourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public CourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        internal object GetCourses(DataTablesAjaxRequestModel tableModel)
        {
            var data = _courseService.GetCourses(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "SeatCount", "Fee", "PublishedDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.SeatCount.ToString(),
                                record.Fee.ToString(),
                                record.PublishedDate.ToString()
                        }
                    ).ToArray()
            };
        }

        public void CreateCourse()
        {
            _courseService.AddCourse(new Course
            {
                Title = this.Title,
                SeatCount = this.SeatCount,
                Fee = this.Fee,
                PublishedDate = DateTime.Now
            });
        }

        public void DeleteCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            _courseService.DeleteCourse(course);
        }

        public void UpdateCourse()
        {
            var course = _courseService.GetCourseById(this.Id);
            course.Title = this.Title;
            course.SeatCount = this.SeatCount;
            course.Fee = this.Fee;
            
            _courseService.UpdateCourse(course);
        }

        public List<Course> GetAllCourse()
        {
            return _courseService.GetAllCourse().ToList();
        }

        public CourseModel GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);

            return new CourseModel
            {
                Id = course.Id,
                Title = course.Title,
                SeatCount = course.SeatCount,
                Fee = course.Fee
            };
        }


        //public void CourseCreate()
        //{
        //    var context = Startup.AutofacContainer.Resolve<FrameworkContext>();

        //    context.Courses.Add(new Course
        //    {
        //        Title = this.Title,
        //        SeatCount = this.SeatCount,
        //        Fee = this.Fee,
        //        PublishedDate = DateTime.Now
        //    });

        //    context.SaveChanges();
        //    context.Dispose();
        //}

    }
}
