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
            client.BaseAddress = new System.Uri("http://customer-accounts-api/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Register
        public async Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            var response = await _client.GetAsync("customeraccounts/");
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
            var response = await _client.PostAsJsonAsync("customeraccounts/", orderDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }
    }
}