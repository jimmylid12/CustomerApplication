using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ProductApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            client.BaseAddress = new System.Uri("http://customer-accounts-api/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }


        //Get all Register
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            var response = await _client.GetAsync("customeraccounts/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();
            return product;
        }

        public async Task<ProductDto> PostProductAsync(ProductDto productDto)
        {
            var response = await _client.PostAsJsonAsync("customeraccounts/", productDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }
    }




}
