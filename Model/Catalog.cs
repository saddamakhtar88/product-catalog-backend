namespace CatalogApi.Domain.Model
{
    using System.Collections.Generic;

    public class Catalog
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        // public CatalogImage Thumbnail { get; set; }

        public List<CatalogImage> Images { get; set; }
    }
}