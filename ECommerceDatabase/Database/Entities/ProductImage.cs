namespace ECommerceDatabase.Database.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FilePath { get; set; }

        public virtual Product Product { get; set; }
    }
}