using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class StudentGrade
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public decimal Grade { get; set; }
    }
}
