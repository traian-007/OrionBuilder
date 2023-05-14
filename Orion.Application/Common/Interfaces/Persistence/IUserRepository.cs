using Orion.Domain.Entities;

namespace Orion.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        UserEntity? GetUserByEmail(string email);
        void Add(UserEntity user);
    }
}
