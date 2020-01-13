using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewApplication.Services.Review
{
    public class FakeReviewService : IReviewService
    {
        public List<ReviewDto> _register = new List<ReviewDto>
        {
            new ReviewDto { Id = 3, CustomerID = 5,  Rating = 41, Comments = "good product", Visible = true, ProductID = 7},
            new ReviewDto { Id = 3, CustomerID = 5,  Rating = 41, Comments = "good product", Visible = true, ProductID = 7}

        };

        public Task<IEnumerable<ReviewDto>> GetReviewAsync()
        {
            return Task.FromResult(_register.AsEnumerable());
        }

        Task<ReviewDto> IReviewService.PostReviewAsync(ReviewDto reviewDto)
        {
            _register.Add(reviewDto);
            return Task.FromResult(reviewDto);
        }

        Task<ReviewDto> IReviewService.EditReviewAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }


        Task<ReviewDto> IReviewService.DetailsReviewAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        Task<ReviewDto> IReviewService.GetDeleteReviewAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<ReviewDto> DeleteReviewAsync(int Id)
        {
            var order = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        Task<ReviewDto> IReviewService.PutReviewAsync(ReviewDto reviews)
        {
            _register.Add(reviews);
            return Task.FromResult(reviews);
        }

        public bool GetReviewExists(int Id)
        {
            return true;
        }




    }

}