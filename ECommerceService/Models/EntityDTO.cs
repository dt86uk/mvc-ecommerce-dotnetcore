namespace ECommerceService.Models
{
    public abstract class EntityDTO
    {
        public int Id { get; set; }
        public virtual string Value { get; set; }
    }
}