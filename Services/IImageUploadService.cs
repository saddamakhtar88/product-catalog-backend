namespace CatalogApi.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CatalogApi.DataSource.Model;

    public interface IImageUploadService
    {
        Task<string> UploadImage(IFormFile file);

        bool DeleteImages(string[] imagePaths);
    }
    
}