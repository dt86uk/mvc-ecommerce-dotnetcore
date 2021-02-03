using System.Collections.Generic;
using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository,  ICategoryRepository categoryRepository,
            IProductSizeRepository productSizeRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productSizeRepository = productSizeRepository;
            _productTypeRepository = productTypeRepository;

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

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllProducts()
        {
            var listProductsEntity = _productRepository.GetAllProducts();
            return mapper.Map<List<Product>, List<ProductDTO>>(listProductsEntity);
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public AddProductContentsDTO GetAddProductContents()
        {
            var listGendersDto = new List<GenderDTO>() {
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Female,
                    GenderName = GenderEnum.Female.ToString()
                },
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Male,
                    GenderName = GenderEnum.Male.ToString()
                },
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Unisex,
                    GenderName = GenderEnum.Unisex.ToString()
                }
            };

            var addProductDTO = new AddProductContentsDTO()
            {
                Brands = mapper.Map<List<Brand>, List<BrandDTO>>(_brandRepository.GetAllBrands()),
                Categories = mapper.Map<List<Category>, List<CategoryDTO>>(_categoryRepository.GetAllCategories()),
                Genders = listGendersDto,
                ProductTypes = mapper.Map<List<ProductType>, List<ProductTypeDTO>>(_productTypeRepository.GetAllProductTypes()),
                Sizes = mapper.Map<List<ProductSize>, List<ProductSizeDTO>>(_productSizeRepository.GetAllProductSizes())
            };

            return addProductDTO;
        }

        public bool ProductNameExists(string productName)
        {
            return _productRepository.ProductNameExists(productName);
        }

        public bool AddProduct(ProductDTO productDto)
        {
            var productEntity = mapper.Map<ProductDTO, Product>(productDto);
            return _productRepository.AddProduct(productEntity);
        }
    }
}