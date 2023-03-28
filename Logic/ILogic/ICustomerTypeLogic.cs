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
        Task<int> InsertCustomerType(CustomerTypeItem customerTypeItem);
        Task UpdateCustomerType(CustomerTypeItem customerTypeItem);
        Task DeleteCustomerType(int id);
        Task<List<CustomerTypeItem>> GetAllCustomerTypes();
    }
}
