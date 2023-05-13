using Mapster;
using Orion.Application.Authentication.Commands.Register;
using Orion.Application.Authentication.Common;
using Orion.Application.Authentication.Queries.Login;
using Orion.Contracts.Authentication;

namespace Orion.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
