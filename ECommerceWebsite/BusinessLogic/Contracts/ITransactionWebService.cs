using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public interface ITransactionWebService
    {
        AdminTransactionsViewModel GetAllTransactions();
        TransactionViewModel GetTransactionById(int transactionId);
        AdminFinancialsViewModel GetFinancialsByCurrentMonth();
    }
}