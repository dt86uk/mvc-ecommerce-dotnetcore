using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ITransactionService
    {
        bool ProcessPayment(PaymentDetail paymentDetails);
        TransactionDTO CreateTransaction(Order order, PaymentDetail paymentDetail);
    }
}