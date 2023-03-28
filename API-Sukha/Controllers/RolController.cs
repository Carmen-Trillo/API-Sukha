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
        private readonly ILogger<RolController> _logger;
        private readonly IRolServices _rolServices;
        public RolController(ILogger<RolController> logger, IRolServices rolServices)
        {
            _logger = logger;
            _rolServices = rolServices;
        }

        /*private ISecurityServices _securityServices;
        private IRolServices _rolServices;
        public RolController(ISecurityServices securityServices, IRolServices rolServices)
        {
            _securityServices = securityServices;
            _rolServices = rolServices;
        }*/

        [HttpPost(Name = "InsertarRol")]
        public async Task<int> PostAsync([FromBody] RolItem rolItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _rolServices.InsertRolAsync(rolItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "VerRoles")]
        public async Task<List<RolItem>> GetAllRolesAsync()
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword*/
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _rolServices.GetAllRolesAsync();
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpPatch(Name = "ModificarRol")]
        public async Task PatchAsync([FromBody] RolItem rolItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _rolServices.UpdateRolAsync(rolItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpDelete(Name = "EliminarRol")]
        public async Task DeleteAsync([FromQuery] int id)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _rolServices.DeleteRolAsync(id);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }
    }
}