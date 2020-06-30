using DailyExpense.Framework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CreateCategoryModel : CategoryBaseModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }


        public CreateCategoryModel(ICategoryService categoryService) : base(categoryService) {}
        public CreateCategoryModel() : base() { }
        
        public void Create(string fileName)
        {
            var category = new Category
            {
                Name = this.Name,
                Image = fileName
               
            };
            _categoryService.CreateCategory(category);
        }

    }
}
