namespace CatalogApi.Services
{
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogImageService
    {
        Task<CatalogImage> GetCatalogImageById(int id);
        Task<List<CatalogImage>> GetCatalogImages(int catalogId);
        Task<CatalogImage> AddCatalogImage(CatalogImage catalogImage);
        Task<CatalogImage> UpdateCatalogImage(CatalogImage catalogImage);
        Task<bool> DeleteCatalogImage(CatalogImage catalogImage);
    }
}