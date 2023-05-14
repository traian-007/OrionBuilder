using Mapster;
using Orion.Application.Packages.Commands.CreatePackage;
using Orion.Contracts.Packages;

namespace Orion.API.Common.Mapping
{
    public class PackageMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreatePackageRequest Request, string HostId), CreatePackageCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);
        }
    }
}
