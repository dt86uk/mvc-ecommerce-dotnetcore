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
            var listTransactionsDto = _transactionService.GetAllTransactions();
            var listTransactions = mapper.Map<List<TransactionItemDTO>, List<TransactionItemViewModel>>(listTransactionsDto);

            return new AdminTransactionsViewModel
            {
                Transactions = listTransactions
            };
        }

        public AdminFinancialsViewModel GetFinancialsByCurrentMonth()
        {
            var listFinancialsThisMonthDto = _transactionService.GetFinancialsByCurrentMonth();
            var listFinancialsThisMonth = mapper.Map<List<FinancialDetailsDTO>, List<AdminFinancialsDetailsItemViewModel>>(listFinancialsThisMonthDto);

            return new AdminFinancialsViewModel
            {
                DailyTakings = listFinancialsThisMonth
            };
        }

        public TransactionViewModel GetTransactionById(int transactionId)
        {
            var transaction = _transactionService.GetTransactionById(transactionId);
            return mapper.Map<TransactionDTO, TransactionViewModel>(transaction);
        }
    }
}
