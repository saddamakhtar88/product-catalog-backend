using Microsoft.EntityFrameworkCore;

namespace CatalogueApi.Models
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogueItem> CatalogueItems { get; set; }

    }
}