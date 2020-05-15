using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class EditCategoryModel : CategoryBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public EditCategoryModel(ICategoryService categoryService) : base(categoryService) { }
        public EditCategoryModel() : base() { }

        public void Edit()
        {
            var category = _categoryService.GetCategory(this.Id);
            category.Id = this.Id;
            category.Name = this.Name;

            _categoryService.EditCategory(category);
        }
        
        public void LoadCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            if(category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
            }
        }
    }
}
