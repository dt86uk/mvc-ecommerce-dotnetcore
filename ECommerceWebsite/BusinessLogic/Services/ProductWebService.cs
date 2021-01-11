using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Helpers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class ProductWebService : IProductWebService
    {
        private readonly IProductService _productService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        //TODO: Configure Mapper for EPVM, PsVM, PVM
        public ProductWebService(IProductService productService)
        {
            _productService = productService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public ProductViewModel GetProductByProductName(string productName)
        {
            var product = _productService.GetProductByProductName(productName);

            if (product == null)
            {
                return new ProductViewModel();    
            }

            string genderDesc = ProductHelper.GetGenderDescription(product.Gender);

            //move to helper class to BuildViewModel => Use AutoMapper
            var productViewModel = new ProductViewModel()
            {
                Title = product.Title,
                Category = mapper.Map<CategoryDTO, CategoryItemViewModel>(product.Category),
                Description = product.Description,
                Gender = genderDesc,
                HeroImage = product.HeroImage,
                HeroTitle = product.HeroTitle,
                Images = new List<ProductImageViewModel>(),
                Brand = new BrandViewModel()
                {
                    Id = product.Brand.Id,
                    BrandName = product.Brand.BrandName
                },
                Sizes = new List<ProductSizeViewModel>(),
                ProductType = new ProductTypeViewModel()
                {
                    Id = product.ProductType.Id,
                    ProductTypeName = product.ProductType.ProductTypeName
                },
                Price = product.Price,
                AddToCart = new AddToCartViewModel()
                {
                    ProductId = product.Id
                }
            };

            foreach (var image in product.Images)
            {
                var base64 = Convert.ToBase64String(image.Image);
                
                productViewModel.Images.Add(new ProductImageViewModel()
                {
                    Id = image.Id,
                    ImageSrc = $"data:image/jpeg;base64,{base64}"
                });
            }

            foreach (var size in product.Sizes)
            {
                var productSizeViewModel = mapper.Map<ProductSizeDTO, ProductSizeViewModel>(size);
                productViewModel.Sizes.Add(productSizeViewModel);
            }

            return productViewModel;
        }

        public List<SuggestedProductViewModel> GetSuggestedProducts(int userId, string httpContextHost)
        {
            var listSuggestedProducts = new List<SuggestedProductViewModel>();
            var listProducts = _productService.GetSuggestedProducts(userId);

            foreach (var product in listProducts)
            {
                var listImagesNoHero = product.Images.Where(p => !p.FilePath.ToLower().Contains("hero")).ToList();
                var base64 = Convert.ToBase64String(listImagesNoHero.First().Image);

                listSuggestedProducts.Add(new SuggestedProductViewModel()
                {
                    Category = product.Category != null ? product.Category.CategoryName : "Featured",
                    ImageSrc = $"data:image/jpeg;base64,{base64}",
                    ProductName = product.Title,
                    Url = $"https://{httpContextHost}/product/{product.Title.ToLower().Trim().Replace(" ", "-")}"
                });
            }

            return listSuggestedProducts;
        }

        public ProductViewModel GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            string genderDesc = ProductHelper.GetGenderDescription(product.Gender);

            var productViewModel = new ProductViewModel()
            {
                Title = product.Title,
                Category = mapper.Map<CategoryDTO, CategoryItemViewModel>(product.Category),
                Description = product.Description,
                Gender = genderDesc,
                HeroImage = product.HeroImage,
                HeroTitle = product.HeroTitle,
                Images = new List<ProductImageViewModel>(),
                Brand = new BrandViewModel()
                {
                    Id = product.Brand.Id,
                    BrandName = product.Brand.BrandName
                },
                Sizes = new List<ProductSizeViewModel>(),
                ProductType = new ProductTypeViewModel()
                {
                    Id = product.ProductType.Id,
                    ProductTypeName = product.ProductType.ProductTypeName
                },
                Price = product.Price,
                AddToCart = new AddToCartViewModel()
                {
                    ProductId = product.Id
                }
            };

            foreach (var image in product.Images)
            {
                var base64 = Convert.ToBase64String(image.Image);

                productViewModel.Images.Add(new ProductImageViewModel()
                {
                    Id = image.Id,
                    ImageSrc = $"data:image/jpeg;base64,{base64}"
                });
            }

            foreach (var size in product.Sizes)
            {
                productViewModel.Sizes.Add(new ProductSizeViewModel()
                {
                    Id = size.Id,
                    Quantity = size.Quantity,
                    Size = size.Size
                });
            }

            return productViewModel;
        }

        public EditProductViewModel GetProductById(ProductsViewModel productsViewModel)
        {
            var product = _productService.GetProductById(productsViewModel.Id);
            string genderDesc = ProductHelper.GetGenderDescription(product.Gender);

            var editProductViewModel = new EditProductViewModel()
            {
                Id = productsViewModel.Id,
                Title = product.Title,
                Category = mapper.Map<CategoryDTO, CategoryItemViewModel>(product.Category),
                Description = product.Description,
                Gender = genderDesc,
                HeroImage = product.HeroImage,
                HeroTitle = product.HeroTitle,
                Images = new List<ProductImageViewModel>(),
                Brand = new BrandViewModel()
                {
                    Id = product.Brand.Id,
                    BrandName = product.Brand.BrandName
                },
                Sizes = new List<ProductSizeViewModel>(),
                ProductType = new ProductTypeViewModel()
                {
                    Id = product.ProductType.Id,
                    ProductTypeName = product.ProductType.ProductTypeName
                },
                Price = product.Price
            };

            foreach (var image in product.Images)
            {
                var base64 = Convert.ToBase64String(image.Image);

                editProductViewModel.Images.Add(new ProductImageViewModel()
                {
                    Id = image.Id,
                    ImageSrc = $"data:image/jpeg;base64,{base64}"
                });
            }

            foreach (var size in product.Sizes)
            {
                editProductViewModel.Sizes.Add(new ProductSizeViewModel()
                {
                    Id = size.Id,
                    Quantity = size.Quantity,
                    Size = size.Size
                });
            }

            return editProductViewModel;
        }

        public bool ProductQuantityIsOk(int productId, int sizeId)
        {
            var product = _productService.GetProductById(productId);
            var size = product.Sizes.SingleOrDefault(p => p.Id == sizeId);
            var newQuantity = size.Quantity - 1;
            
            return newQuantity >= 0;
        }

        public bool ReduceProductQuantity(int productId, int sizeId, int quantityToReduce)
        {
            return _productService.ReduceProductQuantity(productId, sizeId, quantityToReduce);
        }

        public CategoryProductsViewModel GetProductsByCategoryName(string categoryName, string httpContextHost)
        {
            var listProductsDto = _productService.GetProductsByCategoryName(categoryName);

            foreach (var product in listProductsDto)
            {
                product.Url = $"https://{httpContextHost}/product/{product.Title.ToLower().Trim().Replace(" ", "-")}";
            }

            string formattedCategoryName = $"{char.ToUpper(categoryName[0])}{categoryName.Substring(1, categoryName.Length - 1)}";
            
            var model = new CategoryProductsViewModel()
            {
                CategoryName = formattedCategoryName,
                Products = mapper.Map<List<ProductDTO>, List<CategoryProductItemViewMoel>>(listProductsDto)
            };

            return model;
        }

        public AdminProductsViewModel GetAllProducts()
        {
            var listProductsDto = _productService.GetAllProducts();
            var listProdctsViewModel = mapper.Map<List<ProductDTO>, List<ProductsViewModel>>(listProductsDto);

            return new AdminProductsViewModel() 
            { 
                AllProducts = listProdctsViewModel 
            };
        }

        public bool DeleteProduct(int productId)
        {
            return _productService.DeleteProduct(productId);
        }
    }
}