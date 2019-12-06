using System;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Models.Review
{
    public class ReviewContext : DbContext

    {

        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {


        }

        public DbSet<ReviewDTO> ReviewDTO { get; set; }
    }
}

