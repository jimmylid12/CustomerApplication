using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.Services
{
    public class FakeOrderService : IOrderService
    {
        public List<OrderDto> _order = new List<OrderDto>
        {
            new OrderDto { Id = 3, CustomerID = 1, ProductID = 7, Total = 7, Quantity = 5, ShippingAddress = "41 portman street"  },

            new OrderDto { Id = 3, CustomerID = 1, ProductID = 7, Total = 7, Quantity = 5, ShippingAddress = "41 portman street"  }
        };

        public Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            return Task.FromResult(_order.AsEnumerable());
        }

        Task<OrderDto> IOrderService.PostOrderAsync(OrderDto orderDto)
        {
            _order.Add(orderDto);
            return Task.FromResult(orderDto);
        }


        Task<OrderDto> IOrderService.EditOrderAsync(int Id)
        {
            var customer = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }


        Task<OrderDto> IOrderService.DetailsOrderAsync(int Id)
        {
            var customer = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        Task<OrderDto> IOrderService.GetDeleteOrderAsync(int Id)
        {
            var customer = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<OrderDto> DeleteOrderAsync(int Id)
        {
            var order = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        Task<OrderDto> IOrderService.PutOrderAsync(OrderDto orders)
        {
            _order.Add(orders);
            return Task.FromResult(orders);
        }

        public bool GetOrderExists(int Id)
        {
            return true;
        }




    }
}
