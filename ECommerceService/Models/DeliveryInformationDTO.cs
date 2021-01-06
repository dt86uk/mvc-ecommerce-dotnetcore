namespace ECommerceService.Models
{
    public class DeliveryInformationDTO : AddressDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeliveryMethod { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}