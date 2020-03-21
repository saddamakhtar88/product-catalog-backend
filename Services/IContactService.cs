namespace CatalogApi.Services
{
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContactService
    {
        Task<Contact> GetContact();
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
    }
}