using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using API_Sukha.IServices;
using System.Security.Authentication;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerServices _customerServices;
        public CustomerController(ILogger<CustomerController> logger, ICustomerServices customerServices)
        {
            _logger = logger;
            _customerServices = customerServices;
        }

        [HttpPost(Name = "InsertCustomer")]
        public async Task<int> PostAsync([FromBody] CustomerItem customerItem)
        {

                return await _customerServices.InsertCustomerAsync(customerItem);

        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<List<CustomerItem>> GetAllCustomersAsync()
        {
                return await _customerServices.GetAllCustomersAsync();

        }

        [HttpGet(Name = "GetCustomerById")]
        public async Task<CustomerItem> GetCustomerByIdAsync(int id)
           
        {
            return await _customerServices.GetCustomerByIdAsync(id);

        }

        [HttpGet(Name = "GetCustomerByCriteria")]
        public async Task<List<CustomerItem>> GetCustomersByCriteriaAsync([FromQuery] CustomerFilter customerFilter)
        {
                return await _customerServices.GetCustomersByCriteriaAsync(customerFilter);

        }

        [HttpPatch(Name = "UpdateCustomer")]
        public async Task UpdateCustomerAsync([FromBody] CustomerItem customerItem)
        {

                await _customerServices.UpdateCustomerAsync(customerItem);

        }

        [HttpDelete(Name = "DeleteCustomer")]
        public async Task DeleteCustomer([FromQuery] int id)
        {
                await _customerServices.DeleteCustomerAsync(id);
           
        }
    }
}

