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
        private readonly IImageUploadService _imageUploadService;

        public CatalogService(CatalogDbContext dbContext,IImageUploadService imageUploadService)
        {
            _dbContext = dbContext;
            _imageUploadService = imageUploadService;
        }

        public async Task<Catalog> GetCatalogById(int id)
        {
            var catalog = await _dbContext.Catalogs.Where(c => c.Id == id).Include(c => c.Images).OrderByDescending(x=> x.Id).FirstOrDefaultAsync();
            return catalog?.ToDomain();
        }
        public async Task<List<Catalog>> GetCatalogs()
        {
            var catalogList = await _dbContext.Catalogs.Include(c => c.Images).OrderByDescending(x=>x.Id).ToListAsync();
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
                UpdateAssociatedImages(existingCatalogData,catalog);

                existingCatalogData.SyncWithDomain(catalog);
                
                var entry = _dbContext.Catalogs.Update(existingCatalogData);
                await _dbContext.SaveChangesAsync();
                return entry?.Entity?.ToDomain();
            }

            return null;
        }
        public async Task<bool> DeleteCatalog(int catalogId)
        {
            var entry =  await _dbContext.Catalogs.Where(c => c.Id == catalogId).
            Include(c => c.Images).FirstOrDefaultAsync();
            if (entry != null)
            {
                _dbContext.Catalogs.Remove(entry);
                await _dbContext.SaveChangesAsync();

                //Deleting images on delete of catalog
                DeleteImageOnUpdate(entry.Images);
                 
                return true;
            }
            return false;
        }

        private string[] GetImagesPath(List<DataSource.Model.CatalogImage> catalogImages)
        {
            List<string> strList = new List<string>();
            foreach(var imageObj in catalogImages)
            {
                strList.Add(imageObj.Path);
            }

            return strList.ToArray();
        }

        private void UpdateAssociatedImages(DataSource.Model.Catalog existingCatalogData, Catalog catalog)
        {
            // Map catalog image with datasource.model.catalogimage
            var catalogImages  = catalog.Images.Select(a => new DataSource.Model.CatalogImage() 
                                { Id  = a.Id, Path = a.Path }).ToList();
            
            //get the images which needs to be deleted
            var deleted = existingCatalogData.Images.Where(c =>!catalogImages.Any(d => d.Path == c.Path)).ToList();

            //delete images which removed from reference
            DeleteImageOnUpdate(deleted);
        }

        private void DeleteImageOnUpdate(List<DataSource.Model.CatalogImage> imagesToBeDeleted)
        {
            //Deleting images on delete of catalog
            string[] imagePathArray = GetImagesPath(imagesToBeDeleted);
            if(imagePathArray != null && imagePathArray.Any())
            {
                _imageUploadService.DeleteImages(imagePathArray);
            }
        }
    }
}