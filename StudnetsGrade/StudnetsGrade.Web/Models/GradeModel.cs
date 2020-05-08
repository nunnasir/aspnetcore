using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class GradeModel : GradeBaseModel
    {
        public int Id { get; set; }
        //public int StudentId { get; set; }
        public Student Student { get; set; }
        //public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public double GradeValue { get; set; }

        public GradeModel(IGradeService gradeService) : base(gradeService) { }
        public GradeModel() : base() { }
        
        public List<GradeModel> GetAllGrades()
        {
            List<GradeModel> allGrades = new List<GradeModel>();

            foreach (var item in _gradeService.GetAllStudentGrades().ToList())
            {
                var grade = new GradeModel
                {
                    Id = item.Id,
                    Student = item.Student,
                    Subject = item.Subject,
                    GradeValue = item.GradeValue
                };
                allGrades.Add(grade);
            }

            return allGrades;
        }
    }
}
