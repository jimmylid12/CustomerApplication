using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Models.OrderHistory
{
    public class OrderHistoryContext :DbContext
    {
          
        
        
            public OrderHistoryContext(DbContextOptions<OrderHistoryContext> options)
                : base(options)
        {
        }

        public DbSet<OrderHistoryDTO> OrderHistoryDTO { get; set; }

    }
}

