using System;

namespace ECommerceService.Models
{
    [Serializable]
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public bool IsSubscribed { get; set; }
        public string Password { get; set; }
    }
}