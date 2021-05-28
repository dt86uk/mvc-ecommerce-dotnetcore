using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// CRUD operations for Orders to the Repository and returns the Data Transfer Object (DTO) for Orders and Transactions
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IStockService _stockService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public OrderService(ITransactionService transactionService, IStockService stockService)
        {
            _stockService = stockService;
            _transactionService = transactionService;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public OrderDTO PlaceOrder(OrderDTO newOrder)
        {
            var dbOrder = mapper.Map<OrderDTO, Order>(newOrder);
            var paymentDetails = mapper.Map<PaymentDetailDTO, PaymentDetail>(newOrder.PaymentDetails);

            //check we have stock to fulfill order
            foreach (var product in newOrder.OrderedProducts)
            {
                var result = _stockService.IsStockAvailable(product.Id, product.SizeId);
                if (!result)
                {
                    newOrder.PaymentProcessed = false;
                    return newOrder;
                }
            }

            if (!_transactionService.ProcessPayment(paymentDetails))
            {
                newOrder.PaymentProcessed = false;
                return newOrder;
            }

            dbOrder.PaymentReceived = true;
            var transaction = _transactionService.Create(dbOrder, paymentDetails);
            return transaction.Order;
        }
    }
}