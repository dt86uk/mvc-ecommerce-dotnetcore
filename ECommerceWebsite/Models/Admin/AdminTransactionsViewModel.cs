using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminTransactionsViewModel : AdminBaseViewModel
    {
        public List<TransactionItemViewModel> Transactions { get; set; }
    }
}