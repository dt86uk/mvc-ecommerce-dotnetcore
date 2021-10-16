using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.Models;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;
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

        public List<FinancialDetailsDTO> GetFinancialsByCurrentMonth()
        {
            var listFinancialDetailsDto = _transactionRepository.GetFinancialDetailsByCurrentMonth();
            return mapper.Map<List<TransactionDetails>, List<FinancialDetailsDTO>>(listFinancialDetailsDto);
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