namespace CatalogApi.Domain.Model
{
    using System.Collections.Generic;

    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string AdditionalInfo { get; set; }
    }
}