﻿using AutoMapper;
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
                cfg.CreateMap<EditUserViewModel, UserDTO>()
                    .ForMember(src => src.DateOfBirth, opt => opt.MapFrom(dest =>
                            new DateTime(
                                Convert.ToInt32(dest.DateOfBirthYear),
                                Convert.ToInt32(dest.DateOfBirthMonth),
                                Convert.ToInt32(dest.DateOfBirthDay))))
                    .ForMember(src => src.Password, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<AccountViewModel, UserDTO>()
                    .ForMember(src => src.DateOfBirth, opt => opt.MapFrom(dest =>
                        new DateTime(
                            Convert.ToInt32(dest.DateOfBirthYear),
                            Convert.ToInt32(dest.DateOfBirthMonth),
                            Convert.ToInt32(dest.DateOfBirthDay))))
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
                cfg.CreateMap<EditProductViewModel, ProductDTO>()
                    .ForMember(src => src.BrandId, opt => opt.MapFrom(src => Convert.ToInt32(src.SelectedBrand)))
                    .ForMember(src => src.CategoryId, opt => opt.MapFrom(src => Convert.ToInt32(src.SelectedCategory)))
                    .ForMember(src => src.ProductTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.SelectedProductType)))
                    .ForMember(src => src.ProductTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.SelectedProductType)))
                    .ReverseMap();
                cfg.CreateMap<AddBrandViewModel, BrandDTO>().ReverseMap();
                cfg.CreateMap<EditBrandViewModel, BrandDTO>().ReverseMap();
                cfg.CreateMap<EditCategoryViewModel, CategoryDTO>().ReverseMap();
                cfg.CreateMap<AddCategoryViewModel, CategoryDTO>().ReverseMap();
                cfg.CreateMap<RoleDTO, RoleViewModel>().ReverseMap();
                cfg.CreateMap<RoleDTO, EditRoleViewModel>().ReverseMap();
                cfg.CreateMap<RoleDTO, AddRoleViewModel>().ReverseMap();
                cfg.CreateMap<OrderInformationDTO, OrderInformationViewModel>().ReverseMap();
                cfg.CreateMap<EditOrderedProductDTO, OrderedProductViewModel>().ReverseMap();
                cfg.CreateMap<DeliveryInformationDTO, DeliveryInformationViewModel>().ReverseMap();
                cfg.CreateMap<AddressDTO, DeliveryInformationViewModel>().ReverseMap();
                cfg.CreateMap<EditOrderInformationDTO, EditOrderInformationViewModel>()
                    .ForMember(src => src.BillingInformation, opt => opt.MapFrom(src => src.BillingInformation))
                    .ForPath(src => src.BillingInformation.CityTown, opt => opt.MapFrom(src => src.BillingInformation.CityTown))
                    .ForPath(src => src.BillingInformation.PostCode, opt => opt.MapFrom(src => src.BillingInformation.PostCode))
                    .ForMember(src => src.ShippingInformation, opt => opt.MapFrom(src => src.ShippingInformation))
                    .ForPath(src => src.ShippingInformation.CityTown, opt => opt.MapFrom(src => src.ShippingInformation.CityTown))
                    .ForPath(src => src.ShippingInformation.PostCode, opt => opt.MapFrom(src => src.ShippingInformation.PostCode))
                    .ForMember(src => src.OrderedProducts, opt => opt.MapFrom(src => src.OrderedProducts))
                    .ForMember(src => src.OrderStatusId, opt => opt.MapFrom(src => src.OrderStatusId))
                    .ReverseMap();
                cfg.CreateMap<TransactionItemViewModel, TransactionItemDTO>().ReverseMap();
                cfg.CreateMap<TransactionDTO, TransactionViewModel>()
                    .ForMember(src => src.TotalPrice, opt => opt.MapFrom(dest => dest.TotalPrice))
                    .ForMember(src => src.AddressDetails, opt => opt.MapFrom(dest => dest.AddressDetails))
                    .ForMember(src => src.Order, opt => opt.MapFrom(dest => dest.Order))
                    .ForPath(src => src.Order.Customer.FirstName, opt => opt.MapFrom(dest => dest.Order.Customer.FirstName))
                    .ForPath(src => src.Order.Customer.LastName, opt => opt.MapFrom(dest => dest.Order.Customer.LastName))
                    .ForPath(src => src.Order.Customer.Email, opt => opt.MapFrom(dest => dest.Order.Customer.Email))
                    .ForPath(src => src.Order.Customer.DateOfBirth, opt => opt.MapFrom(dest => dest.Order.Customer.DateOfBirth))
                    .ForPath(src => src.Order.ReferenceNumber, opt => opt.MapFrom(dest => dest.Order.ReferenceNumber))
                    .ForPath(src => src.Order.OrderStatus, opt => opt.MapFrom(dest => dest.Order.OrderStatus))
                    .ForPath(src => src.AddressDetails.Address1, opt => opt.MapFrom(dest => dest.AddressDetails.Address1))
                    .ForPath(src => src.AddressDetails.Address2, opt => opt.MapFrom(dest => dest.AddressDetails.Address2))
                    .ForPath(src => src.AddressDetails.CityTown, opt => opt.MapFrom(dest => dest.AddressDetails.CityTown))
                    .ForPath(src => src.AddressDetails.Country, opt => opt.MapFrom(dest => dest.AddressDetails.Country))
                    .ForPath(src => src.AddressDetails.PostCode, opt => opt.MapFrom(dest => dest.AddressDetails.PostCode))
                    .ReverseMap();
                cfg.CreateMap<OrderedProductDTO, ProductViewModel>()
                    .ForMember(src => src.Price, opt => opt.MapFrom(dest => dest.Price))
                    .ReverseMap();
                cfg.CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            });
        }
    }
}