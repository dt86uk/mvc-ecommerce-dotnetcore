﻿using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public interface ITransactionService
    {
        bool ProcessPayment(PaymentDetail paymentDetails);
        TransactionDTO Create(Order order, PaymentDetail paymentDetail);
        List<TransactionItemDTO> GetAllTransactions();
        TransactionDTO GetTransactionById(int transactionId);
    }
}