using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models.Admin;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public class TransactionWebService : ITransactionWebService
    {
        private readonly ITransactionService _transactionService;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public TransactionWebService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public AdminTransactionsViewModel GetAllTransactions()
        {
            var listTransactions = mapper.Map<List<TransactionItemDTO>, List<TransactionItemViewModel>>(_transactionService.GetAllTransactions());

            return new AdminTransactionsViewModel
            {
                Transactions = listTransactions
            };
        }

        public TransactionViewModel GetTransactionById(int transactionId)
        {
            return mapper.Map<TransactionDTO, TransactionViewModel>(_transactionService.GetTransactionById(transactionId));
        }
    }
}
