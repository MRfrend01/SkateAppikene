using Microsoft.EntityFrameworkCore;
using SkateAppikene.Models;

namespace SkateAppikene.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Pin> Pins { get; set; }


    }
}