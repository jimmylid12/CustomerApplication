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
            client.BaseAddress = new System.Uri("https://manage-products-api.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }


        //Get all Register
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            var response = await _client.GetAsync("Products/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();
            return products;
        }

        public async Task<ProductDto> PostProductAsync(ProductDto productDto)
        {
            var response = await _client.PostAsJsonAsync("Products/", productDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<ProductDto>();
            return products;
        }


        public async Task<ProductDto> EditProductAsync(int Id)
        {
            var response = await _client.GetAsync("Products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<ProductDto>();
            return products;
        }

        public async Task<ProductDto> DetailsProductAsync(int Id)
        {
            var response = await _client.GetAsync("Products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<ProductDto>();
            return products;
        }


        //Get Delete
        public async Task<ProductDto> GetDeleteProductAsync(int Id)
        {
            var response = await _client.GetAsync("Products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<ProductDto>();
            return products;
        }



        public async Task<ProductDto> DeleteProductAsync(int Id)
        {
            var response = await _client.DeleteAsync("Products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<ProductDto>();
            return products;
        }





        //Put New Order Member
        public async Task<ProductDto> PutProductAsync(ProductDto product)
        {
            var response = await _client.PutAsJsonAsync("Products/" + product.Id, product);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductDto>();
        }

        //Get Order Exists
        public bool GetProductExists(int Id)
        {
            var response = _client.GetAsync("Products;lkjvc/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Product does not exist in the database");
                return false;
            }
            return true;
        }






    }




}
