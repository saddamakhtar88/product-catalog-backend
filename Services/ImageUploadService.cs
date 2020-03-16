using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CatalogApi.Services
{
    public class ImageUploadService : IImageUploadService
    {
        const string folderName = "Images";  
        readonly string folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        
        public ImageUploadService()
        {
            if (!Directory.Exists(folderPath))  
            {  
                Directory.CreateDirectory(folderPath);  
            }  
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            var fileName = string.Concat("Image_", Guid.NewGuid(),Path.GetExtension(file.FileName));

            var filePath = Path.Combine(folderPath, fileName);  
            
            using (var fileStream = new FileStream(filePath, FileMode.Create)) 
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }
        
    }
}