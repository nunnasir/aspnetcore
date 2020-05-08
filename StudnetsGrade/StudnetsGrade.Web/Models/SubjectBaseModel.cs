using Autofac;
using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class SubjectBaseModel : IDisposable
    {
        protected readonly ISubjectService _subjectService;
        public SubjectBaseModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public SubjectBaseModel()
        {
            _subjectService = Startup.AutofacContainer.Resolve<ISubjectService>();
        }

        public void Dispose()
        {
            _subjectService?.Dispose();
        }
    }
}
