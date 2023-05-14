using Orion.Domain.Entities;

namespace Orion.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserEntity user);
    }
}
