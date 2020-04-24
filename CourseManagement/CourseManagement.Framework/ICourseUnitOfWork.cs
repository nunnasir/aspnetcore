using CourseManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public interface ICourseUnitOfWork : IUnitOfWork<FrameworkContext>
    {
        ICourseRepository CourseRepository { get; set; }
    }
}
