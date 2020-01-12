using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApplication.Services
{
    public interface IOrderService
    {

        Task<IEnumerable<OrderDto>> GetOrderAsync();
        Task<OrderDto> PostOrderAsync(OrderDto orderDto);
       






    }
}
