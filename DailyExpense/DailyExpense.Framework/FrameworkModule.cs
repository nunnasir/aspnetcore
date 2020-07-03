using Autofac;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework
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
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseUnitOfWork>().As<IExpenseUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountRepository>().As<IAccountRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TemperatureRepository>().As<ITemperatureRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountService>().As<IAccountService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseService>().As<IExpenseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TemperatureService>().As<ITemperatureService>()
                .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}
