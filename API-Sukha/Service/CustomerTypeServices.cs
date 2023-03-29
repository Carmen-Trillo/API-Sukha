using API_Sukha.IServices;
using Entities.Entities;
using Logic.ILogic;
using Logic.Logic;

namespace API_Sukha.Services
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly ICustomerTypeLogic _customerTypeLogic;
        public CustomerTypeServices(ICustomerTypeLogic customerTypeLogic)
        {
            _customerTypeLogic = customerTypeLogic;
        }

        public async Task DeleteCustomerTypeAsync(int id)
        {
            await _customerTypeLogic.DeleteCustomerTypeAsync(id);
        }

        public async Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync()
        {
            return await _customerTypeLogic.GetAllCustomerTypesAsync();
        }
        public async Task<CustomerTypeItem> GetCustomerTypeByIdAsync(int id)
        {
            return await _customerTypeLogic.GeCustomerTypeByIdAsync(id);
        }
        public async Task<int> InsertCustomerTypeAsync(CustomerTypeItem customerTypeItem)
        {
            await _customerTypeLogic.InsertCustomerTypeAsync(customerTypeItem);
            return customerTypeItem.Id;
        }

        public async Task UpdateCustomerTypeAsync(CustomerTypeItem customerTypeItem)
        {
            await _customerTypeLogic.UpdateCustomerTypeAsync(customerTypeItem);
        }

    }
}
