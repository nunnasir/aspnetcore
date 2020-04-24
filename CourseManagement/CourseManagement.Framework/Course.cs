using System;
using System.Collections.Generic;

namespace CourseManagement.Framework
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }
        public DateTime PublishedDate { get; set; }
        public IList<StudentRegistration> StudentRegistrations { get; set; }
    }
}
