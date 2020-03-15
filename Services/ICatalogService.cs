namespace Catalog.Services
{
    using Catalog.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogService
    {
        Task<Catalog> GetCatalogById(int id);
        Task<List<Catalog>> GetCatalogs();
        Task<Catalog> AddCatalog(Catalog catalog);
        Task<Catalog> UpdateCatalog(Catalog catalog);
        Task<bool> DeleteCatalog(int catalogId);
    }
}