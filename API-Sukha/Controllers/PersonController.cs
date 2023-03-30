using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using API_Sukha.Services;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personServices;
        public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
        {
            _logger = logger;
            _personServices = personServices;
        }

        [HttpPost(Name = "InsertPerson")]
        public async Task<int> PostAsync([FromBody] PersonItem personItem)
        {
            
                return await _personServices.InsertPersonAsync(personItem);
            
        }

        [HttpGet(Name = "GetAllPersons")]
        public async Task<List<PersonItem>> GetAllPersonsAsync()
        {
            
                return await _personServices.GetAllPersonsAsync();
            
        }

        [HttpGet(Name = "GetPersonById")]
        public async Task<PersonItem> GetPersonByIdAsync(int id)
        {
            
                return await _personServices.GetPersonByIdAsync(id);
            
        }

        [HttpPatch(Name = "UpdatePerson")]
        public async Task PatchAsync([FromBody] PersonItem personItem)
        {
            
                await _personServices.UpdatePersonAsync(personItem);
           
        }

        [HttpDelete(Name = "DeletePerson")]
        public async Task DeleteAsync([FromQuery] int id)
        {
           
                await _personServices.DeletePersonAsync(id);
           
        }

        /*[HttpGet(Name = "MostrarPersonaPorFiltro")]
        public List<PersonaItem> GetByCriteria([FromHeader] string usuarioUser, [FromHeader] string usuarioPassword, [FromQuery] PersonaFilter personaFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUser, usuarioPassword, 1);
            if (validCredentials == true)
            {
                return _personaServices.GetPersonasByCriteria(personaFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }*/
    }
}
