using Entities.Entities;

namespace API_Sukha.IServices
{
    public interface ICustomerTypeServices
    {
        Task<int> InsertCustomerTypeAsync(CustomerTypeItem customerTypeItem);
        Task UpdateCustomerTypeAsync(CustomerTypeItem customerTypeItem);
        Task DeleteCustomerTypeAsync(int id);
        Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync();
    }
}
