using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ReviewApplication.Services
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public ReviewService(HttpClient client, ILogger<ReviewService> logger)
        {
            client.BaseAddress = new System.Uri("http://Manage-Products-api/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Registerz
        public async Task<IEnumerable<ReviewDto>> GetReviewAsync()
        {
            var response = await _client.GetAsync("Reviews/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return review;
        }

        public async Task<ReviewDto> PostReviewAsync(ReviewDto reviewDto)
        {
            var response = await _client.PostAsJsonAsync("Reviews/", reviewDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var register = await response.Content.ReadAsAsync<ReviewDto>();
            return register;
        }






    }
}
