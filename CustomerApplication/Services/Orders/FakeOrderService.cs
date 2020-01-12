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
            new OrderDto { Id = 3, Product = "James Liddle", Price = 7 },
            new OrderDto { Id = 3, Product = "James Liddle", Price = 7 } 
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

       




    }
}
