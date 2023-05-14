using Orion.Domain.Enum;
using System.Net.Http.Json;

namespace Orion.Domain.Entities
{
    public class SubscriptionEntity : BaseEntity
    {
        public JsonContent Meta { get; set; }
        public Status Status { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int PackageId { get; set; }
        public PackageEntity Package { get; set; }

    }
}
