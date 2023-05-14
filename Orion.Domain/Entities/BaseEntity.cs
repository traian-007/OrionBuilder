namespace Orion.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; private set; }

        public BaseEntity()
        {
            UpdatedOnUtc = DateTime.Now;
        }
    }
}
