using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Resource.RequestModels;
using System.Security.Authentication;

namespace API_Sukha.Controllers
{
    [ApiController]
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

        /*private ISecurityServices _securityServices;
        private IOrderServices _orderServices;
        public OrderController(ISecurityServices securityServices, IOrderServices orderServices)
        {
            _securityServices = securityServices;
            _orderServices = orderServices;
        }*/

        [HttpPost(Name = "InsertarPedido")]
        public async Task<int> PostAsync([FromBody] NewOrderRequest newOrderRequest)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.InsertOrderAsync(newOrderRequest);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "VerPedidos")]
        public async Task<List<OrderItem>> GetAllOrdersAsync()
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword*/
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetAllOrdersAsync();
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarPedidosPorFiltro")]
        public async Task<List<OrderItem>> GetOrdersByCriteriaAsync([FromQuery] OrderFilter orderFilter)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetOrdersByCriteriaAsync(orderFilter);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarPedidosPorCliente")]
        public async Task<List<OrderItem>> GetOrdersByClienteAsync([FromQuery] int idCustomer)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetOrdersByCustomerAsync(idCustomer);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarPedidosPorProductos")]
        public async Task<List<OrderItem>> GetOrdersByProductoAsync([FromQuery] int idProduct)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetOrdersByProductAsync(idProduct);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarPedidosPorProductosPagados")]
        public async Task<List<OrderItem>> GetOrdersByPagadosAsync([FromQuery] bool pagado)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetOrdersByPagadosAsync(pagado);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpGet(Name = "MostrarPedidosPorProductosEntregados")]
        public async Task<List<OrderItem>> GetOrdersByEntregadosAsync([FromQuery] bool entregado)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                return await _orderServices.GetOrdersByEntregadosAsync(entregado);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpPatch(Name = "ModificarPedido")]
        public async Task PatchAsync([FromBody] OrderItem orderItem)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _orderServices.UpdateOrderAsync(orderItem);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }

        [HttpDelete(Name = "EliminarPedido")]
        public async Task DeleteAsync([FromQuery] int id)
        {/*[FromHeader] string userUsuario, [FromHeader] string userPassword, */
            /*var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {*/
                await _orderServices.DeleteOrderAsync(id);
            /*}
            else
            {
                throw new InvalidCredentialException();
            }*/
        }


    }
}
