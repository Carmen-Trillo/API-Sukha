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
    public class RolLogic : IRolLogic
    {
        private readonly ServiceContext _serviceContext;
        public RolLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertRolAsync(RolItem rolItem)
        {
            await _serviceContext.Roles.AddAsync(rolItem);
            await _serviceContext.SaveChangesAsync();
            return rolItem.Id;
        }

        public async Task UpdateRolAsync(RolItem rolItem)
        {
            _serviceContext.Roles.Update(rolItem);

            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteRolAsync(int id)
        {
            var rolToDelete = await _serviceContext.Set<RolItem>()
                .Where(u => u.Id == id).FirstAsync();

            rolToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();

        }


        public async Task <List<RolItem>> GetAllRolesAsync()
        {
            return await _serviceContext.Set<RolItem>().ToListAsync();
        }
    }
}
