using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using API_Sukha.Services;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ILogger<CustomerTypeController> _logger;
        private readonly ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ILogger<CustomerTypeController> logger, ICustomerTypeServices customerTypeServices)
        {
            _logger = logger;
            _customerTypeServices = customerTypeServices;
        }


        [HttpPost(Name = "InsertCustomerType")]
        public async Task<int> PostAsync([FromBody] CustomerTypeItem customerTypeItem)
        {
                return await _customerTypeServices.InsertCustomerTypeAsync(customerTypeItem);

        }

        [HttpGet(Name = "GetAllCustomerTypes")]
        public async Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync()
        {
           
                return await _customerTypeServices.GetAllCustomerTypesAsync();
            
        }

        [HttpGet(Name = "GetCustomerTypeById")]
        public async Task<CustomerTypeItem> GetCustomerTypeByIdAsync([FromBody] int id)
        {
            
                return await _customerTypeServices.GetCustomerTypeByIdAsync(id);
            
        }

        [HttpPatch(Name = "UpdateCustomerType")]
        public async Task PatchAsync([FromBody] CustomerTypeItem customerTypeItem)
        {
            
                await _customerTypeServices.UpdateCustomerTypeAsync(customerTypeItem);
            
        }

        [HttpDelete(Name = "DeleteCustomerType")]
        public async Task DeleteAsync([FromQuery] int id)
        {
           
                await _customerTypeServices.DeleteCustomerTypeAsync(id);
            
        }
    }
}
