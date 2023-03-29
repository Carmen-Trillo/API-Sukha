using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IOrderLogic
    {
        Task <int> InsertOrderAsync(OrderItem orderItem);
        Task UpdateOrderAsync(OrderItem orderItem);
        Task DeleteOrderAsync(int id);
        Task <List<OrderItem>> GetAllOrdersAsync();
        Task <List<OrderItem>> GetOrdersByCriteriaAsync(OrderFilter orderFilter);
        Task <List<OrderItem>> GetOrdersByCustomerAsync(int idCustomer);
        Task <List<OrderItem>> GetOrdersByProductAsync(int idProduct);

        Task <List<OrderItem>> GetOrdersByPaidAsync(bool pagado);
        Task <List<OrderItem>> GetOrdersByDeliveredAsync(bool entregado);
    }
}
