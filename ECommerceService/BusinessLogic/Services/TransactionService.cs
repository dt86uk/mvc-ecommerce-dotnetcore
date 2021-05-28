using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Threading;

namespace ECommerceService.BusinessLogic
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public TransactionDTO Create(Order order, PaymentDetail paymentDetail)
        {
            var address = mapper.Map<DeliveryInformation, Address>(order.ShippingInformation);
            var transaction = new Transaction()
            {
                Order = order,
                PaymentDetails = paymentDetail,
                AddressDetails = address
            };

            var newTransaction = _transactionRepository.Create(transaction);

            return mapper.Map<Transaction, TransactionDTO>(newTransaction);
        }

        public bool ProcessPayment(PaymentDetail paymentDetails)
        {
            //charge card here
            Thread.Sleep(3000);
            return true;
        }
    }
}