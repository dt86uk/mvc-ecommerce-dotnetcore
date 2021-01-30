namespace ECommerceDatabase.Database.Entities
{
    public class ProductSize
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}