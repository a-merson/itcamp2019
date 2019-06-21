using Microsoft.EntityFrameworkCore;

namespace Itcamp.Sales.Core
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}