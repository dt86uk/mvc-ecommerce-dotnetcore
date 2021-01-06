using ECommerceWebsite.Models;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IProductWebService
    {
        CategoryProductsViewModel GetProductsByCategoryName(string categoryName, string httpContextHost);
        ProductViewModel GetProductByProductName(string productName);
        List<SuggestedProductViewModel> GetSuggestedProducts(int userId, string httpContextHost);
        ProductViewModel GetProductById(int productId);
        bool ProductQuantityIsOk(int productId, int sizeId);
        bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce);
    }
}