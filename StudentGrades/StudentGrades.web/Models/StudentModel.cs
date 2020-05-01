using StudentGrades.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace StudentGrades.web.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        private readonly IStudentServices _studentService;

        public StudentModel(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        public StudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentServices>();
        }

        public void CreateStudent()
        {
            _studentService.CreateStudent(new Student
            {
                Name = this.Name,
                Username = this.Username,
                Email = this.Email
            });
        }

    }
}
