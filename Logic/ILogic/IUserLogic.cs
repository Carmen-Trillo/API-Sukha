using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IUserLogic
    {
        Task <int> InsertUserAsync(UserItem userItem);
        Task UpdateUserAsync(UserItem userItem);
        Task DeleteUserAsync(int id);
        Task <List<UserItem>> GetAllUsersAsync();
        Task <List<UserItem>> GetUsersByCriteriaAsync(UserFilter userFilter);
    }
}
