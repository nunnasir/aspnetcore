using CourseManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public class CourseUnitOfWork : UnitOfWork<FrameworkContext>, ICourseUnitOfWork
    {
        public CourseUnitOfWork(string connectionString, string migrationAssemblyName) 
            : base(connectionString, migrationAssemblyName)
        {
            CourseRepository = new CourseRepository(_dbContext);
        }
        public ICourseRepository CourseRepository { get; set; }
    }
}
