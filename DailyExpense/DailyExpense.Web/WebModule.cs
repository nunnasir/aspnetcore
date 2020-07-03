using Autofac;
using DailyExpense.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryModel>();
            builder.RegisterType<AccountModel>();
            builder.RegisterType<ExpenseModel>();
            builder.RegisterType<CreateCategoryModel>();
            //builder.RegisterType<IWebHostEnvironment>();


            base.Load(builder);
        }
    }
}
