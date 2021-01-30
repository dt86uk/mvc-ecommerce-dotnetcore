using AutoMapper;
using ECommerceService.Models;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;
using System;

namespace ECommerceWebsite.Mapping
{
    public class AutoMapperWeb
    {
        public MapperConfiguration Configuration;
        public AutoMapperWeb()
        {
            Configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountViewModel, UserDTO>()
                    .ForMember(src => src.FirstName, opt => opt.MapFrom(dest => dest.FirstName))
                    .ForMember(src => src.LastName, opt => opt.MapFrom(dest => dest.LastName))
                    .ForMember(src => src.Email, opt => opt.MapFrom(dest => dest.Email))
                    .ForMember(src => src.DateOfBirth, opt => opt.MapFrom(dest =>
                        new DateTime(
                            Convert.ToInt32(dest.DateOfBirthYear),
                            Convert.ToInt32(dest.DateOfBirthMonth),
                            Convert.ToInt32(dest.DateOfBirthDay))))
                    .ForMember(src => src.IsSubscribed, opt => opt.MapFrom(dest => dest.IsSubscribed))
                    .ForMember(src => src.Password, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<UserViewModel, UserDTO>().ReverseMap();
                cfg.CreateMap<ProductItemViewModel, CartSummaryItemViewModel>().ReverseMap();
                cfg.CreateMap<CartViewModel, CartSummaryViewModel>().ReverseMap();
                cfg.CreateMap<CarouselItemViewModel, ProductImageDTO>().ReverseMap();
                cfg.CreateMap<CarouselItemViewModel, ProductDTO>().ReverseMap();
                cfg.CreateMap<MenuItemViewModel, CategoryDTO>().ReverseMap();
                cfg.CreateMap<CheckoutViewModel, PaymentDetailDTO>().ReverseMap();
                cfg.CreateMap<CheckoutViewModel, CartViewModel>().ReverseMap();
                cfg.CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
                cfg.CreateMap<BrandViewModel, BrandDTO>().ReverseMap();               
                cfg.CreateMap<ProductTypeViewModel, ProductTypeDTO>().ReverseMap();
                cfg.CreateMap<AddToCartViewModel, ProductTypeDTO>().ReverseMap();
                cfg.CreateMap<ProductImageViewModel, ProductImageDTO>().ReverseMap();
                cfg.CreateMap<ProductSizeViewModel, ProductSizeDTO>().ReverseMap();
                cfg.CreateMap<CategoryItemViewModel, CategoryDTO>().ReverseMap();
                cfg.CreateMap<CategoryProductItemViewMoel, ProductDTO>().ReverseMap()
                    .ForMember(src => src.ImageSrc, opt => opt.MapFrom(dest => $"data:image/jpeg;base64,{Convert.ToBase64String(dest.Images[0].Image)}" ));
                
                //Admin
                cfg.CreateMap<LatestTransactionsDTO, LatestTransactionsViewModel>().ReverseMap();
                cfg.CreateMap<LatestTransactionsDTO, LatestTransactionsViewModel>().ReverseMap();
                cfg.CreateMap<FinancialInformationDTO, FinancialInformationViewModel>().ReverseMap();  
                cfg.CreateMap<ProductStockDTO, ProductStockViewModel>().ReverseMap();
                cfg.CreateMap<NewUserDTO, NewUserViewModel>().ReverseMap();
                cfg.CreateMap<ProductsViewModel, ProductDTO>()
                    .ForPath(src => src.Brand.BrandName, opt => opt.MapFrom(dest => dest.Brand))
                    .ForPath(src => src.ProductType.ProductTypeName, opt => opt.MapFrom(dest => dest.ProductType))
                .ReverseMap();
                cfg.CreateMap<UserDetailsDTO, UsersViewModel>().ReverseMap();
                cfg.CreateMap<AddProductViewModel, ProductDTO>()
                    .ForMember(src => src.BrandId, opt => opt.MapFrom(dest => Convert.ToInt32(dest.SelectedBrand)))
                    .ForMember(src => src.CategoryId, opt => opt.MapFrom(dest => Convert.ToInt32(dest.SelectedCategory)))
                    .ForMember(src => src.ProductTypeId, opt => opt.MapFrom(dest => Convert.ToInt32(dest.SelectedProductType)))
                    .ForMember(src => src.Brand, opt => opt.Ignore())
                    .ForMember(src => src.Category, opt => opt.Ignore())
                    .ForMember(src => src.ProductType, opt => opt.Ignore())
                    .ForMember(src => src.Gender, opt => opt.Ignore())
                    .ForMember(src => src.Images, opt => opt.Ignore())
                    .ForMember(src => src.HeroImage, opt => opt.Ignore())
                    .ForMember(src => src.Price, opt => opt.Ignore())
                    .ForMember(src => src.Sizes, opt => opt.Ignore())
                    .ForMember(src => src.Url, opt => opt.Ignore())
                    .ReverseMap();
            });
        }
    }
}