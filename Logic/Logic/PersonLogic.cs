using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PersonLogic : IPersonLogic
    {
        private readonly ServiceContext _serviceContext;
        public PersonLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertPersonAsync(PersonItem personItem)
        {
            await _serviceContext.Persons.AddAsync (personItem);
            await _serviceContext.SaveChangesAsync();
            return personItem.Id;
        }

        public async Task UpdatePersonAsync(PersonItem personItem)
        {
            _serviceContext.Persons.Update(personItem);

            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var personaToDelete = await _serviceContext.Set<PersonItem>()
                .Where(u => u.Id == id).FirstAsync();

            personaToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();

        }


        public async Task<List<PersonItem>> GetAllPersonsAsync()
        {
            return await _serviceContext.Set<PersonItem>().ToListAsync();
        }
    }
    
}

