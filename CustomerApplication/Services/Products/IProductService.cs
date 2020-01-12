using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProductApplication.Services
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> GetProductAsync();
        Task<ProductDto> PostProductAsync(ProductDto productDto);
      






    }
}
