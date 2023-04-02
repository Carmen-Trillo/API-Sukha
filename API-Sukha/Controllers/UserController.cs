using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using Entities.SearchFilters;
using Resource.RequestModels;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using IdentityServer3.Core.ViewModels;
using IdentityServer3.Core.Services;
using Microsoft.IdentityModel.Protocols.WSIdentity;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly IUserServices _userServices;
        /*private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;*/
        public UserController(ILogger<RolController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
            //_userManager = UserManager;
            //_tokenService = TokenService;
        }


        [HttpPost(Name = "InsertUser")]
        public async Task<int> PostAsync([FromBody] UserItem userItem)
        {

                return await _userServices.InsertUserAsync(userItem);
            
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<List<UserItem>> GetAllUsersAsync()
        {
            
                return await _userServices.GetAllUsersAsync();
            
        }

        [HttpGet(Name = "GetUserById")]
        public async Task<UserItem> GetUserByIdAsync(int id)
        {
            
                return await _userServices.GetUserByIdAsync(id);
            
        }

        [HttpGet(Name = "GetUsersByCriteria")]
        public async Task<List<UserItem>> GetUsersByCriteriaAsync([FromQuery] UserFilter userFilter)
        {
           
                return await _userServices.GetUsersByCriteriaAsync(userFilter);
            
        }

        [HttpPatch(Name = "UpdateUser")]
        public async Task PatchAsync([FromBody] UserItem userItem)
        {
            
                await _userServices.UpdateUserAsync(userItem);
            
        }


        [HttpDelete(Name = "DeleteUser")]
        public async Task DeleteAsync([FromQuery] int id)
        {
            
                await _userServices.DeleteUserAsync(id);
            
        }
        /*[HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.RoleId.ToString()) // Agregar el idRol del usuario como una claim
            };

            var token = _tokenService.GenerateToken(claims); // Generar un token de sesión utilizando algún servicio de tokens

            return Ok(new { token, role = user.RoleId });
        }

        [Authorize(Roles = "1")] // Solo los usuarios con idRol = 1 pueden acceder a este endpoint
        [HttpGet("admin")]
        public ActionResult Admin()
        {
            return Ok("Bienvenido, administrador!");
        }

        [Authorize(Roles = "2")] // Solo los usuarios con idRol = 2 pueden acceder a este endpoint
        [HttpGet("profile")]
        public ActionResult Profile()
        {
            return Ok("Bienvenido a tu perfil de usuario!");
        }*/

    }
}
