using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace APIService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;
        public ProductController(ILogger<ProductController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }


        [HttpPost(Name = "InsertProduct")]
        public async Task<int> PostAsync([FromBody] ProductItem productItem)
        {
                return await _productServices.InsertProductAsync(productItem);
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<List<ProductItem>> GetAllProductsAsync()
        {
                return await _productServices.GetAllProductsAsyn();
        }

        [HttpGet(Name = "GetProductsByCriteria")]
        public async Task<List<ProductItem>> GetProductsByCriteriaAsync([FromQuery] ProductFilter productFilter)
        {
                return await _productServices.GetProductsByCriteriaAsync(productFilter);
        }

        [HttpGet(Name = "GetProductById")]
        public async Task<ProductItem> GetProductByIdAsync(int id)
        {
            
                return await _productServices.GetProductByIdAsync(id);
            
        }

        [HttpGet(Name = "GetProductsByBrand")]
        public async Task<List<ProductItem>> GetProductsByBrandAsync([FromQuery] string marca)
        {
     
                return await _productServices.GetProductsByBrandAsync(marca);
    
        }

        [HttpPatch(Name = "UpdateProduct")]
        public async Task PatchAsync(int id,ProductItem productItem)
        {

                var productToUpdate = _productServices.GetProductByIdAsync(id);
                await _productServices.UpdateProductAsync(productItem);

        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task DeleteAsync([FromQuery] int id)
        {
               await _productServices.DeleteProductAsync(id);

        }

    }

}