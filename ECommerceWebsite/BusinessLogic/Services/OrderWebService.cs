using System;
using System.Linq;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public class OrderWebService : IOrderWebService
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public OrderWebService(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public OrderSuccessfulViewModel PlaceOrder(CheckoutViewModel model)
        {
            //cast to send type
            //customer to do here
            var newOrder = mapper.Map<CheckoutViewModel, OrderDTO>(model);
            var newOrderDTO = new OrderDTO()
            {
                OrderStatus = "Ongoing",
                PaymentDetails = new PaymentDetailDTO()
                {
                    NameOnCard = model.NameOnCard,
                    CardNumber = model.CardNumber,
                    CardType = "n/a", //implement this type to front-end e.g. MasterCard, Visa, Visa Debit
                    CCV = model.CCV,
                    ExpiryDateMonth = model.ExpiryDateMonth,
                    ExpiryDateYear = model.ExpiryDateYear
                }
            };

            foreach (var product in model.Cart.Products)
            {
                var productEntity = _productService.GetProductById(product.ProductId);
                newOrder.OrderedProducts.Add(new OrderedProductDTO()
                {
                    Price = product.Price,
                    ProductId = product.ProductId,
                    SizeId = productEntity.Sizes.Single(p => 
                        string.Equals(p.Size, product.Size, StringComparison.InvariantCultureIgnoreCase)).Id
                });
            }

            var placedOrder = _orderService.PlaceOrder(newOrder);

            return new OrderSuccessfulViewModel()
            {
                Id = placedOrder.Id,
                OrderStatus = placedOrder.OrderStatus,
                ArrivalDate = placedOrder.ArrivalDate,
                Customer = new UserViewModel()
                {
                    Id = newOrder.Customer.Id,
                    Email = newOrder.Customer.Email,
                    FirstName = newOrder.Customer.FirstName,
                    LastName = newOrder.Customer.LastName
                },
                ReferenceNumber = placedOrder.ReferenceNumber
            };
        }
    }
}