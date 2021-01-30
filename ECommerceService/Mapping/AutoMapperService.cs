using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace ECommerceService.Mapping
{
    public class AutoMapperService
    {
        public MapperConfiguration Configuration;
        public AutoMapperService()
        {
            Configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Address, AddressDTO>().ReverseMap();
                cfg.CreateMap<PaymentDetail, PaymentDetailDTO>().ReverseMap();
                cfg.CreateMap<OrderedProduct, OrderedProductDTO>().ReverseMap();
                cfg.CreateMap<Role, RoleDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Brand, BrandDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
                cfg.CreateMap<ProductSize, ProductSizeDTO>().ReverseMap();
                cfg.CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>()
                    //.ForMember(src => src.Category, opt => opt.Ignore())
                    //.ForMember(src => src.Brand, opt => opt.Ignore())
                    //.ForMember(src => src.ProductType, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<DeliveryInformation, DeliveryInformationDTO>()
                    .ReverseMap();
                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(src => src.Customer, opt => opt.MapFrom(dest => dest.Customer))
                    .ForMember(src => src.OrderedProducts, opt => opt.MapFrom(dest => dest.OrderedProducts))
                    .ForMember(src => src.PaymentProcessed, opt => opt.Ignore())
                    .ForMember(src => src.PaymentDetails, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<OrderDTO, Order>()
                    .ForMember(src => src.Customer, opt => opt.MapFrom(dest => dest.Customer))
                    .ForMember(src => src.OrderedProducts, opt => opt.MapFrom(dest => dest.OrderedProducts))
                    .ForMember(src => src.ShippingInformation, opt => opt.Ignore())
                    .ForMember(src => src.BillingInformation, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<Transaction, TransactionDTO>()
                    .ForMember(src => src.AddressDetails, opt => opt.MapFrom(dest => dest.AddressDetails))
                    .ForMember(src => src.Order, opt => opt.MapFrom(dest => dest.Order))
                    .ForMember(src => src.PaymentDetails, opt => opt.MapFrom(dest => dest.PaymentDetails))
                    .ReverseMap();
                cfg.CreateMap<User, NewUserDTO>()
                    .ForMember(src => src.DateRegistered, opt => opt.MapFrom(dest => dest.CreatedDate))
                    .ReverseMap();
                cfg.CreateMap<User, UserDetailsDTO>()
                    .ForMember(src => src.DateRegistered, opt => opt.MapFrom(dest => dest.CreatedDate))
                    .ReverseMap();
            });
        }
    }
}