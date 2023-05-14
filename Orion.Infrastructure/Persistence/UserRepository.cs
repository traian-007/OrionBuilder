using Orion.Application.Common.Interfaces.Persistence;
using Orion.Domain.Entities;

namespace Orion.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public static readonly List<UserEntity> _users = new();
        public void Add(UserEntity user)
        {
            _users.Add(user);

        }

        public UserEntity? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
