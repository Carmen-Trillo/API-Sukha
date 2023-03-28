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
        public async Task<int> InsertCustomer(CustomerItem customerItem)
        {
            await _customerLogic.InsertCustomer(customerItem);
            return customerItem.Id;
        }
        public async Task<List<CustomerItem>> GetAllCustomers()
        {
            return await _customerLogic.GetAllCustomers();
        }
        public async Task<List<CustomerItem>> GetCustomersByCriteria(CustomerFilter customerFilter)
        {
            return await _customerLogic.GetCustomersByCriteria(customerFilter);
        }

        public async Task UpdateCustomer(CustomerItem customerItem)
        {
            await _customerLogic.UpdateCustomer(customerItem);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerLogic.DeleteCustomer(id);
        }
    }
}