namespace Catalog.Dto
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class CatalogImage
    {
        public int Id { get; set; }

        public string URL { get; set; }

        public int CatalogId { get; set; }
    }
}