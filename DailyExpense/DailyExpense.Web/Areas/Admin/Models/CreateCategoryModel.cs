using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CreateCategoryModel : CategoryBaseModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public CreateCategoryModel(ICategoryService categoryService) : base(categoryService) { }
        public CreateCategoryModel() : base() { }
        
        public void Create()
        {
            var category = new Category
            {
                Name = this.Name
            };
            _categoryService.CreateCategory(category);
        }

    }
}
