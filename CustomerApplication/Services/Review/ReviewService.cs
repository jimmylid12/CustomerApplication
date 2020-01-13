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
            client.BaseAddress = new System.Uri("https://manage-products-api.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Register
        public async Task<IEnumerable<ReviewDto>> GetReviewAsync()
        {
            var response = await _client.GetAsync("Reviews/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return reviews;
        }

        public async Task<ReviewDto> PostReviewAsync(ReviewDto reviewDto)
        {
            var response = await _client.PostAsJsonAsync("Reviews/", reviewDto);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<ReviewDto>();
            return reviews;
        }


        public async Task<ReviewDto> EditReviewAsync(int Id)
        {
            var response = await _client.GetAsync("Reviews/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<ReviewDto>();
            return reviews;
        }

        public async Task<ReviewDto> DetailsReviewAsync(int Id)
        {
            var response = await _client.GetAsync("Rewviews/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<ReviewDto>();
            return reviews;
        }


        //Get Delete
        public async Task<ReviewDto> GetDeleteReviewAsync(int Id)
        {
            var response = await _client.GetAsync("Reviews/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<ReviewDto>();
            return reviews;
        }



        public async Task<ReviewDto> DeleteReviewAsync(int Id)
        {
            var response = await _client.DeleteAsync("Reviews/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<ReviewDto>();
            return reviews;
        }





        //Put New Order Member
        public async Task<ReviewDto> PutReviewAsync(ReviewDto reviews)
        {
            var response = await _client.PutAsJsonAsync("Reviews/" + reviews.Id, reviews);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ReviewDto>();
        }

        //Get Order Exists
        public bool GetReviewExists(int Id)
        {
            var response = _client.GetAsync("Reviews/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Review doesnt exsist");
                return false;
            }
            return true;
        }



    }
}
