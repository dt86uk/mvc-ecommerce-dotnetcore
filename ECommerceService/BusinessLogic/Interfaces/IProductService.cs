using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// Serves Products and updates quantities from the Product Repository
    /// </summary>
    public interface IProductService
    {
        List<ProductDTO> GetProductsByCategoryName(string categoryName);
        ProductDTO GetProductByProductName(string productName);
        List<ProductDTO> GetSuggestedProducts(int userId);
        ProductDTO GetProductById(int productId);
        bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce);
        List<ProductDTO> GetAllProducts();
        bool DeleteProduct(int productId);
    }
}