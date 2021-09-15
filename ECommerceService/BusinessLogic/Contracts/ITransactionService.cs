using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ITransactionService
    {
        bool ProcessPayment(PaymentDetails paymentDetails);
        TransactionDTO Create(Order order, PaymentDetails paymentDetail);
        List<TransactionItemDTO> GetAllTransactions();
        TransactionDTO GetTransactionById(int transactionId);
    }
}