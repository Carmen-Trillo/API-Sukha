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
        /*private readonly ILogger<RolController> _logger;
        private readonly IUserServices _userServices;
        public UserController(ILogger<RolController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }*/

        private ISecurityServices _securityServices;
        private IUserServices _userServices;
        public UserController(ISecurityServices securityServices, IUserServices userServices)
        {
            _securityServices = securityServices;
            _userServices = userServices;
        }

        [HttpPost(Name = "InsertUser")]
        public async Task<int> PostAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] NewUserRequest newUserRequest)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _userServices.InsertUserAsync(newUserRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<List<UserItem>> GetAllUsersAsync([FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _userServices.GetAllUsersAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetUserById")]
        public async Task<UserItem> GetUserByIdAsync(int id, [FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _userServices.GetUserByIdAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetUsersByCriteria")]
        public async Task<List<UserItem>> GetUsersByCriteriaAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] UserFilter userFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _userServices.GetUsersByCriteriaAsync(userFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateUser")]
        public async Task PatchAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] UserItem userItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _userServices.UpdateUserAsync(userItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


        [HttpDelete(Name = "DeleteUser")]
        public async Task DeleteAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _userServices.DeleteUserAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}
