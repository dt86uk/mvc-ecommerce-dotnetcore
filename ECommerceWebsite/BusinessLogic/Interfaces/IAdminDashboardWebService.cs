using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IAdminDashboardWebService
    {
        AdminHomeViewModel GetDashboard();
    }
}
