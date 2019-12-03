using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Models.Product
{
    public class ProductContext : DbContext
    {


        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<ProductDTO> ProductDTO { get; set; }

    }
}
