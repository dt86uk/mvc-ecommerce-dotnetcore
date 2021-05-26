namespace ECommerceWebsite.BusinessLogic
{
    public interface ICategoryValidationService
    {
        bool CategoryHasProducts(int categoryId);
    }
}