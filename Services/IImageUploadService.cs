namespace CatalogApi.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImageUploadService
    {
        Task<string> UploadImage(IFormFile file);
    }
    
}