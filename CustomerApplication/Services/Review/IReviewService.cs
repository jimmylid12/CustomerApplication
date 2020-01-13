using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReviewApplication.Services
{
    public interface IReviewService
    {

        Task<IEnumerable<ReviewDto>> GetReviewAsync();
        Task<ReviewDto> PostReviewAsync(ReviewDto reviewDto);
        Task<ReviewDto> EditReviewAsync(int Id);
        Task<ReviewDto> DetailsReviewAsync(int Id);
        Task<ReviewDto> DeleteReviewAsync(int Id);
        Task<ReviewDto> GetDeleteReviewAsync(int Id);

        Task<ReviewDto> PutReviewAsync(ReviewDto ReviewDto);

        bool GetReviewExists(int Id);



    }
}
