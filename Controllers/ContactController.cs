namespace CatalogApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Domain.Model;

    [Route("productCatalog/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<Contact>> Get()
        {
            var contact = await _contactService.GetContact();

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Put(Contact contact)
        {
            return await _contactService.UpdateContact(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Post(Contact contact)
        {
            return await _contactService.AddContact(contact);
        }
    }
}
