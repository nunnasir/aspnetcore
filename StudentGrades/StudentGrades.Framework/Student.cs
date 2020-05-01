using StudentGrades.Data;
using System;
using System.Collections.Generic;

namespace StudentGrades.Framework
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<StudentGrade> Grades { get; set; }
    }
}
