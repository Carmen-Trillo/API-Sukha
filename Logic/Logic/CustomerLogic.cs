using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ServiceContext _serviceContext;
        public CustomerLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertCustomerAsync(CustomerTypeItem customerItem)
        {
            if (customerItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            await _serviceContext.Customers.AddAsync(customerItem);
            await _serviceContext.SaveChangesAsync();
            return customerItem.Id;
        }

        public async Task UpdateCustomerAsync(CustomerTypeItem customerItem)
        {
            _serviceContext.Customers.Update(customerItem);
            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerToDelete = await _serviceContext.Set<CustomerTypeItem>()
                 .Where(u => u.Id == id).FirstAsync();

            customerToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();
        }

        public async Task<List<CustomerTypeItem>> GetAllCustomersAsync()
        {
            return await _serviceContext.Set<CustomerTypeItem>().ToListAsync();
        }
        public async Task<CustomerTypeItem> GetCustomerByIdAsync(int id)
        {
            return await _serviceContext.Set<CustomerTypeItem>()
                    .Where(u => u.Id == id).FirstAsync();
        }
        public async Task<List<CustomerTypeItem>> GetCustomersByCriteriaAsync(CustomerFilter customerFilter)
        {
            var resultList = _serviceContext.Set<CustomerTypeItem>()
                                .Where(u => u.IsActive == true);

            if (customerFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > customerFilter.InsertDateFrom);
            }

            if (customerFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < customerFilter.InsertDateTo);
            }

            return await resultList.ToListAsync();
        }
    }
}

