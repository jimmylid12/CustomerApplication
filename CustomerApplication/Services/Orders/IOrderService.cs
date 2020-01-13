using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApplication.Services
{
    public interface IOrderService
    {

        Task<IEnumerable<OrderDto>> GetOrderAsync();
        Task<OrderDto> PostOrderAsync(OrderDto orderDto);


        Task<OrderDto> EditOrderAsync(int Id);
        Task<OrderDto> DetailsOrderAsync(int Id);
        Task<OrderDto> DeleteOrderAsync(int Id);
        Task<OrderDto> GetDeleteOrderAsync(int Id);

        Task<OrderDto> PutOrderAsync(OrderDto OrderDto);

        bool GetOrderExists(int Id);





    }
}
