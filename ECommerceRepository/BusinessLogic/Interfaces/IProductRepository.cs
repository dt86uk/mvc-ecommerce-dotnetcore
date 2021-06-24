using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    /// <summary>
    /// Queries & Updates the database and returns the Entity Framework models for Products
    /// </summary>
    public interface IProductRepository
    {
        List<Product> GetProductByCategoryName(string categoryName);
        Product GetProductByProductName(string productName);
        List<Product> GetRandomProducts(int numberOfProducts);
        List<Product> GetSuggestedProductsByUser(int userId);
        bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce);
        Product GetProductById(int productId);
        List<Product> GetFiveLowestStockProducts();
        List<Product> GetAllProducts();
        bool Delete(int productId);
        bool ProductNameExists(string productName, int? productId);
        bool Add(Product productEntity);
        bool Update(Product productEntity);
        string GetProductNameById(int productId);
    }
}