using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public class StudentRegistration
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }
    }
}
