using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OrderApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public OrderService(HttpClient client, ILogger<OrderService> logger)
        {
            client.BaseAddress = new System.Uri("https://customer-orders-api.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Register
        public async Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            var response = await _client.GetAsync("ordersservice/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<IEnumerable<OrderDto>>();
            return register;
        }

        public async Task<OrderDto> PostOrderAsync(OrderDto orderDto)
        {
            var response = await _client.PostAsJsonAsync("ordersservice/", orderDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        public async Task<OrderDto> EditOrderAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadAsAsync<OrderDto>();
            return orders;
        }

        public async Task<OrderDto> DetailsOrderAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadAsAsync<OrderDto>();
            return orders;
        }


        //Get Delete
        public async Task<OrderDto> GetDeleteOrderAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadAsAsync<OrderDto>();
            return orders;
        }



        public async Task<OrderDto> DeleteOrderAsync(int Id)
        {
            var response = await _client.DeleteAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadAsAsync<OrderDto>();
            return orders;
        }





        //Put New Order Member
        public async Task<OrderDto> PutOrderAsync(OrderDto order)
        {
            var response = await _client.PutAsJsonAsync("ordersservice/" + order.Id, order);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<OrderDto>();
        }

        //Get Order Exists
        public bool GetOrderExists(int Id)
        {
            var response = _client.GetAsync("ordersservice/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Product does not exist in the database");
                return false;
            }
            return true;
        }



    }
}