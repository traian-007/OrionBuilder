using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orion.Application.Packages.Commands.CreatePackage;
using Orion.Contracts.Packages;

namespace Orion.API.Controllers
{
    [Route("api/{hostId}/packages")]
    public class PackagesController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public PackagesController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage(
            CreatePackageRequest request,
            string hostId)
        {
            var command = _mapper.Map<CreatePackageCommand>((request, hostId));

            var createMenuResult = await _mediator.Send(command);
            return Ok(request);
        }

        [HttpGet]
        public IActionResult ListPackages()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
