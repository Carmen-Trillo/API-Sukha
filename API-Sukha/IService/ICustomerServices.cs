using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface ICustomerServices
    {
        Task<int> InsertCustomerAsync(CustomerTypeItem customerItem);
        Task UpdateCustomerAsync(CustomerTypeItem customerItem);
        Task DeleteCustomerAsync(int id);
        Task<List<CustomerTypeItem>> GetAllCustomersAsync();
        Task<CustomerTypeItem> GetCustomerByIdAsync(int id);
        Task<List<CustomerTypeItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter);
    }
}
