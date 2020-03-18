namespace CatalogApi.Domain.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class CatalogImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
}