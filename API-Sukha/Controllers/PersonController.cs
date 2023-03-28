using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Sukha.IServices;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
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

        /*private ISecurityServices _securityServices;
        private IPersonServices _personServices;
        public PersonController(ISecurityServices securityServices, IPersonServices personServices)
        {
            _securityServices = securityServices;
            _personServices = personServices;
        }*/

        [HttpPost(Name = "InsertarPersona")]
        public async Task<int> PostAsync([FromBody] PersonItem personItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _personServices.InsertPersonAsync(personItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "VerPersonas")]
        public async Task<List<PersonItem>> GetAllPersonsAsync()
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword*/
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _personServices.GetAllPersonsAsync();
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpPatch(Name = "ModificarPersona")]
        public async Task PatchAsync([FromBody] PersonItem personItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _personServices.UpdatePersonAsync(personItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpDelete(Name = "EliminarPersona")]
        public async Task DeleteAsync([FromQuery] int id)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _personServices.DeletePersonAsync(id);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        /*[HttpGet(Name = "MostrarPersonaPorFiltro")]
        public List<PersonaItem> GetByCriteria([FromHeader] string usuarioUsuario, [FromHeader] string usuarioPassword, [FromQuery] PersonaFilter personaFilter)
        {
            var validCredentials = _securityServices.ValidateUsuarioCredentials(usuarioUsuario, usuarioPassword, 1);
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
