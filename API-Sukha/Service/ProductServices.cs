using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;
using System.Runtime.CompilerServices;

public class ProductServices : IProductServices
{
    private readonly IProductLogic _productLogic;
    public ProductServices(IProductLogic productLogic)
    {
        _productLogic = productLogic;
    }
    public async Task<int> InsertProductAsync(ProductItem productItem)
    {
        await _productLogic.InsertProductAsync(productItem);
        return productItem.Id;
    }
    public async Task<List<ProductItem>> GetAllProductsAsyn()
    {
        return await _productLogic.GetAllProductsAsync();
    }
    public async Task<List<ProductItem>> GetProductsByCriteriaAsync(ProductFilter productFilter)
    {
        return await _productLogic.GetProductsByCriteriaAsync(productFilter);
    }

    public async Task<List<ProductItem>> GetProductsByBrandAsync(string marca)
    {
        return await _productLogic.GetProductsByBrandAsync(marca);
    }

    public async Task  UpdateProductAsync(ProductItem productItem)
    {
        await _productLogic.UpdateProductAsync(productItem);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productLogic.DeleteProductAsync(id);
    }

    public async Task<ProductItem> GetProductByIdAsync(int id)
    {
        return await _productLogic.GetProductByIdAsync(id);
    }
}

