using Autofac;
using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CategoryBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly ICategoryService _categoryService;
        public CategoryBaseModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public CategoryBaseModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public void Dispose()
        {
            _categoryService?.Dispose();
        }
    }
}
