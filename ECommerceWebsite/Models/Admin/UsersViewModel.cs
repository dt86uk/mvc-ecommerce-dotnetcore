using System;

namespace ECommerceWebsite.Models.Admin
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsSubscribed { get; set; }
        public string RoleName { get; set; }
    }
}