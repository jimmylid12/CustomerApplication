using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using ProductApplication.Services;

//this is what allows you to purchase the product and aftwards see what you have bought 
namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
             IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // Returns the products in a list
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _productService.GetProductAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("error");
                products = Array.Empty<ProductDto>();
            }
            return View(products.ToList());
        }

        // Returns the view to create them
        public IActionResult Create()
        {
            return View();
        }


        // This is what allows you to create the products and purchase them
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock")] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productService.PostProductAsync(new ProductDto
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Stock = productDto.Stock

                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Error.");
            }
            return View(productDto);
        }


        // Allows you to edit the purchase and update any information if you want to
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _productService.EditProductAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _productService.PutProductAsync(product);
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("error.");
            }
            return RedirectToAction(nameof(Index));
        }


        private bool ProductExists(int id)
        {
            return _productService.GetProductExists(id);
        }





        //Display the product in the details view and allows you to edit if if information is incorrect
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("Name,Price,Stock")] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productService.PostProductAsync(new ProductDto
                {
                   Name = productDto.Name,
                   Price = productDto.Price,
                   Stock = productDto.Stock
                    
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(productDto);
        }


        
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _productService.DetailsProductAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }



        // Allows you to delete the product 
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

           ProductDto product = null;
            try
            {
                product = await _productService.GetDeleteProductAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("error   " + product);
                _logger.LogWarning("error.");
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _productService.DeleteProductAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _productService.GetProductAsync();

            return RedirectToAction(nameof(Index));
        }

    }

    }


