using Entities.Entities;

namespace API_Sukha.IServices
{
    public interface IRolServices
    {
        Task<int> InsertRolAsync(RolItem rolItem);
        Task UpdateRolAsync(RolItem rolItem);
        Task DeleteRolAsync(int id);
        Task<List<RolItem>> GetAllRolesAsync();
    }
}
