using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface ICustomerServices
    {
        Task<int> InsertCustomer(CustomerItem customerItem);
        Task UpdateCustomer(CustomerItem customerItem);
        Task DeleteCustomer(int id);
        Task<List<CustomerItem>> GetAllCustomers();
        Task<List<CustomerItem>> GetCustomersByCriteria(CustomerFilter customerFilter);
    }
}
