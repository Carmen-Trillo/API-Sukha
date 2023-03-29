using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderLogic _orderLogic;
        public OrderServices(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderLogic.DeleteOrderAsync(id);
        }

        public async Task<List<OrderItem>> GetAllOrdersAsync()
        {
            return await _orderLogic.GetAllOrdersAsync();
        }
        public async Task<OrderItem> GetOrderByIdAsync(int id)
        {
            return await _orderLogic.GetOrderByIdAsync(id);
        }

        public async Task<List<OrderItem>> GetOrdersByCriteriaAsync(OrderFilter orderFilter)
        {
            return await _orderLogic.GetOrdersByCriteriaAsync(orderFilter);
        }

        public async Task <List<OrderItem>> GetOrdersByCustomerAsync(int idCustomer)
        {
            return await _orderLogic.GetOrdersByCustomerAsync(idCustomer);
        }

        public async Task<List<OrderItem>> GetOrdersByProductAsync(int idProduct)
        {
            return await _orderLogic.GetOrdersByProductAsync(idProduct);
        }
        public async Task<List<OrderItem>> GetOrdersByPaidAsync(bool pagado)
        {
            return await _orderLogic.GetOrdersByPaidAsync(pagado);
        }
        public async Task<List<OrderItem>> GetOrdersByDeliveredAsync(bool entregado)
        {
            return await _orderLogic.GetOrdersByDeliveredAsync(entregado);
        }


        public async Task<int> InsertOrderAsync(NewOrderRequest newOrderRequest)
        {

            var newOrderItem = newOrderRequest.ToOrderItem();
            return await _orderLogic.InsertOrderAsync(newOrderItem);
        }

        public async Task UpdateOrderAsync(OrderItem orderItem)
        {
            await _orderLogic.UpdateOrderAsync(orderItem);
        }
    }
}

