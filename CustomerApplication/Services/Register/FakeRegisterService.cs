using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApplication.Services
{
    public class FakeRegisterService : IRegisterService
    {
        public List<RegisterDto> _register = new List<RegisterDto>
        {
            new RegisterDto { Id = 3, Name = "James Liddle", Address = "41 portman street", PostCode = "ts1 2es" },
            new RegisterDto { Id = 4, Name = "James Liddle", Address = "12 summerfield road", PostCode = "yo4395" }
        };

        public Task<IEnumerable<RegisterDto>> GetRegisterAsync()
        {
            return Task.FromResult(_register.AsEnumerable());
        }

        Task<RegisterDto> IRegisterService.PostRegisterAsync(RegisterDto registerDto)
        {
            _register.Add(registerDto);
            return Task.FromResult(registerDto);
        }

        Task<RegisterDto> IRegisterService.EditRegisterAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }


        Task<RegisterDto> IRegisterService.DetailsRegisterAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        Task<RegisterDto> IRegisterService.GetDeleteRegisterAsync(int Id)
        {
            var customer = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<RegisterDto> DeleteRegisterAsync(int Id)
        {
            var order = _register.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        Task<RegisterDto> IRegisterService.PutRegisterAsync(RegisterDto register)
        {
            _register.Add(register);
            return Task.FromResult(register);
        }

        public bool GetRegisterExists(int Id)
        {
            return true;
        }

    }
}
