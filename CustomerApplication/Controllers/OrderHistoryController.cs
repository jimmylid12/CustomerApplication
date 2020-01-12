using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerApplication.Models.OrderHistory;
using Microsoft.Extensions.Logging;
using OrderApplication.Services;

using System.Net.Http;


namespace OrderApplication.Controllers
{

    public class OrderHistoryController : Controller
    {

        private readonly ILogger _logger;
        private readonly IOrderService _orderService;

        public OrderHistoryController(ILogger<OrderHistoryController> logger,
             IOrderService  orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<OrderDto> orders = null;
            try
            {
                orders = await _orderService.GetOrderAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using review service.");
                orders= Array.Empty<OrderDto>();
            }
            return View(orders.ToList());
        }

        // GET: review
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Price")] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderService.PostOrderAsync(new OrderDto
                {
                    Product = orderDto.Product,
                    Price = orderDto.Price

                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(orderDto);
        }


    }







}




//{
//    public class OrderHistoryController : Controller
//    {
//        private readonly OrderHistoryContext _context;

//        public OrderHistoryController(OrderHistoryContext context)
//        {
//            _context = context;
//        }

//        // GET: OrderHistory
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.OrderHistoryDTO.ToListAsync());
//        }

//        // GET: OrderHistory/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var orderHistoryDTO = await _context.OrderHistoryDTO
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (orderHistoryDTO == null)
//            {
//                return NotFound();
//            }

//            return View(orderHistoryDTO);
//        }

//        // GET: OrderHistory/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: OrderHistory/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Product,Price")] OrderHistoryDTO orderHistoryDTO)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(orderHistoryDTO);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(orderHistoryDTO);
//        }

//        // GET: OrderHistory/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var orderHistoryDTO = await _context.OrderHistoryDTO.FindAsync(id);
//            if (orderHistoryDTO == null)
//            {
//                return NotFound();
//            }
//            return View(orderHistoryDTO);
//        }

//        // POST: OrderHistory/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Price")] OrderHistoryDTO orderHistoryDTO)
//        {
//            if (id != orderHistoryDTO.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(orderHistoryDTO);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!OrderHistoryDTOExists(orderHistoryDTO.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(orderHistoryDTO);
//        }

//        // GET: OrderHistory/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var orderHistoryDTO = await _context.OrderHistoryDTO
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (orderHistoryDTO == null)
//            {
//                return NotFound();
//            }

//            return View(orderHistoryDTO);
//        }

//        // POST: OrderHistory/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var orderHistoryDTO = await _context.OrderHistoryDTO.FindAsync(id);
//            _context.OrderHistoryDTO.Remove(orderHistoryDTO);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool OrderHistoryDTOExists(int id)
//        {
//            return _context.OrderHistoryDTO.Any(e => e.Id == id);
//        }
//    }
//}
