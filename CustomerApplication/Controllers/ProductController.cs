using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerApplication.Models.Product;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using ProductApplication.Services;

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

        // GET: Register
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
                _logger.LogWarning("Exception Occured using register service.");
                products = Array.Empty<ProductDto>();
            }
            return View(products.ToList());
        }

        // GET: Registration Form
        public IActionResult Create()
        {
            return View();
        }


        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Description,Cost")] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productService.PostProductAsync(new ProductDto
                {
                    Product = productDto.Product,
                    Description = productDto.Description,
                    Cost = productDto.Cost,

                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(productDto);
        }

    }

    }



//public class ProductController : Controller
//{
//    private readonly ProductContext _context;

//    public ProductController(ProductContext context)
//    {
//        _context = context;
//    }

//    // GET: Product
//    public async Task<IActionResult> Index()
//    {
//        return View(await _context.ProductDTO.ToListAsync());
//    }

//    // GET: Product/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var productDTO = await _context.ProductDTO
//            .FirstOrDefaultAsync(m => m.Id == id);
//        if (productDTO == null)
//        {
//            return NotFound();
//        }

//        return View(productDTO);
//    }

//    // GET: Product/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: Product/Create
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("Id,Product,Description,Cost")] ProductDTO productDTO)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Add(productDTO);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        return View(productDTO);
//    }

//    // GET: Product/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var productDTO = await _context.ProductDTO.FindAsync(id);
//        if (productDTO == null)
//        {
//            return NotFound();
//        }
//        return View(productDTO);
//    }

//    // POST: Product/Edit/5
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Description,Cost")] ProductDTO productDTO)
//    {
//        if (id != productDTO.Id)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(productDTO);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ProductDTOExists(productDTO.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        return View(productDTO);
//    }

//    // GET: Product/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var productDTO = await _context.ProductDTO
//            .FirstOrDefaultAsync(m => m.Id == id);
//        if (productDTO == null)
//        {
//            return NotFound();
//        }

//        return View(productDTO);
//    }

//    // POST: Product/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        var productDTO = await _context.ProductDTO.FindAsync(id);
//        _context.ProductDTO.Remove(productDTO);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool ProductDTOExists(int id)
//    {
//        return _context.ProductDTO.Any(e => e.Id == id);
//    }
//}