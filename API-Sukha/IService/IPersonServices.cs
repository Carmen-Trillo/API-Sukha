﻿using Entities.Entities;
using Entities.SearchFilters;

namespace API_Sukha.IServices
{
    public interface IPersonServices
    {
        Task<int> InsertPersonAsync(PersonItem personItem);
        Task UpdatePersonAsync(PersonItem personItem);
        Task DeletePersonAsync(int id);
        Task <List<PersonItem>> GetAllPersonsAsync();

        //List<PersonItem> GetPersonByCriteria(PersonFilter personFilter);
    }
}
