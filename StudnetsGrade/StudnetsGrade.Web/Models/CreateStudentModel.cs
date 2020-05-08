using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class CreateStudentModel : StudentBaseModel
    {
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        public CreateStudentModel(IStudentService studentService) : base(studentService) { }
        public CreateStudentModel() : base() { }

        public void CreateStudent()
        {
            var student = new Student
            {
                Name = this.Name,
                Username = this.Username,
                Email = this.Email
            };

            _studentService.CreateStudent(student);
        }

    }
}
