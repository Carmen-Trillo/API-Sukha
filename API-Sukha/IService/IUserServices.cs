using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IUserServices
    {
        Task<int> InsertUserAsync(NewUserRequest newUserRequest);
        Task UpdateUserAsync(UserItem userItem);
        Task DeleteUserAsync(int id);
        Task<List<UserItem>> GetAllUsersAsync();
        Task<List<UserItem>> GetUsersByCriteriaAsync(UserFilter userFilter);
    }
}
