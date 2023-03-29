using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using API_Sukha.IServices;
using System.Security.Authentication;
using Entities.SearchFilters;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        /*private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerServices _customerServices;
        public CustomerController(ILogger<CustomerController> logger, ICustomerServices customerServices)
        {
            _logger = logger;
            _customerServices = customerServices;
        }*/

        private ISecurityServices _securityServices;
        private ICustomerServices _customerServices;
        public CustomerController(ISecurityServices securityServices, ICustomerServices customerServices)
        {
            _securityServices = securityServices;
            _customerServices = customerServices;
        }

        [HttpPost(Name = "InsertCustomer")]
        public async Task<int> PostAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.InsertCustomerAsync(customerItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<List<CustomerTypeItem>> GetAllCustomersAsync([FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.GetAllCustomersAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetCustomerById")]
        public async Task<CustomerTypeItem> GetCustomerByIdAsync([FromHeader] string userUser, [FromHeader] string userPassword,int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
            return await _customerServices.GetCustomerByIdAsync(id);
            }
        }

        [HttpGet(Name = "GetCustomerByCriteria")]
        public async Task<List<CustomerTypeItem>> GetCustomersByCriteriaAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] CustomerFilter customerFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.GetCustomersByCriteriaAsync(customerFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateCustomer")]
        public async Task UpdateCustomerAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _customerServices.UpdateCustomerAsync(customerItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public async Task DeleteCustomer([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _customerServices.DeleteCustomerAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}

