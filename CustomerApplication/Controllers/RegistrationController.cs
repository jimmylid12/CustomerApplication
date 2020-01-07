using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using RegisterApplication.Services;

namespace RegisterApplication.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IRegisterService _registerService;

        public RegistrationController(ILogger<RegistrationController> logger,
             IRegisterService registerService)
        {
            _logger = logger;
            _registerService = registerService;
        }
        // GET: Register
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<RegisterDto> registers = null;
            try
            {
                registers = await _registerService.GetRegisterAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using register service.");
                registers = Array.Empty<RegisterDto>();
            }
            return View(registers.ToList());
        }
    }

    //private readonly RegistrationContext _context;

    //public RegistrationController(RegistrationContext context)
    //{
    //    _context = context;
    //}

    //// GET: Registration
    //public async Task<IActionResult> Index()
    //{
    //    return View(await _context.RegistrationDTO.ToListAsync());
    //}

    //// GET: Registration/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var registrationDTO = await _context.RegistrationDTO
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (registrationDTO == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(registrationDTO);
    //}

    //// GET: Registration/Create
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Registration/Create
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,Name,Address,PostCode,TelephoneNumber")] RegistrationDTO registrationDTO)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(registrationDTO);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(registrationDTO);
    //}

    //// GET: Registration/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var registrationDTO = await _context.RegistrationDTO.FindAsync(id);
    //    if (registrationDTO == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(registrationDTO);
    //}

    //// POST: Registration/Edit/5
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PostCode,TelephoneNumber")] RegistrationDTO registrationDTO)
    //{
    //    if (id != registrationDTO.Id)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(registrationDTO);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!RegistrationDTOExists(registrationDTO.Id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(registrationDTO);
    //}

    //// GET: Registration/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var registrationDTO = await _context.RegistrationDTO
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (registrationDTO == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(registrationDTO);
    //}

    //// POST: Registration/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    var registrationDTO = await _context.RegistrationDTO.FindAsync(id);
    //    _context.RegistrationDTO.Remove(registrationDTO);
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool RegistrationDTOExists(int id)
    //{
    //    return _context.RegistrationDTO.Any(e => e.Id == id);
    //}
}

