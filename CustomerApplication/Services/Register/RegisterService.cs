using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RegisterApplication.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public RegisterService(HttpClient client, ILogger<RegisterService> logger)
        {
            client.BaseAddress = new System.Uri("http://customer-order-api/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Register
        public async Task<IEnumerable<RegisterDto>> GetRegisterAsync()
        {
            var response = await _client.GetAsync("ordersservice/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<IEnumerable<RegisterDto>>();
            return register;
        }

        //Get individual Registers
        public async Task<IEnumerable<RegisterDto>> GetRegistersAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<IEnumerable<RegisterDto>>();
            return register;
        }
    }
}
