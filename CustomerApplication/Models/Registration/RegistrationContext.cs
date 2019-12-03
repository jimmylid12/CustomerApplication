using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Models.Registration
{
    public class RegistrationContext : DbContext
    {
        
        
            public RegistrationContext(DbContextOptions<RegistrationContext> options)
                : base(options)
            {
            }

            public DbSet<RegistrationDTO> RegistrationDTO { get; set; }
        
    }
}
