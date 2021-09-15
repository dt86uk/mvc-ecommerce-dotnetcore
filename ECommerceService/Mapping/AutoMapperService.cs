using System.Linq;
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
                cfg.CreateMap<PaymentDetails, PaymentDetailDTO>().ReverseMap();
                cfg.CreateMap<OrderedProduct, OrderedProductDTO>().ReverseMap();
                cfg.CreateMap<Role, RoleDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Brand, BrandDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
                cfg.CreateMap<ProductSize, ProductSizeDTO>().ReverseMap();
                cfg.CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<DeliveryInformation, DeliveryInformationDTO>().ReverseMap();
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
                    .ForMember(src => src.AddressDetails, opt => opt.MapFrom(dest => dest.Address))
                    .ForMember(src => src.Order, opt => opt.MapFrom(dest => dest.Order))
                    .ForMember(src => src.PaymentDetails, opt => opt.MapFrom(dest => dest.PaymentDetails))
                    .ReverseMap();
                cfg.CreateMap<Transaction, TransactionItemDTO>()
                    .ReverseMap();
                cfg.CreateMap<User, NewUserDTO>()
                    .ForMember(src => src.DateRegistered, opt => opt.MapFrom(dest => dest.CreatedDate))
                    .ReverseMap();
                cfg.CreateMap<User, UserDetailsDTO>()
                    .ForMember(src => src.DateRegistered, opt => opt.MapFrom(dest => dest.CreatedDate))
                    .ReverseMap();
                cfg.CreateMap<Order, OrderInformationDTO>()
                    .ForMember(src => src.Cost, opt => opt.MapFrom(dest => dest.OrderedProducts.Sum(s => s.Price)))
                    .ReverseMap();
                cfg.CreateMap<OrderedProduct, EditOrderedProductDTO>()
                    .ForMember(src => src.PriceId, opt => opt.MapFrom(dest => dest.Id))
                    .ReverseMap();
                cfg.CreateMap<Order, EditOrderInformationDTO>()
                    .ForMember(src => src.BillingInformation, opt => opt.MapFrom(dest => dest.BillingInformation))
                    .ForPath(src => src.BillingInformation.CityTown, opt => opt.MapFrom(dest => dest.BillingInformation.CityTown))
                    .ForPath(src => src.BillingInformation.PostCode, opt => opt.MapFrom(dest => dest.BillingInformation.PostalCode))
                    .ForMember(src => src.ShippingInformation, opt => opt.MapFrom(dest => dest.ShippingInformation))
                    .ForPath(src => src.ShippingInformation.CityTown, opt => opt.MapFrom(dest => dest.ShippingInformation.CityTown))
                    .ForPath(src => src.ShippingInformation.PostCode, opt => opt.MapFrom(dest => dest.ShippingInformation.PostalCode))
                    .ForMember(src => src.OrderedProducts, opt => opt.MapFrom(dest => dest.OrderedProducts))
                    .ForMember(src => src.User, opt => opt.MapFrom(dest => dest.Customer))
                    .ForMember(src => src.OrderStatusId, opt => opt.MapFrom(dest => dest.OrderStatusId))
                    .ReverseMap();
                cfg.CreateMap<OrderStatus, OrderStatusDTO>()
                    .ForMember(src => src.OrderStatus, opt => opt.MapFrom(dest => dest.Status))
                    .ReverseMap();
            });
        }
    }
}