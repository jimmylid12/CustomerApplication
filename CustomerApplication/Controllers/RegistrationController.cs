using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using RegisterApplication.Services;
//This is what allows you to register, you information is then displayed 
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

        // GET: Registration Form
        public IActionResult Create()
        {
            return View();
        }





        // POST: This is what is used to create and register a user with the correct information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Address,Postcode,Telephone,IsComplete")] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _registerService.PostRegisterAsync(new RegisterDto
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    Address = registerDto.Address,
                    Postcode = registerDto.Postcode,
                    Telephone = registerDto.Telephone,
                   IsComplete = registerDto.IsComplete 
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("error.");
            }
            return View(registerDto);
        }

        


        // GET: After you have created your account you can edit it if you so wish.
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _registerService.EditRegisterAsync( id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _registerService.PutRegisterAsync(register);
                if (!RegisterExists(id))
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

        //checks if user already exsists
        private bool RegisterExists(int id)
        {
            return _registerService.GetRegisterExists(id);
        }





        // POST: what is displayed within details view after account has been registered
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("Id,Name,Email,Password,Address,Postcode,Telephone,IsComplete")] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _registerService.PostRegisterAsync(new RegisterDto
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    Address = registerDto.Address,
                   Postcode = registerDto.Postcode,
                    Telephone = registerDto.Telephone,
                    IsComplete = registerDto.IsComplete
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(registerDto);
        }


        
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _registerService.DetailsRegisterAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }



        // Allows user to delete their account if they want to
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            RegisterDto register = null;
            try
            {
                register = await _registerService.GetDeleteRegisterAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("error  " + register);
                _logger.LogWarning("error.");
            }

            return View(register);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _registerService.DeleteRegisterAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _registerService.GetRegisterAsync();

            return RedirectToAction(nameof(Index));
        }


    }

}





