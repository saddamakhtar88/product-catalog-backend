namespace Catalog.Services
{
    using Catalog.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class CatalogService : DbContext, ICatalogService
    {
        public CatalogService(DbContextOptions<CatalogService> options) : base(options)
        { }

        private DbSet<Catalog> Catalogs { get; set; }
        private DbSet<CatalogImage> CatalogImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Catalog>()
            //     .HasOne(b => b.Thumbnail)
            //     .WithOne();
            modelBuilder.Entity<Catalog>()
                .HasMany(b => b.Images)
                .WithOne();
        }

        public async Task<Catalog> GetCatalogById(int id)
        {
            return await Catalogs.Where(c => c.Id == id).Include(c => c.Images).FirstOrDefaultAsync();
        }
        public async Task<List<Catalog>> GetCatalogs()
        {
            return await Catalogs.Include(c => c.Images).ToListAsync();
        }
        public async Task<Catalog> AddCatalog(Catalog catalog)
        {
            var entry = Catalogs.Add(catalog);
            await SaveChangesAsync();
            return entry.Entity;
        }
        public async Task<Catalog> UpdateCatalog(Catalog catalog)
        {
            var entry = Catalogs.Update(catalog);
            await SaveChangesAsync();
            return entry.Entity;
        }
        public async Task<bool> DeleteCatalog(int catalogId)
        {
            var entry = Catalogs.Find(catalogId);
            if (entry != null)
            {
                Catalogs.Remove(entry);
                await SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}