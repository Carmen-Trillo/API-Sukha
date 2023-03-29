using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICustomerLogic
    {
        Task<int> InsertCustomerAsync(CustomerItem customerItem);
        Task UpdateCustomerAsync(CustomerItem customerItem);
        Task DeleteCustomerAsync(int id);
        Task<List<CustomerItem>> GetAllCustomersAsync();
        Task<CustomerItem> GetCustomerByIdAsync(int id);
        Task<List<CustomerItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter);
    }
}
