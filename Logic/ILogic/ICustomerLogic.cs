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
        Task<int> InsertCustomerAsync(CustomerTypeItem customerItem);
        Task UpdateCustomerAsync(CustomerTypeItem customerItem);
        Task DeleteCustomerAsync(int id);
        Task<List<CustomerTypeItem>> GetAllCustomersAsync();
        Task<CustomerTypeItem> GetCustomerByIdAsync(int id);
        Task<List<CustomerTypeItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter);
    }
}
