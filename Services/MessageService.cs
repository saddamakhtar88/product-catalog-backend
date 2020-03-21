namespace CatalogApi.Services
{
    using DataSource;
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class MessageService : IMessageService
    {
        private CatalogDbContext _dbContext { get; }

        public MessageService(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Message>> GetMessages()
        {
            var messagesList = await _dbContext.Messages.ToListAsync();
            if(messagesList != null)
            {
                var listOfMessages = messagesList.Select(c => c.ToDomain()).ToList();
                return listOfMessages.OrderByDescending(x=>x.PostedDate).ToList();
            }
            return null;    
        }

        public async Task<Message> AddMessage(Message message)
        {
             var messageDataItem = new DataSource.Model.Message();
            messageDataItem.SyncWithDomain(message);
            var entry = _dbContext.Messages.Add(messageDataItem);
            await _dbContext.SaveChangesAsync();
            return entry?.Entity?.ToDomain();
        }
    }
}