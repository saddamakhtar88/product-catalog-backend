namespace CatalogApi.DataSource.Model
{
    public class CatalogImage
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int CatalogId { get; set; }

        public Domain.Model.CatalogImage ToDomain()
        {
            return new Domain.Model.CatalogImage
            {
                Path = this.Path
            };
        }

        public void SyncWithDomain(Domain.Model.CatalogImage domain)
        {
            this.Path = domain.Path;
        }
    }
}