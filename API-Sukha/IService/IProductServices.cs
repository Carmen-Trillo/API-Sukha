using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IProductServices
    {
        Task<int> InsertProduct(NewProductRequest newProductRequest);
        Task UpdateProduct(NewProductRequest newProductRequest);
        Task DeleteProduct(int id);
        Task<List<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(int id);
        Task<List<ProductItem>> GetProductsByCriteria(ProductFilter productFilter);
        Task<List<ProductItem>> GetProductsByMarca(string marca);
    }
}
