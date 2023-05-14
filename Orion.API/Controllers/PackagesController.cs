using Microsoft.AspNetCore.Mvc;
using Orion.Contracts.Packages;

namespace Orion.API.Controllers
{
    [Route("api/{hostId}/packages")]
    public class PackagesController : ApiController
    {
        [HttpPost]
        public IActionResult CreatePackage(
            CreatePackageRequest request,
            string hostId)
        {
            return Ok(request);
        }

        [HttpGet]
        public IActionResult ListPackages()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
