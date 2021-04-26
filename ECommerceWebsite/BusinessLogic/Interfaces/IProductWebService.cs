using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IProductWebService
    {
        CategoryProductsViewModel GetProductsByCategoryName(string categoryName, string httpContextHost);
        ProductViewModel GetProductByProductName(string productName);
        List<SuggestedProductViewModel> GetSuggestedProducts(int userId, string httpContextHost);
        ProductViewModel GetProductById(int productId); //TODO: Consider renaming these to more ViewModel based names
        EditProductViewModel GetEditProductById(int productId);
        bool ProductQuantityIsOk(int productId, int sizeId);
        bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce);
        AdminProductsViewModel GetAllProducts();
        bool DeleteProduct(int productId);
        AddProductViewModel GetAddProductsContent(AddProductViewModel model = null);
        BaseWebServiceResponse AddProduct(AddProductViewModel model);
        BaseWebServiceResponse UpdateProduct(EditProductViewModel model);
    }
}