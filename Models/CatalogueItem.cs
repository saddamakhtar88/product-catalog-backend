using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueApi.Models
{
    
    public class CatalogueItem
    {
        public int Id{get;set;}

        public string Title{get;set;}

        public string Description {get;set;}
        
        public CatalogueImage ThumbnailImage{get;set;}

        [BindProperty]
        public List<CatalogueImage> CatalogueImages {get;set;}
    }

    public class CatalogueImage
    {
        public int Id{get;set;}

        public string URL {get;set;}
    }
}