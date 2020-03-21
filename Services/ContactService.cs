namespace CatalogApi.Services
{
    using DataSource;
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ContactService : IContactService
    {
        private CatalogDbContext _dbContext { get; }

        public ContactService(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> GetContact()
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync();
            return contact?.ToDomain();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
             var contactDataItem = new DataSource.Model.Contact();
            contactDataItem.SyncWithDomain(contact);
            var entry = _dbContext.Contacts.Add(contactDataItem);
            await _dbContext.SaveChangesAsync();
            return entry?.Entity?.ToDomain();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var existingContactData = await _dbContext.Contacts.Where(c => c.Id == contact.Id).FirstOrDefaultAsync();
            if (existingContactData != null)
            {
                existingContactData.SyncWithDomain(contact);
                var entry = _dbContext.Contacts.Update(existingContactData);
                await _dbContext.SaveChangesAsync();
                return entry?.Entity?.ToDomain();
            }

            return null;
        }
    }
}