namespace Orion.Domain.Entities
{
    public class ServiceFeaturePackageEntity : BaseEntity
    {
        public int Price { get; set; }

        public int ServiceFeatureId { get; set; }
        public ServiceFeatureEntity ServiceFeature { get; set; }
        public int PackageId { get; set; }
        public PackageEntity Package { get; set; }
    }
}
