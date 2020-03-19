namespace CatalogApi.DataSource
{
    using CatalogApi.DataSource.Model;
    using Microsoft.EntityFrameworkCore;

    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        { }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogImage> CatalogImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=catalog-sqlite.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Catalog>()
            //     .HasOne(b => b.Thumbnail)
            //     .WithOne();
            modelBuilder.Entity<Catalog>()
                .HasMany(b => b.Images)
                .WithOne();
        }
    }
}