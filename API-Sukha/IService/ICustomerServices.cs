using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface ICustomerServices
    {
        Task<int> InsertCustomerAsync(CustomerItem customerItem);
        Task UpdateCustomerAsync(CustomerItem customerItem);
        Task DeleteCustomerAsync(int id);
        Task<List<CustomerItem>> GetAllCustomersAsync();
        Task<CustomerItem> GetCustomerByIdAsync(int id);
        Task<List<CustomerItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter);
    }
}
