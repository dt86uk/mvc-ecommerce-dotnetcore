using System;
using System.Collections.Generic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ISalesService
    {
        List<LatestTransactionsDTO> GetLatestTransactions();
        List<FinancialInformationDTO> GetDailyTakings(int numberOfDays);
    }
}