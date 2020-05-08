using Autofac;
using StudnetsGrade.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudnetsGrade.Web.Models
{
    public class GradeBaseModel : IDisposable
    {
        protected readonly IGradeService _gradeService;
        public GradeBaseModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        public GradeBaseModel()
        {
            _gradeService = Startup.AutofacContainer.Resolve<IGradeService>();
        }
        public void Dispose()
        {
            _gradeService?.Dispose();
        }
    }
}
