using DavidToveyCSIMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace DavidToveyCSIMedia
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Sort> Sort => Set<Sort>();
    }
}