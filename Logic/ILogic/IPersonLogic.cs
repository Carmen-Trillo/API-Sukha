using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPersonLogic
    {
        Task<int> InsertPersonAsync(PersonItem personItem);
        Task UpdatePersonAsync(PersonItem personItem);
        Task DeletePersonAsync(int id);
        Task <List<PersonItem>> GetAllPersonsAsync();
        Task<PersonItem> GetPersonByIdAsync(int id);
    }
}
