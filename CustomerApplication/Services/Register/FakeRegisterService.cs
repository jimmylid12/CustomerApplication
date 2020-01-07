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
            new RegisterDto { Id = 3, Name = "Musa Haamwala", Address = "2 Tell close", PostCode = "JG3 5BD" },
            new RegisterDto { Id = 4, Name = "Lsoij Haamwala", Address = "5 Tell close", PostCode = "JG3 5BD" }
        };

        public Task<IEnumerable<RegisterDto>> GetRegisterAsync()
        {
            return Task.FromResult(_register.AsEnumerable());
        }

        public Task<IEnumerable<RegisterDto>> GetRegistersAsync(int Id)
        {
            return Task.FromResult(_register.AsEnumerable());
        }
    }
}
