namespace Orion.Domain.Entities
{
    public class ServiceFeatureEntity : BaseEntity
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
    }
}
