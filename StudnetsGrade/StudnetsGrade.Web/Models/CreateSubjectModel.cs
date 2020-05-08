using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class CreateSubjectModel : SubjectBaseModel
    {
        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public bool RegistrationOpen { get; set; }

        public CreateSubjectModel(ISubjectService subjectService) : base(subjectService) { }
        public CreateSubjectModel() : base() { }

        public void CreateSubject()
        {
            var subject = new Subject
            {
                Name = this.Name,
                RegistrationOpen = this.RegistrationOpen
            };
            _subjectService.CreateSubject(subject);
        }
        
    }
}
