using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly IUserServices _userServices;
        public UserController(ILogger<RolController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        /*private ISecurityServices _securityServices;
        private IUserServices _userServices;
        public UserController(ISecurityServices securityServices, IUserServices userServices)
        {
            _securityServices = securityServices;
            _userServices = userServices;
        }*/

        [HttpPost(Name = "InsertarUsuarios")]
        public async Task<int> PostAsync([FromBody] NewUserRequest newUserRequest)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _userServices.InsertUserAsync(newUserRequest);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "VerUsuarios")]
        public async Task<List<UserItem>> GetAllUsersAsync()
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword*/
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _userServices.GetAllUsersAsync();
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarUsuarioPorFiltro")]
        public async Task<List<UserItem>> GetUsersByCriteriaAsync([FromQuery] UserFilter userFilter)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _userServices.GetUsersByCriteriaAsync(userFilter);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpPatch(Name = "ModificarUsuario")]
        public async Task PatchAsync([FromBody] UserItem userItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _userServices.UpdateUserAsync(userItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }


        [HttpDelete(Name = "EliminarUsuario")]
        public async Task DeleteAsync([FromQuery] int id)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _userServices.DeleteUserAsync(id);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }
    }
}
