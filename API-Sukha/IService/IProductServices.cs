using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IProductServices
    {
        Task<int> InsertProductAsync(ProductItem productItem);
        Task UpdateProductAsync(ProductItem productItem);
        Task DeleteProductAsync(int id);
        Task<List<ProductItem>> GetAllProductsAsyn();
        Task<ProductItem> GetProductByIdAsync(int id);
        Task<List<ProductItem>> GetProductsByCriteriaAsync(ProductFilter productFilter);
        Task<List<ProductItem>> GetProductsByBrandAsync(string marca);
    }
}
