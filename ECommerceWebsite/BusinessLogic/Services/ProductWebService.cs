using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Helpers;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebsite.BusinessLogic
{
    public class ProductWebService : IProductWebService
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _productTypeService;
        private readonly IGenderService _genderService;
        private readonly IFileValidationWebService _fileValidationWebService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        //TODO: Configure Mapper for EPVM, PsVM, PVM
        public ProductWebService(IProductService productService, IBrandService brandService, ICategoryService categoryService, 
            IProductTypeService productTypeService, IGenderService genderService, IFileValidationWebService fileValidationWebService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _productTypeService = productTypeService;
            _genderService = genderService;
            _fileValidationWebService = fileValidationWebService;

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
                ProductName = product.ProductName,
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
                    ProductName = product.ProductName,
                    Url = $"https://{httpContextHost}/product/{product.ProductName.ToLower().Trim().Replace(" ", "-")}"
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
                ProductName = product.ProductName,
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
                ProductName = product.ProductName,
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
                product.Url = $"https://{httpContextHost}/product/{product.ProductName.ToLower().Trim().Replace(" ", "-")}";
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

        public AddProductViewModel GetAddProductsContents()
        {
            AddProductContentsDTO addProductDto = _productService.GetAddProductContents();
            var model = new AddProductViewModel();

            foreach (var brand in addProductDto.Brands)
            {
                model.Brands.Add(new SelectListItem()
                {
                    Value = brand.Id.ToString(),
                    Text = brand.BrandName
                });
            }

            foreach (var category in addProductDto.Categories)
            {
                model.Categories.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName
                });
            }

            foreach (var genders in addProductDto.Genders)
            {
                model.Genders.Add(new SelectListItem()
                {
                    Value = genders.Id.ToString(),
                    Text = genders.Name
                });
            }

            foreach (var productType in addProductDto.ProductTypes)
            {
                model.ProductTypes.Add(new SelectListItem()
                {
                    Value = productType.Id.ToString(),
                    Text = productType.ProductTypeName
                });
            }

            foreach (var size in addProductDto.Sizes)
            {
                model.ProductTypes.Add(new SelectListItem()
                {
                    Value = size.Id.ToString(),
                    Text = size.Size
                });
            }

            return model;
        }

        public AddProductViewModel GetAddProductsContent(AddProductViewModel model = null)
        {
            if (model == null)
            {
                model = new AddProductViewModel();
            }
            
            var addProductContents = _productService.GetAddProductContents();

            foreach (var brand in addProductContents.Brands)
            {
                model.Brands.Add(new SelectListItem()
                {
                    Value = brand.Id.ToString(),
                    Text = brand.BrandName
                });
            }

            foreach (var category in addProductContents.Categories)
            {
                model.Categories.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName
                });
            }

            foreach (var gender in addProductContents.Genders)
            {
                model.Genders.Add(new SelectListItem()
                {
                    Value = gender.Id.ToString(),
                    Text = gender.Name
                });
            }

            foreach (var productType in addProductContents.ProductTypes)
            {
                model.ProductTypes.Add(new SelectListItem()
                {
                    Value = productType.Id.ToString(),
                    Text = productType.ProductTypeName
                });
            }

            foreach (var size in addProductContents.Sizes)
            {
                model.Sizes.Add(new SelectListItem()
                {
                    Value = size.Id.ToString(),
                    Text = size.Size
                });
            }

            return model;
        }

        public BaseWebServiceResponse AddProduct(AddProductViewModel model)
        {
            var response = new BaseWebServiceResponse();

            if (_productService.ProductNameExists(model.ProductName))
            {

                response.Error.Name = "Product Name";
                response.Error.Message = "Product Name exists";

                return response;
            }

            decimal price;
            if (!decimal.TryParse(model.Price, out price))
            {
                response.ActionSuccessful = false;
                response.Error.Name = "Price";
                response.Error.Message = "Price must be a decimal value e.g. 100.00";

                return response;
            }

            List<IFormFile> listFiles = new List<IFormFile>()
            {
                model.Image1,
                model.Image2,
                model.Image3,
                model.Image4,
            };

            bool fileExists = _fileValidationWebService.FileExists(listFiles);
            if (!fileExists)
            {
                response.Error.Name = "Images";
                response.Error.Message = "At least one Image must be uploaded.";

                return response;
            }

            bool filesAreJpg = _fileValidationWebService.IsFileFormatJpg(listFiles);
            if (!filesAreJpg)
            {
                response.Error.Name = "Images";
                response.Error.Message = "Files must be jpg file format.";

                return response;
            }

            var productDto = mapper.Map<AddProductViewModel, ProductDTO>(model);
            productDto.Gender = _genderService.GetGenderById(Convert.ToInt32(model.SelectedGender));
            productDto.Price = price;
            productDto.HeroImage = ProductHelper.WriteImageToBytes(model.HeroImage);
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image1) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image2) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image3) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image4) });

            if (!_productService.AddProduct(productDto))
            {
                response.Error.Name = "Add Product";
                response.Error.Message = "There was a problem while attempting to add the Product, please try again. If this problem persists, please contact support.";

                return response;
            }

            response.ActionSuccessful = true;
            return response;
        }
    }
}