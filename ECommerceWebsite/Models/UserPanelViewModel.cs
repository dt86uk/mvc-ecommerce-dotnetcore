namespace ECommerceWebsite.Models
{
    public class UserPanelViewModel
    {
        public bool IsUserLoggedIn { get; set; }
        public UserViewModel User { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}