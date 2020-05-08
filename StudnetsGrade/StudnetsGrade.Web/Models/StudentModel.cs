using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class StudentModel : StudentBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public StudentModel(IStudentService studentService) : base(studentService) { }
        public StudentModel() : base() { }

        public List<StudentModel> GetAllStudent()
        {
            var students = _studentService.GetAllStudent();
            List<StudentModel> allStudent = new List<StudentModel>();

            foreach (var item in students)
            {
                var student = new StudentModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Username = item.Username,
                    Email = item.Email
                };
                allStudent.Add(student);
            }
            return allStudent;
        }

    }
}
