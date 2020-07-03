using Autofac;
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
        
        public void Create()
        {
            var hostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/Category/", fileName);
            var stream = new FileStream(path, FileMode.Create);
            ImageFile.CopyToAsync(stream);

            var category = new Category
            {
                Name = this.Name,
                Image = fileName
               
            };
            _categoryService.CreateCategory(category);
        }

    }
}
