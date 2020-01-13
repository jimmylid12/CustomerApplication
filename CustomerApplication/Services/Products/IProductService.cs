using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProductApplication.Services
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> GetProductAsync();
        Task<ProductDto> PostProductAsync(ProductDto productDto);

        Task<ProductDto> EditProductAsync(int Id);
        Task<ProductDto> DetailsProductAsync(int Id);
        Task<ProductDto> DeleteProductAsync(int Id);
        Task<ProductDto> GetDeleteProductAsync(int Id);

        Task<ProductDto> PutProductAsync(ProductDto ProductDto);

        bool GetProductExists(int Id);





    }
}
