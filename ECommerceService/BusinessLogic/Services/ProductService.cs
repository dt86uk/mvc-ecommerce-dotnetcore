using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        /// <summary>
        /// Gets Product by product Id provided.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductDTO GetProductById(int productId)
        {
            return mapper.Map<Product, ProductDTO>(_productRepository.GetProductById(productId));
        }

        /// <summary>
        /// Gets list of Product by product name provided.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public ProductDTO GetProductByProductName(string productName)
        {
            var strippedProductName = productName.Replace("-", " ");
            var product = _productRepository.GetProductByProductName(strippedProductName);
            
            return mapper.Map<Product, ProductDTO>(product);
        }

        /// <summary>
        /// Gets list of Products by the Category name provided
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public List<ProductDTO> GetProductsByCategoryName(string categoryName)
        {
            var listProducts = _productRepository.GetProductByCategoryName(categoryName);

            return mapper.Map<List<Product>, List<ProductDTO>>(listProducts);
        }

        /// <summary>
        /// If userId is 0 then we get 3 random products else we return related Products that the user has viewed or purchased.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ProductDTO> GetSuggestedProducts(int userId)
        {
            List<Product> listProducts;
            if (userId == 0)
            {
                //get three random products
                listProducts = _productRepository.GetRandomProducts(3);
            }
            else
            {
                listProducts = _productRepository.GetSuggestedProductsByUser(userId);
            }

            return mapper.Map<List<Product>, List<ProductDTO>>(listProducts);
        }

        /// <summary>
        /// Lowers the quantity of the product's size quantity by provided integer (quantityToReduce)
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        public bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce)
        {
            return _productRepository.ReduceProductQuantity(productId, sizeId, quantityToReduce);
        }
    }
}