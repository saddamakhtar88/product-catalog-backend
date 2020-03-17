namespace CatalogApi.DataSource.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class Catalog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public List<CatalogImage> Images { get; set; }

        public Domain.Model.Catalog ToDomain()
        {
            return new Domain.Model.Catalog
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                Thumbnail = this.Thumbnail,
                Images = this.Images.Select(i => i.ToDomain()).ToList()
            };
        }

        public void SyncWithDomain(Domain.Model.Catalog domain)
        {
            this.Title = domain.Title;
            this.Description = domain.Description;
            this.Thumbnail = domain.Thumbnail;

            var updatedImages = new List<CatalogImage>();

            int i = 0;

            if (this.Images != null)
            {
                for (; i < this.Images.Count; i++)
                {
                    if (i < domain.Images.Count)
                    {
                        Images[i].SyncWithDomain(domain.Images[i]);
                        updatedImages.Add(Images[i]);
                    }
                }
            }
            if (i < domain.Images.Count)
            {
                for (; i < domain.Images.Count; i++)
                {
                    var catalogDataItem = new DataSource.Model.CatalogImage();
                    catalogDataItem.SyncWithDomain(domain.Images[i]);
                    updatedImages.Add(catalogDataItem);
                }
            }

            this.Images = updatedImages;
        }
    }
}