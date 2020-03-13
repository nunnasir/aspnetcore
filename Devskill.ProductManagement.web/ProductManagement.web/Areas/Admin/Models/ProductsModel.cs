using Devskill.Product.Framework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.web.Areas.Admin.Models
{
    public class ProductsModel : AdminBaseModel
    {
        private readonly IProductService _productService;
        public ProductsModel(IConfiguration configuration)
        {
            _productService = new ProductService(configuration.GetConnectionString("DefaultConnection"));
        }

        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _productService.GetProducts(
                    tableModel.PageIndex,
                    tableModel.PageSize,
                    tableModel.SearchText,
                    tableModel.GetSortText(new string[] { "Name", "Description", "Price" })
                );

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from product in data.records
                        select new string[]
                        {
                            //product.Id.ToString(),
                            product.Name,
                            product.Description,
                            product.Price.ToString()
                        }).ToArray()
            };
        }
    }
}
