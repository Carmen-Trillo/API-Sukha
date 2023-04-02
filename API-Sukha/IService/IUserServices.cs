using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IUserServices
    {
        Task<int> InsertUserAsync(UserItem userItem);
        Task UpdateUserAsync(UserItem userItem);
        Task DeleteUserAsync(int id);
        Task<List<UserItem>> GetAllUsersAsync();
        Task<UserItem> GetUserByIdAsync(int id);
        Task<List<UserItem>> GetUsersByCriteriaAsync(UserFilter userFilter);
    }
}
