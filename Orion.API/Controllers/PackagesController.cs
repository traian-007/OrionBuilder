using Microsoft.AspNetCore.Mvc;

namespace Orion.API.Controllers
{
    [Route("[controller]")]
    public class PackagesController : ApiController
    {
        [HttpGet]
        public IActionResult ListPackages()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
