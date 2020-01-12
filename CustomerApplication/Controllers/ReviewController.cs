using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using ReviewApplication.Services;

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
        // GET: Register
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
                _logger.LogWarning("Exception Occured using review service.");
                reviews = Array.Empty<ReviewDto>();
            }
            return View(reviews.ToList());
        }

        // GET: review
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Review,Mark")] ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _reviewService.PostReviewAsync(new ReviewDto
                {
                    Review = reviewDto.Review,
                    Mark = reviewDto.Mark
                   
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(reviewDto);
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