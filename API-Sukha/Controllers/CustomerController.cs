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
        private ISecurityServices _securityServices;
        private ICustomerServices _customerServices;
        public CustomerController(ISecurityServices securityServices, ICustomerServices customerServices)
        {
            _securityServices = securityServices;
            _customerServices = customerServices;
        }

        [HttpPost(Name = "InsertCustomer")]
        public async Task<int> Post([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] CustomerItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.InsertCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<List<CustomerItem>> GetAllCustomers([FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.GetAllCustomers();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetCustomerByCriteria")]
        public async Task<List<CustomerItem>> GetCustomersByCriteria([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] CustomerFilter customerFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerServices.GetCustomersByCriteria(customerFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateCustomer")]
        public async Task UpdateCustomer([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] CustomerItem customerItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _customerServices.UpdateCustomer(customerItem);
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
                await _customerServices.DeleteCustomer(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}

