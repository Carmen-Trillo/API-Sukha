using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertUserAsync(UserItem userItem)
        {
            if (userItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            await _serviceContext.Users.AddAsync(userItem);
            await _serviceContext.SaveChangesAsync();
            return userItem.Id;
        }

        public async Task UpdateUserAsync(UserItem userItem)
        {
            _serviceContext.Users.Update(userItem);

            await _serviceContext.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _serviceContext.Set<UserItem>()
                 .Where(u => u.Id == id).FirstAsync();

            userToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();

        }

        public async Task<List<UserItem>> GetAllUsersAsync()
        {
            return await _serviceContext.Set<UserItem>().ToListAsync();
        }
        public async Task<UserItem> GetUserByIdAsync(int id)
        {
            return await _serviceContext.Set<UserItem>()
                    .Where(u => u.Id == id).FirstAsync();
        }
        public async Task<List<UserItem>> GetUsersByCriteriaAsync(UserFilter userFilter)
        {
            var resultList = _serviceContext.Set<UserItem>()
                  .Where(u => u.IsActive == true);

            if (userFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > userFilter.InsertDateFrom);
            }

            if (userFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < userFilter.InsertDateTo);
            }

            return await resultList.ToListAsync();
        }

        
    }
}
