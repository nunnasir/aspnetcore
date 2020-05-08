using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class SubjectModel : SubjectBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RegistrationOpen { get; set; }

        public SubjectModel(ISubjectService subjectService) : base(subjectService) { }
        public SubjectModel() : base() { }
        
        public List<SubjectModel> GetAllSubject()
        {
            List<SubjectModel> subjects = new List<SubjectModel>();

            foreach (var item in _subjectService.GetAllSubject())
            {
                var subject = new SubjectModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    RegistrationOpen = item.RegistrationOpen
                };
                subjects.Add(subject);
            }
            return subjects;
        }

    }
}
