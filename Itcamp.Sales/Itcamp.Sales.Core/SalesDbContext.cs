using Microsoft.EntityFrameworkCore;

namespace Stachka.Sales.Core
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}