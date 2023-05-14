using System.Net.Http.Json;

namespace Orion.Domain.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public JsonContent Meta { get; set; }
    }
}
