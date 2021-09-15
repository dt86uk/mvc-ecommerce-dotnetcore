using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;

namespace ECommerceRepository.BusinessLogic
{
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// Creates a Transaction for the new order to be placed which it resides in.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Transaction Create(Transaction transaction)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var createdTransaction = context.Transactions.Add(transaction).Entity;
                context.Entry(createdTransaction).State = EntityState.Added;
                context.SaveChanges();

                return context.Transactions
                    .Include(p => p.Address)
                    .Include(p => p.Order)
                    .Include(p => p.PaymentDetails)
                    .Single(p => p.Id == createdTransaction.Id);
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Transactions
                    .Include(p => p.Address)
                    .Include(p => p.Order)
                    .Include(p => p.PaymentDetails)
                    .ToList();
            }
        }

        public List<Transaction> GetDailyTakings(int numberOfDays)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Transactions
                    .Include(t => t.Order)
                    .ThenInclude(o => o.OrderedProducts)
                    .Where(p => p.CreatedDate > DateTime.Now.AddDays(-numberOfDays) && p.CreatedDate <= DateTime.Now)
                    .Take(5).ToList();
            }
        }

        public List<Transaction> GetLatestTransactions()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var startDate = DateTime.Today.AddDays(-8);
                var endDate = DateTime.Today;

                return context.Transactions
                    .Include(t => t.Order)
                    .ThenInclude(o => o.OrderedProducts)
                    .Include(t => t.Order)
                    .ThenInclude(o => o.BillingInformation)
                    .Where(p => p.CreatedDate > DateTime.Now.AddDays(-5) && p.CreatedDate <= DateTime.Now)
                    .ToList();
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Transactions
                    .Include(p => p.Address)
                    .Include(p => p.Order)
                    .SingleOrDefault(p => p.Id == transactionId);
            }
        }
    }
}