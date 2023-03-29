using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolController : ControllerBase
    {
        /*private readonly ILogger<RolController> _logger;
        private readonly IRolServices _rolServices;
        public RolController(ILogger<RolController> logger, IRolServices rolServices)
        {
            _logger = logger;
            _rolServices = rolServices;
        }*/

        private ISecurityServices _securityServices;
        private IRolServices _rolServices;
        public RolController(ISecurityServices securityServices, IRolServices rolServices)
        {
            _securityServices = securityServices;
            _rolServices = rolServices;
        }

        [HttpPost(Name = "InsertRol")]
        public async Task<int> PostAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] RolItem rolItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _rolServices.InsertRolAsync(rolItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllRoles")]
        public async Task<List<RolItem>> GetAllRolesAsync([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _rolServices.GetAllRolesAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateRol")]
        public async Task PatchAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] RolItem rolItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _rolServices.UpdateRolAsync(rolItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeleteRol")]
        public async Task DeleteAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _rolServices.DeleteRolAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}