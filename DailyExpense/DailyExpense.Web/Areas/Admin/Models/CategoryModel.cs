using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CategoryModel : CategoryBaseModel
    {
        public CategoryModel(ICategoryService categoryService) : base(categoryService) { }
        public CategoryModel() : base() { }
        
        internal object GetCategories(DataTableAjaxRequestModel tableModel)
        {
            var data = _categoryService.GetCategories(
                tableModel.PageIndex, 
                tableModel.PageSize, 
                tableModel.SearchText, 
                tableModel.GetSortText(new string[] { "Name" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(int id)
        {
            var deleteCategory = _categoryService.DeleteCategory(id);
            return deleteCategory.Name;
        }
    }
}
