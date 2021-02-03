namespace ECommerceService.Models
{
    public class CategoryDTO : EntityDTO
    {
        public override string Value => CategoryName;
        public string CategoryName { get; set; }
        public bool IsGender => CategoryName != "New Releases";
    }
}