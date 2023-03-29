using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerLogic _customerLogic;
        public CustomerServices(ICustomerLogic customerLogic)
        {
            _customerLogic = customerLogic;
        }
        public async Task<int> InsertCustomerAsync(CustomerItem customerItem)
        {
            await _customerLogic.InsertCustomerAsync(customerItem);
            return customerItem.Id;
        }
        public async Task<List<CustomerItem>> GetAllCustomersAsync()
        {
            return await _customerLogic.GetAllCustomersAsync();
        }

        public async Task<CustomerItem> GetCustomerByIdAsync(int id)
        {
            return await _customerLogic.GetCustomerByIdAsync(id);
        }
        public async Task<List<CustomerItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter)
        {
            return await _customerLogic.GetCustomersByCriteriaAsync(customerFilter);
        }

        public async Task UpdateCustomerAsync(CustomerItem customerItem)
        {
            await _customerLogic.UpdateCustomerAsync(customerItem);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerLogic.DeleteCustomerAsync(id);
        }
    }
}