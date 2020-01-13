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
            new ProductDto { Id = 3, Name = "James Liddle", Price = 6.00, Stock = 2 },
              new ProductDto { Id = 3, Name = "James Liddle", Price = 6.00, Stock = 2 }
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

        Task<ProductDto> IProductService.EditProductAsync(int Id)
        {
            var customer = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }


        Task<ProductDto> IProductService.DetailsProductAsync(int Id)
        {
            var customer = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        Task<ProductDto> IProductService.GetDeleteProductAsync(int Id)
        {
            var customer = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<ProductDto> DeleteProductAsync(int Id)
        {
            var order = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        Task<ProductDto> IProductService.PutProductAsync(ProductDto products)
        {
            _product.Add(products);
            return Task.FromResult(products);
        }

        public bool GetProductExists(int Id)
        {
            return true;
        }






    }
}
