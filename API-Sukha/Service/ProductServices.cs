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
    public async Task<int> InsertProduct(NewProductRequest newProductRequest)
    {
        var newProductItem = newProductRequest.ToProductItem();
        return await _productLogic.InsertProduct(newProductItem);
    }
    public async Task<List<ProductItem>> GetAllProducts()
    {
        return await _productLogic.GetAllProducts();
    }
    public async Task<List<ProductItem>> GetProductsByCriteria(ProductFilter productFilter)
    {
        return await _productLogic.GetProductsByCriteria(productFilter);
    }

    public async Task<List<ProductItem>> GetProductsByMarca(string marca)
    {
        return await _productLogic.GetProductsByMarca(marca);
    }

    public async Task  UpdateProduct(NewProductRequest newProductRequest)
    {
        var newProductItem = newProductRequest.ToProductItem();
        await _productLogic.UpdateProduct(newProductItem);
    }

    public async Task DeleteProduct(int id)
    {
        await _productLogic.DeleteProduct(id);
    }

    public async Task<ProductItem> GetProductById(int id)
    {
        return await _productLogic.GetProductById(id);
    }
}

