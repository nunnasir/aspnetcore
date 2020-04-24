using Autofac;
using CourseManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlServerDataProvider<Course>>().As<ISqlServerDataProvider<Course>>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString) 
                .WithParameter("migrationAssemblyName", _migrationAssemblyName);

            builder.RegisterType<FrameworkContext>().As<IFrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseUnitOfWork>().As<ICourseUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
