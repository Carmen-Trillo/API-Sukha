using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        

        [HttpPost(Name = "InsertRol")]
        public async Task<int> PostAsync([FromBody] RolItem rolItem)
        {
            
                return await _rolServices.InsertRolAsync(rolItem);
            
        }

        [HttpGet(Name = "GetAllRoles")]
        public async Task<List<RolItem>> GetAllRolesAsync()
        {
           
                return await _rolServices.GetAllRolesAsync();
            
        }

        [HttpGet(Name = "GetRolById")]
        public async Task<RolItem> GetRolByIdAsync(int id)
        {
            
                return await _rolServices.GetRolByIdAsync(id);
            
        }

        [HttpPatch(Name = "UpdateRol")]
        public async Task PatchAsync([FromBody] RolItem rolItem)
        {
            
                await _rolServices.UpdateRolAsync(rolItem);
            
        }

        [HttpDelete(Name = "DeleteRol")]
        public async Task DeleteAsync([FromQuery] int id)
        {
            
                await _rolServices.DeleteRolAsync(id);
            
        }
    }
}