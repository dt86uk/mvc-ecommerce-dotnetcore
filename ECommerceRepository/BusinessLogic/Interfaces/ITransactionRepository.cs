using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    /// <summary>
    /// Creates and queries the database for Transactions and returns the Entity Framework models for Transactions
    /// </summary>
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        List<Transaction> GetLatestTransactions();
        List<Transaction> GetDailyTakings(int numberOfDays);
    }
}
