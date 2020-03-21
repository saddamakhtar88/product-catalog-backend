namespace CatalogApi.Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageText{get;set;}
        public DateTime PostedDate{get;set;}
        public string EmailID { get; set; }
        public string PhoneNumber {get;set;}
    }
}