using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReviewApplication.Services
{
    public interface IReviewService
    {

        Task<IEnumerable<ReviewDto>> GetReviewAsync();
        Task<ReviewDto> PostReviewAsync(ReviewDto reviewDto);






    }
}
