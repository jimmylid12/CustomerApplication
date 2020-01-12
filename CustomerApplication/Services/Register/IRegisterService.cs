using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterApplication.Services
{
    public interface IRegisterService
    {
      
        Task<IEnumerable<RegisterDto>> GetRegisterAsync();
        Task<RegisterDto> PostRegisterAsync(RegisterDto registerDto);
        Task<RegisterDto> EditRegisterAsync(int Id);
        Task<RegisterDto> DetailsRegisterAsync(int Id);
        Task<RegisterDto> DeleteRegisterAsync(int Id);
        Task<RegisterDto> GetDeleteRegisterAsync(int Id);

        Task<RegisterDto> PutRegisterAsync(RegisterDto RegisterDto);

        bool GetRegisterExists(int Id);


    }
}
