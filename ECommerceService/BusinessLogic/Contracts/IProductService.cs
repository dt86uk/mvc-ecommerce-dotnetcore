﻿using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// Serves Products and updates quantities from the Product Repository
    /// </summary>
    public interface IProductService
    {
        bool Add(ProductDTO addProductDto);
        bool Update(ProductDTO addProductDto);
        bool Delete(int productId);
        List<ProductDTO> GetProductsByCategoryName(string categoryName);
        ProductDTO GetProductByProductName(string productName);
        List<ProductDTO> GetSuggestedProducts(int userId);
        ProductDTO GetProductById(int productId);
        bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce);
        List<ProductDTO> GetAllProducts();
        AddProductContentsDTO GetAddProductContents();
        bool ProductNameExists(string productName, int? productId = null);
    }
}