using Orion.Domain.Enum;
using System.Net.Http.Json;

namespace Orion.Domain.Entities
{
    public class PackageEntity : BaseEntity
    {
       
        public PackageType Type { get; set; }
        public IEnumerable<string> Features { get; set; }
        public int Price { get; set; }
        public int ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
        public JsonContent Meta { get; set; }
    }
}
