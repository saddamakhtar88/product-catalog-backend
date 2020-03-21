namespace CatalogApi.Services
{
    using Domain.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        Task<List<Message>> GetMessages();
        Task<Message> AddMessage(Message message);
    }
}