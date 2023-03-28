using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;

namespace API_Sukha.Services
{
    public class RolServices : IRolServices
    {
        private readonly IRolLogic _rolLogic;
        public RolServices(IRolLogic rolLogic)
        {
            _rolLogic = rolLogic;
        }

        public async Task DeleteRolAsync(int id)
        {
            await _rolLogic.DeleteRolAsync(id);
        }

        public async Task<List<RolItem>> GetAllRolesAsync()
        {
            return await _rolLogic.GetAllRolesAsync();
        }

        public async Task<int> InsertRolAsync(RolItem rolItem)
        {
            await _rolLogic.InsertRolAsync(rolItem);
            return rolItem.Id;
        }

        public async Task UpdateRolAsync(RolItem rolItem)
        {
            await _rolLogic.UpdateRolAsync(rolItem);
        }
    }
}
