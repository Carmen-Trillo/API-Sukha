using Entities.Entities;
using Entities.SearchFilters;
using Resource.RequestModels;

namespace API_Sukha.IServices
{
    public interface IOrderServices
    {
        Task<int> InsertOrderAsync(NewOrderRequest newOrderRequest);
        Task UpdateOrderAsync(OrderItem orderItem);
        Task DeleteOrderAsync(int id);
        Task<List<OrderItem>> GetAllOrdersAsync();
        Task<List<OrderItem>> GetOrdersByCriteriaAsync(OrderFilter orderFilter);
        Task<List<OrderItem>> GetOrdersByCustomerAsync(int idCustomer);
        Task<List<OrderItem>> GetOrdersByProductAsync(int idProduct);
        Task<List<OrderItem>> GetOrdersByPaidAsync(bool pagado);
        Task<List<OrderItem>> GetOrdersByDeliveredAsync(bool entregado);
    }
}