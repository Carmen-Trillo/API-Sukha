using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        /*private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;
        public ProductController(ILogger<ProductController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }*/

        private ISecurityServices _securityServices;
        private IProductServices _productServices;
        public ProductController(ISecurityServices securityServices, IProductServices productServices)
        {
            _securityServices = securityServices;
            _productServices = productServices;
        }

        [HttpPost(Name = "InsertProduct")]
        public async Task<int> PostAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] ProductItem productItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _productServices.InsertProductAsync(productItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<List<ProductItem>> GetAllProductsAsync([FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _productServices.GetAllProductsAsyn();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetProductsByCriteria")]
        public async Task<List<ProductItem>> GetProductsByCriteriaAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] ProductFilter productFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _productServices.GetProductsByCriteriaAsync(productFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetProductById")]
        public async Task<ProductItem> GetProductByIdAsync(int id, [FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _productServices.GetProductByIdAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetProductsByBrand")]
        public async Task<List<ProductItem>> GetProductsByBrandAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] string marca)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _productServices.GetProductsByBrandAsync(marca);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateProduct")]
        public async Task PatchAsync(int id, [FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] ProductItem productItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                var productToUpdate = _productServices.GetProductByIdAsync(id);
                await _productServices.UpdateProductAsync(productItem);
            }
            else
            {
                    throw new InvalidCredentialException();
         
            }
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task DeleteAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
               await _productServices.DeleteProductAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

    }

}