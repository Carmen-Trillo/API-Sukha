using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICustomerTypeLogic
    {
        Task<int> InsertCustomerTypeAsync(CustomerTypeItem customerTypeItem);
        Task UpdateCustomerTypeAsync(CustomerTypeItem customerTypeItem);
        Task DeleteCustomerTypeAsync(int id);
        Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync();
    }
}
