using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    //ServiceContext _serviceContext;
    public class NewOrderRequest
    {
        //public NewPedidoRequest(ServiceContext serviceContext) {
        //    _serviceContext = serviceContext;
        //}
        public Guid IdWeb { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdCustomerType { get; set; }

        public int IdProduct { get; set; }

        public decimal Price { get; set; }

        public int Number { get; set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public DateTime DeliveryDate { get; set; }
        public bool Paid { get; set; }
        public bool Delivered { get; set; }
        public bool IsActive { get; set; }
        public OrderItem ToOrderItem()
        {
            var orderItem = new OrderItem();

            orderItem.IdWeb = IdWeb;
            orderItem.DateOrder = DateOrder;
            orderItem.IdProduct = IdProduct;
            orderItem.IdCustomer = IdCustomer;
            orderItem.IdCustomerType= IdCustomerType;
            orderItem.Number = Number;
            orderItem.Price= Price;

            //pedidoItem.Descuento = 0.2M * (Cantidad * Precio);

            if (orderItem.IdCustomerType == 1)
            {
                orderItem.Discount = 0.1M* (Number * Price);
            }
            else if (orderItem.IdCustomerType == 2)
            {
                orderItem.Discount = 0.15M* (Number * Price);
            }
            else if (orderItem.IdCustomerType == 3)
            {
                orderItem.Discount = 0.2M * (Number * Price);
            }
            else
            {
                orderItem.Discount = 0;
            }

            if (orderItem.IdCustomerType == 1)
            {
                orderItem.TotalAmount = 0.9M * (Number * Price);
            }
            else if (orderItem.IdCustomerType == 2)
            {
                orderItem.TotalAmount = 0.85M * (Number * Price);
            }
            else if (orderItem.IdCustomerType == 3)
            {
                orderItem.TotalAmount = 0.8M * (Number * Price);
            }
            else
            {
                orderItem.TotalAmount = Number * Price;
            }
            //pedidoItem.ImporteTotal = (Cantidad * Precio) - pedidoItem.Descuento;
 
            orderItem.DeliveryDate = DeliveryDate;
            orderItem.Paid = Paid;
            orderItem.Delivered = Delivered;
            orderItem.IsActive = true;

            return orderItem;

            //buscas en base el producto y su precio.
        }
    }
}
