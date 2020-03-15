namespace CatalogApi.Services
{
    using DataSource;
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class CatalogService : ICatalogService
    {
        private CatalogDbContext _dbContext { get; }

        public CatalogService(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Catalog> GetCatalogById(int id)
        {
            var catalog = await _dbContext.Catalogs.Where(c => c.Id == id).Include(c => c.Images).FirstOrDefaultAsync();
            return catalog?.ToDomain();
        }
        public async Task<List<Catalog>> GetCatalogs()
        {
            var catalogList = await _dbContext.Catalogs.Include(c => c.Images).ToListAsync();
            return catalogList.Select(c => c.ToDomain()).ToList();
        }
        public async Task<Catalog> AddCatalog(Catalog catalog)
        {
            var catalogDataItem = new DataSource.Model.Catalog();
            catalogDataItem.SyncWithDomain(catalog);
            var entry = _dbContext.Catalogs.Add(catalogDataItem);
            await _dbContext.SaveChangesAsync();
            return entry?.Entity?.ToDomain();
        }
        public async Task<Catalog> UpdateCatalog(Catalog catalog)
        {
            var existingCatalogData = await _dbContext.Catalogs.Where(c => c.Id == catalog.Id).Include(c => c.Images).FirstOrDefaultAsync();
            if (existingCatalogData != null)
            {
                existingCatalogData.SyncWithDomain(catalog);
                var entry = _dbContext.Catalogs.Update(existingCatalogData);
                await _dbContext.SaveChangesAsync();
                return entry?.Entity?.ToDomain();
            }

            return null;
        }
        public async Task<bool> DeleteCatalog(int catalogId)
        {
            var entry = _dbContext.Catalogs.Find(catalogId);
            if (entry != null)
            {
                _dbContext.Catalogs.Remove(entry);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}