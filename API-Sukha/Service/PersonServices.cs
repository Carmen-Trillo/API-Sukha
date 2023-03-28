using Entities.Entities;
using Logic.ILogic;
using API_Sukha.IServices;
using Logic.Logic;

namespace API_Sukha.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonLogic _personLogic;
        public PersonServices(IPersonLogic personLogic)
        {
            _personLogic = personLogic;
        }


        public async Task<int> InsertPersonAsync(PersonItem personItem)
        {
            await _personLogic.InsertPersonAsync(personItem);
            return personItem.Id;
        }


        public async Task UpdatePersonAsync(PersonItem personItem)
        {
            await _personLogic.UpdatePersonAsync(personItem);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personLogic.DeletePersonAsync(id);
        }

        public async Task<List<PersonItem>> GetAllPersonsAsync()
        {
            return await _personLogic.GetAllPersonsAsync();
        }



    }
}
