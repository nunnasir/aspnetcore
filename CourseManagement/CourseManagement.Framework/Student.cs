using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<StudentRegistration> StudentRegistrations { get; set; }
    }
}
