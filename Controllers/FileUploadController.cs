using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatalogApi.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace CatalogueApi.Controllers
{
    [Route("productCatalog/[controller]")]  
    [ApiController]
    public class FileUploadController : ControllerBase  
    {  
        private readonly IImageUploadService _uploadService;
        public FileUploadController(IImageUploadService uploadService)  
        {  
            _uploadService = uploadService;
        }  
        [HttpPost]  
        public async Task<string> Post([FromForm(Name = "file")]IFormFile file)  
        {  
            return await _uploadService.UploadImage(file);
        }


    }  
    
}