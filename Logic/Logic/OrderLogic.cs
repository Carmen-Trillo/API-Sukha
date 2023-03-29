using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ServiceContext _serviceContext;
        public OrderLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public async Task <int> InsertOrderAsync(OrderItem orderItem)
        {
            //get para comprobar que la cantida pedido<=sctok, añadir el pedido y despés hacer un update que modifique el stock
            await _serviceContext.Orders.AddAsync(orderItem);
            await _serviceContext.SaveChangesAsync();
            return orderItem.Id;
        }

        public async Task UpdateOrderAsync(OrderItem orderItem)
        {
            _serviceContext.Orders.Update(orderItem);

            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderToDelete = await _serviceContext.Set<OrderItem>()
                .Where(p => p.Id == id).FirstAsync();

            orderToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();

        }

        public async Task <List<OrderItem>> GetAllOrdersAsync()
        {
            return await _serviceContext.Set<OrderItem>().ToListAsync();
        }

        public async Task<List<OrderItem>> GetOrdersByCriteriaAsync(OrderFilter orderFilter)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.IsActive == true);

            if (orderFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(p => p.DateOrder > orderFilter.InsertDateFrom);
            }

            if (orderFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(p => p.DateOrder < orderFilter.InsertDateTo);
            }
            if (orderFilter.TotalAmountFrom != null)
            {
                resultList = resultList.Where(p => p.TotalAmount > orderFilter.TotalAmountFrom);
            }

            if (orderFilter.TotalAmountTo != null)
            {
                resultList = resultList.Where(p => p.TotalAmount < orderFilter.TotalAmountTo);
            }

            if (orderFilter.DeliveryDateFrom != null)
            {
                resultList = resultList.Where(p => p.DeliveryDate > orderFilter.DeliveryDateFrom);
            }

            if (orderFilter.DeliveryDateTo != null)
            {
                resultList = resultList.Where(p => p.DeliveryDate < orderFilter.DeliveryDateTo);
            }

            return await resultList.ToListAsync();

        }

        public async Task <List<OrderItem>> GetOrdersByCustomerAsync(int idCustomer)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                        .Where(p => p.IdCustomer == idCustomer);
            return await resultList.ToListAsync();
        }
        public async Task<OrderItem> GetOrderByIdAsync(int id)
        {
            return await _serviceContext.Set<OrderItem>()
                    .Where(u => u.Id == id).FirstAsync();
        }

        public async Task <List<OrderItem>> GetOrdersByProductAsync(int idProduct)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                        .Where(p => p.IdProduct == idProduct);
            return resultList.ToList();
        }

        public async Task<List<OrderItem>> GetOrdersByPaidAsync(bool paid)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Paid == true);
            var resultListNoPagados = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Paid == false);

            if (paid == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoPagados.ToList();
            }
        }
        public async Task <List<OrderItem>> GetOrdersByDeliveredAsync(bool delivered)
        {
            var resultList = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Delivered == true);
            var resultListNoEntregados = _serviceContext.Set<OrderItem>()
                                            .Where(p => p.Delivered == false);

            if (delivered == true)
            {
                return resultList.ToList();
            }
            else
            {
                return resultListNoEntregados.ToList();
            }
        }
    }
}