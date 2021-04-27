namespace ECommerceService.Models
{
    public class RoleDTO : EntityDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public override string Value => RoleName;
    }
}
