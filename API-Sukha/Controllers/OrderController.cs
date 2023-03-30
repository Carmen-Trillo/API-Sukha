using API_Sukha.IServices;
using API_Sukha.Services;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace API_Sukha.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderServices _orderServices;
        public OrderController(ILogger<OrderController> logger, IOrderServices orderServices)
        {
            _logger = logger;
            _orderServices = orderServices;
        }

  

        [HttpPost(Name = "InsertOrder")]
        public async Task<int> PostAsync([FromBody] NewOrderRequest newOrderRequest)
        {
            
                return await _orderServices.InsertOrderAsync(newOrderRequest);
        
        }

        [HttpGet(Name = "GetAllOrders")]
        public async Task<List<OrderItem>> GetAllOrdersAsync()
        {
            
                return await _orderServices.GetAllOrdersAsync();
            
        }

        [HttpGet(Name = "GetOrdersByCriteria")]
        public async Task<List<OrderItem>> GetOrdersByCriteriaAsync([FromQuery] OrderFilter orderFilter)
        {
           
                return await _orderServices.GetOrdersByCriteriaAsync(orderFilter);
            
        }

        [HttpGet(Name = "GetOrdersByCustomer")]
        public async Task<List<OrderItem>> GetOrdersByCustomerAsync([FromQuery] int idCustomer)
        {
           
                return await _orderServices.GetOrdersByCustomerAsync(idCustomer);
            
        }

        [HttpGet(Name = "GetOrdersByProduct")]
        public async Task<List<OrderItem>> GetOrdersByProductAsync([FromQuery] int idProduct)
        {
           
                return await _orderServices.GetOrdersByProductAsync(idProduct);
            
        }

        [HttpGet(Name = "GetOrdersByPaid")]
        public async Task<List<OrderItem>> GetOrdersByPaidAsync([FromQuery] bool pagado)
        {
            return await _orderServices.GetOrdersByPaidAsync(pagado);
            
        }

        [HttpGet(Name = "GetOrdersByDelivered")]
        public async Task<List<OrderItem>> GetOrdersByDeliveredAsync([FromQuery] bool entregado)
        {
            
                return await _orderServices.GetOrdersByDeliveredAsync(entregado);
           
        }

        [HttpGet(Name = "GetOrderById")]
        public async Task<OrderItem> GetOrderByIdAsync(int id)
        {
            
                return await _orderServices.GetOrderByIdAsync(id);
     
        }

        [HttpPatch(Name = "UpdateOrder")]
        public async Task PatchAsync([FromBody] OrderItem orderItem)
        {

                await _orderServices.UpdateOrderAsync(orderItem);
            
        }

        [HttpDelete(Name = "DeleteOrder")]
        public async Task DeleteAsync([FromQuery] int id)
        {
           
                await _orderServices.DeleteOrderAsync(id);
            
        }


    }
}
