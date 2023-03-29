using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IRolLogic
    {
        Task<int> InsertRolAsync(RolItem rolItem);
        Task UpdateRolAsync(RolItem rolItem);
        Task DeleteRolAsync(int id);
        Task<List<RolItem>> GetAllRolesAsync();
        Task<RolItem> GetRolByIdAsync(int id);
    }
}
