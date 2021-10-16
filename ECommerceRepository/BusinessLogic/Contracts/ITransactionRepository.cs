using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.Models;

namespace ECommerceRepository.BusinessLogic
{
    /// <summary>
    /// Creates and queries the database for Transactions, Orders and Financials
    /// </summary>
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        List<Transaction> GetLatestTransactions();
        List<Transaction> GetDailyTakings(int numberOfDays);
        List<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionId);
        List<TransactionDetails> GetFinancialDetailsByCurrentMonth();
    }
}