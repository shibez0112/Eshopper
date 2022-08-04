using Microsoft.EntityFrameworkCore;
namespace Eshopper.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}