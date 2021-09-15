using System.Linq;
using System.Collections.Generic;
using ECommerceService.Models;
using ECommerceRepository.BusinessLogic;

namespace ECommerceService.BusinessLogic
{
    public class SalesService : ISalesService
    {
        private readonly ITransactionRepository _transactionRepository;

        public SalesService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<FinancialInformationDTO> GetDailyTakings(int numberOfDays)
        {
            var listTransactions = _transactionRepository.GetDailyTakings(numberOfDays);
            var listFinancialInformationDto = new List<FinancialInformationDTO>();

            foreach (var transaction in listTransactions)
            {
                var dailyTakings = listFinancialInformationDto.SingleOrDefault(p => p.Date == transaction.CreatedDate);

                if (dailyTakings == null)
                {
                    var financialInfo = new FinancialInformationDTO()
                    {
                        Id = transaction.Id,
                        Date = transaction.CreatedDate,
                        TotalTakings = transaction.TotalPrice
                    };

                    listFinancialInformationDto.Add(financialInfo);
                }
                else 
                {
                    dailyTakings.TotalTakings += transaction.TotalPrice;
                    
                    //TODO: Test if this is needed
                    //listFinancialInformationDto.Remove(dailyTakings);
                    //listFinancialInformationDto.Add(dailyTakings);
                }
            }

            return listFinancialInformationDto;
        }

        public List<LatestTransactionsDTO> GetLatestTransactions()
        {
            var listTransactions = _transactionRepository.GetLatestTransactions();
            var listLatestTransactionsDto = new List<LatestTransactionsDTO>();

            foreach (var transaction in listTransactions)
            {
                var latestTransaction = new LatestTransactionsDTO()
                {
                    Id = transaction.Id,
                    DateCreated = transaction.CreatedDate,
                    FirstName = transaction.Order.BillingInformation.FirstName,
                    LastName = transaction.Order.BillingInformation.LastName,
                    TotalCost = transaction.TotalPrice
                };

                listLatestTransactionsDto.Add(latestTransaction);
            }

            return listLatestTransactionsDto;
        }
    }
}