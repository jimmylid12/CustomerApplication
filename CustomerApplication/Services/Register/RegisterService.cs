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
            client.BaseAddress = new System.Uri("https://customeraccountapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Register
        public async Task<IEnumerable<RegisterDto>> GetRegisterAsync()
        {
            var response = await _client.GetAsync("customeraccounts/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<IEnumerable<RegisterDto>>();
            return register;
        }

        public async Task<RegisterDto> PostRegisterAsync(RegisterDto registerDto)
        {
            var response = await _client.PostAsJsonAsync("customeraccounts/", registerDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<RegisterDto>();
            return register;
        }

        public async Task<RegisterDto> EditRegisterAsync(int Id)
        {
            var response = await _client.GetAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<RegisterDto>();
            return register;
        }

        public async Task<RegisterDto> DetailsRegisterAsync(int Id)
        {
            var response = await _client.GetAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<RegisterDto>();
            return register;
        }


        //Get Delete
        public async Task<RegisterDto> GetDeleteRegisterAsync(int Id)
        {
            var response = await _client.GetAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<RegisterDto>();
            return order;
        }



        public async Task<RegisterDto> DeleteRegisterAsync(int Id)
        {
            var response = await _client.DeleteAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<RegisterDto>();
            return register;
        }





        //Put New Order Member
        public async Task<RegisterDto> PutRegisterAsync(RegisterDto register)
        {
            var response = await _client.PutAsJsonAsync("customeraccounts/" + register.Id, register);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RegisterDto>();
        }

        //Get Order Exists
        public bool GetRegisterExists(int Id)
        {
            var response = _client.GetAsync("customeraccounts/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Order does not exist in the database");
                return false;
            }
            return true;
        }

     
    }
}
