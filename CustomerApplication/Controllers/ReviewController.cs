using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using ReviewApplication.Services;
//this is what displays the reviews of products and you are able to add your own
namespace ReviewApplication.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger,
             IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }
        // GET: Reviews and returns them to the view in a list
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _reviewService.GetReviewAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Error.");
                reviews = Array.Empty<ReviewDto>();
            }
            return View(reviews.ToList());
        }

        
        public IActionResult Create()
        {
            return View();
        }

        //This is what creates the review and adds it to the database and returns it to the view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Comments,CustomerID,ProductID,Rating,Visible")] ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _reviewService.PostReviewAsync(new ReviewDto
                {
                    Comments = reviewDto.Comments,
                     CustomerID = reviewDto.CustomerID,
                     ProductID = reviewDto.ProductID,
                     Rating = reviewDto.Rating,
                     Visible = reviewDto.Visible,


                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Error.");
            }
            return View(reviewDto);
        }





        // Allows customer to edit the review if they need to change it 
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _reviewService.EditReviewAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewDto reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _reviewService.PutReviewAsync(reviews);
                if (!ReviewExists(id))
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

        //checks if the review exsists and if not returns it
        private bool ReviewExists(int id)
        {
            return _reviewService.GetReviewExists(id);
        }





        // Returns the information about the review if you need to change and update it
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("Comments,CustomerID,ProductID,Rating,Visible")] ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _reviewService.PostReviewAsync(new ReviewDto
                {
                    Comments = reviewDto.Comments,
                    CustomerID = reviewDto.CustomerID,
                    ProductID = reviewDto.ProductID,
                    Rating = reviewDto.Rating,
                    Visible = reviewDto.Visible,

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

            var reviews = await _reviewService.DetailsReviewAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            return View(reviews);
        }



        // Allows you to delete the review and update the database
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            ReviewDto reviews = null;
            try
            {
                reviews = await _reviewService.GetDeleteReviewAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("error  " + reviews);
                _logger.LogWarning("error.");
            }

            return View(reviews);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _reviewService.DeleteReviewAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _reviewService.GetReviewAsync();

            return RedirectToAction(nameof(Index));
        }



    }


}



//public class ReviewController : Controller
//{
//    private readonly ReviewContext _context;

//    public ReviewController(ReviewContext context)
//    {
//        _context = context;
//    }

//    // GET: Review
//    public async Task<IActionResult> Index()
//    {
//        return View(await _context.ReviewDTO.ToListAsync());
//    }

//    // GET: Review/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var reviewDTO = await _context.ReviewDTO
//            .FirstOrDefaultAsync(m => m.Id == id);
//        if (reviewDTO == null)
//        {
//            return NotFound();
//        }

//        return View(reviewDTO);
//    }

//    // GET: Review/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: Review/Create
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("Id,Review,Mark")] ReviewDTO reviewDTO)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Add(reviewDTO);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        return View(reviewDTO);
//    }

//    // GET: Review/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var reviewDTO = await _context.ReviewDTO.FindAsync(id);
//        if (reviewDTO == null)
//        {
//            return NotFound();
//        }
//        return View(reviewDTO);
//    }

//    // POST: Review/Edit/5
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("Id,Review,Mark")] ReviewDTO reviewDTO)
//    {
//        if (id != reviewDTO.Id)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(reviewDTO);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ReviewDTOExists(reviewDTO.Id))
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
//        return View(reviewDTO);
//    }

//    // GET: Review/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var reviewDTO = await _context.ReviewDTO
//            .FirstOrDefaultAsync(m => m.Id == id);
//        if (reviewDTO == null)
//        {
//            return NotFound();
//        }

//        return View(reviewDTO);
//    }

//    // POST: Review/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        var reviewDTO = await _context.ReviewDTO.FindAsync(id);
//        _context.ReviewDTO.Remove(reviewDTO);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool ReviewDTOExists(int id)
//    {
//        return _context.ReviewDTO.Any(e => e.Id == id);
//    }
//}


//    #API's
//customer-accounts-api:
//    image: nathanlloyd/manage-products-api
//    environment:
//      DBServer: "ms-sql-server-orders"
//    ports:
//      - "8081:80"