namespace ECommerceService.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsGender => CategoryName != "New Releases";
    }
}