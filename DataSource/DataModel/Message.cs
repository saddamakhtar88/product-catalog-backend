using System;

namespace CatalogApi.DataSource.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageText{get;set;}
        public DateTime PostedDate{get;set;}
        public string EmailID { get; set; }
        public string PhoneNumber {get;set;}

        public Domain.Model.Message ToDomain(bool fromGet)
        {
            return new Domain.Model.Message
            {
                Id = this.Id,
                EmailID = this.EmailID,
                MessageText = this.MessageText,
                PhoneNumber = this.PhoneNumber,
                Name = this.Name,
                PostedDate = fromGet? this.PostedDate: DateTime.Now
            };
        }


        public void SyncWithDomain(Domain.Model.Message domain)
        {
            this.Id = domain.Id;
            this.EmailID = domain.EmailID;
            this.MessageText = domain.MessageText;
            this.PhoneNumber = domain.PhoneNumber;
            this.Name = domain.Name;
            this.PostedDate = DateTime.Now;
        }
    }
}