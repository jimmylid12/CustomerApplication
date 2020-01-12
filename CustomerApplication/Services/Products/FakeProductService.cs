using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProductApplication.Services
{
    public class FakeProductService : IProductService
    {
        public List<ProductDto> _product = new List<ProductDto>
        {
            new ProductDto { Id = 3, Product = "James Liddle", Description = "41 portman street", Cost = 2 },
            new ProductDto { Id = 3, Product = "James Liddle", Description = "41 portman street", Cost = 2 }
        };


        public Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            return Task.FromResult(_product.AsEnumerable());
        }

        Task<ProductDto> IProductService.PostProductAsync(ProductDto productDto)
        {
            _product.Add(productDto);
            return Task.FromResult(productDto);
        }





    }
}
