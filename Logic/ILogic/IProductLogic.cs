using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductLogic
    {
        Task<int> InsertProduct(ProductItem productItem);
        Task UpdateProduct(ProductItem productItem);
        Task DeleteProduct(int id);
        Task DeleteProductMarca(string marca);
        Task<List<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(int id);
        Task<List<ProductItem>> GetProductsByCriteria(ProductFilter productFilter);
        Task<List<ProductItem>> GetProductsByMarca(string marca);
        Task<List<ProductItem>> GetProductsByCategory(string category);
    }
}
