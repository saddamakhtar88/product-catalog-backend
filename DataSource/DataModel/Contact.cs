namespace CatalogApi.DataSource.Model
{
    public class Contact
    {
       
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string AdditionalInfo { get; set; }

        public Domain.Model.Contact ToDomain()
        {
            return new Domain.Model.Contact
            {
                Id = this.Id,
                EmailID = this.EmailID,
                AdditionalInfo = this.AdditionalInfo,
                PhoneNumber = this.PhoneNumber
            };
        }

        public void SyncWithDomain(Domain.Model.Contact domain)
        {
            this.Id = domain.Id;
            this.EmailID = domain.EmailID;
            this.AdditionalInfo = domain.AdditionalInfo;
            this.PhoneNumber = domain.PhoneNumber;
        }
    }
}