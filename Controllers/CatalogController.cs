namespace CatalogApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Domain.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost]
        public async Task<ActionResult<Catalog>> Post(Catalog catalog)
        {
            return await _catalogService.AddCatalog(catalog);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Catalog>> Get(int Id)
        {
            var catalog = await _catalogService.GetCatalogById(Id);

            if (catalog == null)
            {
                return NotFound();
            }

            return catalog;
        }

        [HttpGet]
        public async Task<ActionResult<List<Catalog>>> GetCatalogs()
        {
            return await _catalogService.GetCatalogs();
        }

        [HttpPut]
        public async Task<ActionResult<Catalog>> Put(Catalog catalog)
        {
            return await _catalogService.UpdateCatalog(catalog);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int catalogId)
        {
            return await _catalogService.DeleteCatalog(catalogId);
        }
    }
}
