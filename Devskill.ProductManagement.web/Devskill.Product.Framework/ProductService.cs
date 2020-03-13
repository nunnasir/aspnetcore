using Devskill.Product.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devskill.Product.Framework
{
    public class ProductService : IProductService
    {
        private string _connectionString;
        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            using var dbProvider = new SqlServerDataProvider<Product>(_connectionString);

            var products = dbProvider.GetData("Select * from Product");

            var filterproducts = products.Where(x => x.Name.Contains(searchText) || x.Description.Contains(searchText) || x.Price.ToString().Contains(searchText));

            var filterProductCount = filterproducts.Count();

            var totalProducts = products.Count();

            var filterProductList = filterproducts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return (filterProductList, totalProducts, filterProductCount);
        }
    }
}
