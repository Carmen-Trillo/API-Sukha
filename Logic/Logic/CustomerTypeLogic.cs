using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class CustomerTypeLogic : ICustomerTypeLogic
    {
        private readonly ServiceContext _serviceContext;
        public CustomerTypeLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertCustomerTypeAsync(CustomerTypeItem customerTypeItem)
        {
            await _serviceContext.CustomerTypes.AddAsync(customerTypeItem);
            await _serviceContext.SaveChangesAsync();
            return customerTypeItem.Id;
        }

        public async Task UpdateCustomerTypeAsync(CustomerTypeItem customerTypeItem)
        {
            _serviceContext.CustomerTypes.Update(customerTypeItem);

            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerTypeAsync(int id)
        {
            var customerTypeToDelete = await _serviceContext.Set<CustomerTypeItem>()
                .Where(u => u.Id == id).FirstAsync();

            customerTypeToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();

        }

        public async Task<List<CustomerTypeItem>> GetAllCustomerTypesAsync()
        {
            return await _serviceContext.Set<CustomerTypeItem>().ToListAsync();
        }
    }
}
