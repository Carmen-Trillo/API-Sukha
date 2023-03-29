﻿using API_Sukha.IServices;
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
        /*private readonly ILogger<OrderController> _logger;
        private readonly IOrderServices _orderServices;
        public OrderController(ILogger<OrderController> logger, IOrderServices orderServices)
        {
            _logger = logger;
            _orderServices = orderServices;
        }*/

        private ISecurityServices _securityServices;
        private IOrderServices _orderServices;
        public OrderController(ISecurityServices securityServices, IOrderServices orderServices)
        {
            _securityServices = securityServices;
            _orderServices = orderServices;
        }

        [HttpPost(Name = "InsertOrder")]
        public async Task<int> PostAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] NewOrderRequest newOrderRequest)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.InsertOrderAsync(newOrderRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllOrders")]
        public async Task<List<OrderItem>> GetAllOrdersAsync([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetAllOrdersAsync();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrdersByCriteria")]
        public async Task<List<OrderItem>> GetOrdersByCriteriaAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] OrderFilter orderFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetOrdersByCriteriaAsync(orderFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrdersByCustomer")]
        public async Task<List<OrderItem>> GetOrdersByClienteAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int idCustomer)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetOrdersByCustomerAsync(idCustomer);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrdersByProduct")]
        public async Task<List<OrderItem>> GetOrdersByProductoAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int idProduct)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetOrdersByProductAsync(idProduct);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrdersByPaid")]
        public async Task<List<OrderItem>> GetOrdersByPagadosAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] bool pagado)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetOrdersByPaidAsync(pagado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrdersByDelivered")]
        public async Task<List<OrderItem>> GetOrdersByEntregadosAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] bool entregado)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return await _orderServices.GetOrdersByDeliveredAsync(entregado);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "UpdateOrder")]
        public async Task PatchAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] OrderItem orderItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _orderServices.UpdateOrderAsync(orderItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "DeleteOrder")]
        public async Task DeleteAsync([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                await _orderServices.DeleteOrderAsync(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }


    }
}
