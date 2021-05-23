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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
        //TODO: Consider the responsibility of the class, this is doing a lot of leg work, maybe pass to to "Service" layer...
        //TODO: ...cont. And/Or a ValidationService/Helpers/Mappers
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

        public EditProductViewModel GetEditProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            
            var editProductViewModel = new EditProductViewModel()
            {
                Id = productId,
                ProductName = product.ProductName,
                Description = product.Description,
                Genders = SelectListItemHelper.BuildGendersDropDownList(_genderService.GetAllGenders()),
                HeroImageCurrent = product.HeroImage,
                HeroTitle = product.HeroTitle,
                Brands = SelectListItemHelper.BuildDropDownList(_brandService.GetAllBrands()),
                Price = product.Price.ToString(),
                Sizes = mapper.Map<List<ProductSizeDTO>, List<ProductSizeViewModel>>(product.Sizes),
                SizesJson = JsonConvert.SerializeObject(product.Sizes)
            };

            foreach (var gender in editProductViewModel.Genders)
            {
                if (gender.Text == product.Gender)
                {
                    gender.Selected = true;
                }
            }

            var listProductTypes = _productTypeService.GetAllProductTypes();
            foreach (var productType in listProductTypes)
            {
                editProductViewModel.ProductTypes.Add(new SelectListItem()
                {
                    Value = productType.Id.ToString(),
                    Text = productType.Value,
                    Selected = productType.Id == product.CategoryId
                });
            }

            foreach (var image in product.Images)
            {
                //TODO: Try put this in mapper
                if (image.Image.Length > 1)
                {
                    editProductViewModel.ImagesSrc.Add($"data:image/jpeg;base64,{Convert.ToBase64String(image.Image)}");
                    editProductViewModel.ImagesBytes.Add(image.Image);
                }
            }

            var listCategories = _categoryService.GetAllCategories();
            foreach (var category in listCategories)
            {
                editProductViewModel.Categories.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Value,
                    Selected = category.Id == product.CategoryId
                }); ;
            }

            return editProductViewModel;
        }

        //TODO: Refactor this
        public EditProductViewModel GetProductById(EditProductViewModel editProductsViewModel)
        {
            var product = _productService.GetProductById(editProductsViewModel.Id);

            var editProductViewModel = new EditProductViewModel()
            {
                Id = editProductsViewModel.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Genders = SelectListItemHelper.BuildGendersDropDownList(_genderService.GetAllGenders()),
                HeroImageCurrent = product.HeroImage,
                HeroTitle = product.HeroTitle,
                Brands = SelectListItemHelper.BuildDropDownList(_brandService.GetAllBrands()),
                Price = product.Price.ToString(),
                Sizes = mapper.Map<List<ProductSizeDTO>, List<ProductSizeViewModel>>(product.Sizes)
            };

            //TODO: Refactor this - Helper
            foreach (var gender in editProductViewModel.Genders)
            {
                if (gender.Text == product.Gender)
                {
                    gender.Selected = true;
                }
            }

            var listProductTypes = _productTypeService.GetAllProductTypes();
            foreach (var productType in listProductTypes)
            {
                editProductViewModel.ProductTypes.Add(new SelectListItem()
                {
                    Value = productType.Id.ToString(),
                    Text = productType.Value,
                    Selected = productType.Id == product.CategoryId
                });
            }
            //TODO: Refactor this - Helper
            foreach (var image in product.Images)
            {
                //TODO: Try put this in mapper
                if (image.Image.Length > 1)
                {
                    editProductViewModel.ImagesSrc.Add($"data:image/jpeg;base64,{Convert.ToBase64String(image.Image)}");
                }
            }
            //TODO: Refactor this - Helper
            var listCategories = _categoryService.GetAllCategories();
            foreach (var category in listCategories)
            {
                editProductViewModel.Categories.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Value,
                    Selected = category.Id == product.CategoryId
                }); ;
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

        //TODO: Make sure all messages have a pattern - consts?
        public BaseWebServiceResponse DeleteProduct(int productId)
        {
            var isProductDeleted = _productService.DeleteProduct(productId);
            return new BaseWebServiceResponse
            {
                ActionSuccessful = isProductDeleted,
                SuccessMessage = isProductDeleted ?
                    "Product Deleted!" :
                    string.Empty,
                Error = isProductDeleted ?
                    null :
                    new ErrorServiceViewModel
                    {
                        Name = "Product",
                        Message = "There was a problem deleting the Product. If this problem persists, please contact support."
                    }
            };
        }

        public AddProductViewModel GetAddProductsContents()
        {
            AddProductContentsDTO addProductDto = _productService.GetAddProductContents();
            var model = new AddProductViewModel();
            //TODO: Refactor this - Helper
            foreach (var brand in addProductDto.Brands)
            {
                model.Brands.Add(new SelectListItem()
                {
                    Value = brand.Id.ToString(),
                    Text = brand.BrandName
                });
            }
            //TODO: Refactor this - Helper
            foreach (var category in addProductDto.Categories)
            {
                model.Categories.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName
                });
            }
            //TODO: Refactor this - Helper
            foreach (var genders in addProductDto.Genders)
            {
                model.Genders.Add(new SelectListItem()
                {
                    Value = genders.Id.ToString(),
                    Text = genders.GenderName
                });
            }
            //TODO: Refactor this - Helper
            foreach (var productType in addProductDto.ProductTypes)
            {
                model.ProductTypes.Add(new SelectListItem()
                {
                    Value = productType.Id.ToString(),
                    Text = productType.ProductTypeName
                });
            }
            //TODO: Refactor this - Helper
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
            var addProductContents = _productService.GetAddProductContents();

            if (model == null)
            {
                return new AddProductViewModel()
                {
                    Brands = SelectListItemHelper.BuildDropDownList(addProductContents.Brands),
                    Categories = SelectListItemHelper.BuildDropDownList(addProductContents.Categories),
                    Genders = SelectListItemHelper.BuildDropDownList(addProductContents.Genders),
                    ProductTypes = SelectListItemHelper.BuildDropDownList(addProductContents.ProductTypes)
                };
            }
            //TODO: Refactor this - mapper
            model.Brands = SelectListItemHelper.BuildDropDownList(addProductContents.Brands);
            model.Categories = SelectListItemHelper.BuildDropDownList(addProductContents.Categories);
            model.Genders = SelectListItemHelper.BuildDropDownList(addProductContents.Genders);
            model.ProductTypes = SelectListItemHelper.BuildDropDownList(addProductContents.ProductTypes);

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
            
            //TODO: Refactor this - Mapper or Helper
            var productDto = mapper.Map<AddProductViewModel, ProductDTO>(model);
            productDto.Gender = _genderService.GetGenderById(Convert.ToInt32(model.SelectedGender));
            productDto.Price = price;
            productDto.HeroImage = ProductHelper.WriteImageToBytes(model.HeroImage);
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image1) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image2) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image3) });
            productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image4) });
            productDto.Sizes = JsonConvert.DeserializeObject<List<ProductSizeDTO>>(model.SizesJson);

            if (!_productService.AddProduct(productDto))
            {
                response.Error.Name = "Add Product";
                response.Error.Message = "There was a problem while attempting to add the Product, please try again. If this problem persists, please contact support.";

                return response;
            }

            response.ActionSuccessful = true;
            response.SuccessMessage = "Product added successfully!";
            return response;
        }

        public BaseWebServiceResponse UpdateProduct(EditProductViewModel model)
        {
            var response = new BaseWebServiceResponse();

            //TODO: Refactor this - Move this check to a new service => ProductValidationService?
            if (_productService.ProductNameExists(model.ProductName, model.Id))
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

            var productDto = mapper.Map<EditProductViewModel, ProductDTO>(model);

            bool fileExists = _fileValidationWebService.FileExists(listFiles);
            if (fileExists)
            {
                bool filesAreJpg = _fileValidationWebService.IsFileFormatJpg(listFiles);
                if (!filesAreJpg)
                {
                    response.Error.Name = "Images";
                    response.Error.Message = "Files must be jpg file format.";

                    return response;
                }
            }
            else 
            {
                //TODO: Refactor this => Duplicated below
                productDto.Images.Add(new ProductImageDTO() { Image = model.ImagesBytes[0] });
                productDto.Images.Add(new ProductImageDTO() { Image = model.ImagesBytes[1] });
                productDto.Images.Add(new ProductImageDTO() { Image = model.ImagesBytes[2] });
                productDto.Images.Add(new ProductImageDTO() { Image = model.ImagesBytes[3] });
            }

            //TODO: Refactor this - move Mapper or Helper
            productDto.Gender = _genderService.GetGenderById(Convert.ToInt32(model.SelectedGender));
            productDto.Price = price;

            //TODO: Refactor this - move Mapper or Helper
            if (model.HeroImage != null)
            {
                productDto.HeroImage = ProductHelper.WriteImageToBytes(model.HeroImage);
            }

            //TODO: Refactor this - move to Helper - refactor e.g. model.Image1,2,3 => .Add to list return list
            if (fileExists)
            {
                if (model.Image1 != null)
                {
                    productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image1) });
                }

                if (model.Image2 != null)
                {
                    productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image2) });
                }

                if (model.Image3 != null)
                {
                    productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image3) });
                }

                if (model.Image4 != null)
                {
                    productDto.Images.Add(new ProductImageDTO() { Image = ProductHelper.WriteImageToBytes(model.Image4) });
                }
            }
            productDto.Sizes = JsonConvert.DeserializeObject<List<ProductSizeDTO>>(model.SizesJson);

            if (!_productService.UpdateProduct(productDto))
            {
                response.Error.Name = "Add Product";
                response.Error.Message = "There was a problem while attempting to add the Product, please try again. If this problem persists, please contact support.";

                return response;
            }

            response.ActionSuccessful = true;
            response.SuccessMessage = "Product successfully updated";
            return response;
        }
    }
}