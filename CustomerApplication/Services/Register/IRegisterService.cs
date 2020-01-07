using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterApplication.Services
{
    public interface IRegisterService
    {
      
        Task<IEnumerable<RegisterDto>> GetRegisterAsync();

        Task<IEnumerable<RegisterDto>> GetRegistersAsync(int Id);



    }
}
