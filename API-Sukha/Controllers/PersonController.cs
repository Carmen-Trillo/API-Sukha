using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;
using API_Sukha.Services;

namespace API_Sukha.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        /*private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personServices;
        public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
        {
            _logger = logger;
            _personServices = personServices;
        }*/

        private ISecurityServices _securityServices;
        private IPersonServices _personServices;
        public PersonController(ISecurityServices securityServices, IPersonServices personServices)
        {
            _securityServices = securityServices;
            _personServices = personServices;
        }

        [HttpPost(Name = "InsertPerson")]
        public async Task<int> PostAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _personServices.InsertPersonAsync(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllPersons")]
        public async Task<List<PersonItem>> GetAllPersonsAsync([FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _personServices.GetAllPersonsAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetPersonById")]
        public async Task<PersonItem> GetPersonByIdAsync(int id, [FromHeader] string userUser, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                return await _personServices.GetPersonByIdAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdatePerson")]
        public async Task PatchAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _personServices.UpdatePersonAsync(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeletePerson")]
        public async Task DeleteAsync([FromHeader] string userUser, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUser, userPassword, 1);
            if (validCredentials == true)
            {
                await _personServices.DeletePersonAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
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
