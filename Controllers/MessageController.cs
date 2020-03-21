namespace CatalogApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Domain.Model;

    [Route("productCatalog/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

       [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages()
        {
            return await _messageService.GetMessages();
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            return await _messageService.AddMessage(message);
        }
    }
}
