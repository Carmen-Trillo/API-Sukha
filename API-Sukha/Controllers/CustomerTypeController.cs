using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
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

        /*private ISecurityServices _securityServices;
        private ICustomerTypeServices _customerTypeServices;
        public CustomerTypeController(ISecurityServices securityServices, ICustomerTypeServices customerTypeServices)
        {
            _securityServices = securityServices;
            _customerTypeServices = customerTypeServices;
        }*/

        [HttpPost(Name = "InsertarTipoCliente")]
        public async Task<int> PostAsync([FromBody] CustomerTypeItem customerTypeItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _customerTypeServices.InsertCustomerTypeAsync(customerTypeItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "VerTipoCliente")]
        public async Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync()
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword*/
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _customerTypeServices.GetAllCustomerTypesAsync();
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpPatch(Name = "ModificarTipoCliente")]
        public async Task PatchAsync([FromBody] CustomerTypeItem customerTypeItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _customerTypeServices.UpdateCustomerTypeAsync(customerTypeItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpDelete(Name = "EliminarTipoCliente")]
        public async Task DeleteAsync([FromQuery] int id)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _customerTypeServices.DeleteCustomerTypeAsync(id);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }
    }
}
