namespace CatalogApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("productCatalog/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{password}")]
        public bool Get(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return password == "AKHTAR"? true : false;
            }

            return false;
        }
    }
}