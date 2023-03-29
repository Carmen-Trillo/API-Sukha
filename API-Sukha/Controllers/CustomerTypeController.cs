using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using API_Sukha.Services;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerTypeController : ControllerBase
    {
        /*private readonly ILogger<CustomerTypeController> _logger;
        private readonly ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ILogger<CustomerTypeController> logger, ICustomerTypeServices customerTypeServices)
        {
            _logger = logger;
            _customerTypeServices = customerTypeServices;
        }*/

        private ISecurityServices _securityServices;
        private ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ISecurityServices securityServices, ICustomerTypeServices customerTypeServices)
        {
            _securityServices = securityServices;
            _customerTypeServices = customerTypeServices;
        }

        [HttpPost(Name = "InsertCustomerType")]
        public async Task<int> PostAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerTypeItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerTypeServices.InsertCustomerTypeAsync(customerTypeItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllCustomerTypes")]
        public async Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerTypeServices.GetAllCustomerTypesAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetCustomerTypeById")]
        public async Task<CustomerTypeItem> GetCustomerTypeByIdAsync(int id, [FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _customerTypeServices.GetCustomerTypeByIdAsync(id);
            }
        }

        [HttpPatch(Name = "UpdateCustomerType")]
        public async Task PatchAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] CustomerTypeItem customerTypeItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _customerTypeServices.UpdateCustomerTypeAsync(customerTypeItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeleteCustomerType")]
        public async Task DeleteAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _customerTypeServices.DeleteCustomerTypeAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
