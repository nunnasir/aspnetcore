using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentGradeUnitOfWork>().As<IStudentGradeUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GradeRepository>().As<IGradeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubjectService>().As<ISubjectService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GradeService>().As<IGradeService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
