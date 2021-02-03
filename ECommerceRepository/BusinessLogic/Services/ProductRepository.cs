using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Get all products that are associated with the provided Category name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public List<Product> GetProductByCategoryName(string categoryName)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var category = context.Categories.SingleOrDefault(item => string.Equals(item.CategoryName, categoryName, StringComparison.InvariantCultureIgnoreCase));

                return context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").
                    Where(x => x.CategoryId == category.Id).ToList();
            }
        }

        /// <summary>
        /// Get a product by the Product name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public Product GetProductByProductName(string productName)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").
                    SingleOrDefault(p =>
                        string.Equals(p.ProductName, productName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        /// <summary>
        /// Gets a list of products selected at random with the maximum amount being provided in the parameter.
        /// </summary>
        /// <param name="numberOfProducts"></param>
        /// <returns></returns>
        public List<Product> GetRandomProducts(int numberOfProducts)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var listAllProducts = context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").ToList();

                return listAllProducts.Take(3).ToList();
            }
        }

        /// <summary>
        /// Gets a list of products that the User has previously viewed or purchased.
        /// </summary>
        /// <param name="numberOfProducts"></param>
        /// <returns></returns>
        public List<Product> GetSuggestedProductsByUser(int userId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var listAllProducts = context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").ToList();

                return listAllProducts.Take(3).ToList();
            }
        }

        //TODO: Possibly rename this method?
        /// <summary>
        /// Decreases the quantity of a Product by 1.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        public bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var product = context.Products.
                    Include("ProductType")
                    .SingleOrDefault(p => p.Id == productId);

                if (product == null)
                {
                    return false;
                }

                var productSizes = context.ProductSizes.SingleOrDefault(p => p.ProductTypeId == product.ProductTypeId);
                var size = context.ProductSizes.SingleOrDefault(p => p.Id == sizeId);

                if (size == null)
                {
                    return false;
                }

                size.Quantity -= quantityToReduce;
                context.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Gets the Product based off of the Product ID provided.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(int productId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").Single(p => p.Id == productId);
            }
        }

        public List<Product> GetFiveLowestStockProducts()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var listProducts = context.Products
                    .Include("Sizes")
                    .Include("Brand")
                    .Include("ProductType")
                    .ToList();

                foreach (var product in listProducts)
                {
                    product.Sizes = context
                        .ProductSizes
                        .Where(p => p.ProductTypeId == product.ProductTypeId).ToList();
                }
                
                return listProducts
                    .OrderBy(x => x.Sizes.Sum(p => p.Quantity))
                    .Take(5).ToList();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType")
                    .ToList();
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var productEntity = context.Products.
                    Include("Images").
                    Include("Brand").
                    Include("Sizes").
                    Include("ProductType").
                    SingleOrDefault(p => p.Id == productId);

                if (productEntity != null)
                {
                    context.Products.Remove(productEntity);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool ProductNameExists(string productName)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products
                    .Any(p => string.Equals(p.ProductName, productName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public bool AddProduct(Product productEntity)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                try
                {
                    context.Products.Add(productEntity);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}