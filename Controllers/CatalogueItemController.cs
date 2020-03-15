using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogueApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueItemController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public CatalogueItemController(CatalogueContext context)
        {
            _context = context;
        }

        // POST: api/CatalogueItem
        [HttpPost]
        public async Task<ActionResult<CatalogueItem>> PostCatalogueItem(CatalogueItem catalogueItem)
        {
            _context.CatalogueItems.Add(catalogueItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetCatalogueItem), new { id = catalogueItem.Id }, catalogueItem);
        }


        // GET: api/CatalogueItem/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CatalogueItem>> GetCatalogueItem(int Id)
        {
            var catalogueItem = await _context.CatalogueItems.FindAsync(Id);

            if (catalogueItem == null)
            {
                return NotFound();
            }

            return catalogueItem;
        }

        [HttpGet]
        public async Task<ActionResult<List<CatalogueItem>>> GetCatalogueItems()
        {
            return await _context.CatalogueItems.ToListAsync();
        }
    }
}
