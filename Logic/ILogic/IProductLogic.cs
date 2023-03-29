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
        Task<int> InsertProductAsync (ProductItem productItem);
        Task UpdateProductAsync (ProductItem productItem);
        Task DeleteProductAsync (int id);
        Task DeleteProductMarcaAsync (string marca);
        Task<List<ProductItem>> GetAllProductsAsync ();
        Task<ProductItem> GetProductByIdAsync (int id);
        Task<List<ProductItem>> GetProductsByCriteriaAsync (ProductFilter productFilter);
        Task<List<ProductItem>> GetProductsByBrandAsync(string marca);
        Task<List<ProductItem>> GetProductsByCategoryAsync (string category);
    }
}
