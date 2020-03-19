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
            Title = domain.Title;
            Description = domain.Description;
            Thumbnail = domain.Thumbnail;

            if (Images == null)
            {
                Images = new List<CatalogImage>();
            }

            var updatedImages = domain.Images.Select(domainImage =>
            {
                var filteredDataImage = Images.Where(dataImage => dataImage.Id == domainImage.Id).FirstOrDefault();
                if (filteredDataImage != null)
                {
                    filteredDataImage.SyncWithDomain(domainImage);
                    return filteredDataImage;
                }
                else
                {
                    var newDataImage = new DataSource.Model.CatalogImage();
                    newDataImage.SyncWithDomain(domainImage);
                    return newDataImage;
                }
            });

            Images = updatedImages.ToList();
        }
    }
}