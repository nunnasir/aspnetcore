using Microsoft.AspNetCore.Mvc.Rendering;
using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class CreateGradeModel : GradeBaseModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        [Range(0.00, 4.00)]
        public double GradeValue { get; set; }

        public CreateGradeModel(IGradeService gradeService) : base(gradeService) { }
        public CreateGradeModel() : base() { }
        
        public void CreateGrade()
        {
            var grade = new StudentGrade
            {
                StudentId = this.StudentId,
                SubjectId = this.SubjectId,
                GradeValue = this.GradeValue
            };
            _gradeService.CreateStudentGrade(grade);
        }

        public List<SelectListItem> GetStudentList()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            
            foreach (var item in _gradeService.GetStudents().ToList())
            {
                var student = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItem.Add(student);
            }
            return listItem;
        }

        public List<SelectListItem> GetSubjectList()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (var item in _gradeService.GetSubjects().ToList())
            {
                var subject = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItem.Add(subject);
            }
            return listItem;
        }

    }
}
