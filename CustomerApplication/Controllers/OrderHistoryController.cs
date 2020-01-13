using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.Extensions.Logging;
using OrderApplication.Services;

using System.Net.Http;

//this method displays the OrderHistory of what people have bought
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


        //this creates the order history and returns it to the view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,ProductID,Total,Quantity,ShippingAdress,OrderDate,ShipppingDate")] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderService.PostOrderAsync(new OrderDto
                {
                    CustomerID = orderDto.CustomerID,
                    ProductID = orderDto.ProductID,
                    Total = orderDto.Total,
                    Quantity = orderDto.Quantity,
                    ShippingAddress = orderDto.ShippingAddress,
                    OrderDate = orderDto.OrderDate,
                    ShippingDate = orderDto.OrderDate

                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(orderDto);
        }



        // Allows you to edit anything if the information is incorrect
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _orderService.EditOrderAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // This is what helps return the edit to the view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDto orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _orderService.PutOrderAsync(orders);
                if (!OrderExists(id))
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



        //checks if the order exsists
        private bool OrderExists(int id)
        {
            return _orderService.GetOrderExists(id);
        }

        // Displays the orders details, and if need be can edit them
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("CustomerID,ProductID,Total,Quantity,ShippingAdress,OrderDate,ShipppingDate")] OrderDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderService.PostOrderAsync(new OrderDto
                {
                    CustomerID = reviewDto.CustomerID,
                    ProductID = reviewDto.ProductID,
                    Total = reviewDto.Total,
                    Quantity = reviewDto.Quantity,
                    ShippingDate = reviewDto.ShippingDate,
                   ShippingAddress= reviewDto.ShippingAddress
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("error.");
            }
            return View(reviewDto);
        }


        // GET: Customer/Edit
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var orders = await _orderService.DetailsOrderAsync(id);
            if (orders== null)
            {
                return NotFound();
            }
            return View(orders);
        }



        // What allows you to delete an order if you want to
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            OrderDto orders = null;
            try
            {
                orders = await _orderService.GetDeleteOrderAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("error  " + orders);
                _logger.LogWarning("error.");
            }

            return View(orders);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.DeleteOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.GetOrderAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}




