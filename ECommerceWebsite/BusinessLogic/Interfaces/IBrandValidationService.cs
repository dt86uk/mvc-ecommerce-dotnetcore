namespace ECommerceWebsite.BusinessLogic
{
    public interface IBrandValidationService
    {
        bool BrandNameExists(string brandName);
        bool BrandNameExists(string brandName, int brandId);
    }
}