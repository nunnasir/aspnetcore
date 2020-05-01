using StudentGrades.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class Subject : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RegistrationOpen { get; set; }
        public List<StudentGrade> Grades { get; set; }
    }
}
