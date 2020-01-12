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
            new ReviewDto { Id = 3, Review = "James Liddle",  Mark = 41},
            new ReviewDto { Id = 3, Review = "James Liddle",  Mark = 41}

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
    }

}