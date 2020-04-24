using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public interface IFrameworkContext
    {
        DbSet<Course> Courses { get; set; }
    }
}
