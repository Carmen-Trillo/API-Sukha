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
        Task<int> InsertCustomer(CustomerItem customerItem);
        Task UpdateCustomer(CustomerItem customerItem);
        Task DeleteCustomer(int id);
        Task<List<CustomerItem>> GetAllCustomers();
        Task<List<CustomerItem>> GetCustomersByCriteria(CustomerFilter customerFilter);
    }
}
