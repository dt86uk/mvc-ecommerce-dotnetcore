using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;
using System.Threading;

namespace ECommerceService.BusinessLogic
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public TransactionDTO Create(Order order, PaymentDetails paymentDetail)
        {
            var address = mapper.Map<DeliveryInformation, Address>(order.ShippingInformation);
            var transaction = new Transaction()
            {
                Order = order,
                PaymentDetails = paymentDetail,
                Address = address
            };

            var newTransaction = _transactionRepository.Create(transaction);

            return mapper.Map<Transaction, TransactionDTO>(newTransaction);
        }

        public List<TransactionItemDTO> GetAllTransactions()
        {
            var listTransactons = _transactionRepository.GetAllTransactions();
            return mapper.Map<List<Transaction>, List<TransactionItemDTO>>(listTransactons);
        }

        public TransactionDTO GetTransactionById(int transactionId)
        {
            var transaction = _transactionRepository.GetTransactionById(transactionId);
            return mapper.Map<Transaction, TransactionDTO>(transaction);
        }

        public bool ProcessPayment(PaymentDetails paymentDetails)
        {
            //a small delay to simulate card charge occured
            Thread.Sleep(3000);
            return true;
        }
    }
}