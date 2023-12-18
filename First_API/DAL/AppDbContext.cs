using First_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace First_API.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colors { get; set; }
    }
}
