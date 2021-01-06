using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDatabase.Database.Entities
{
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string CCV { get; set; }        
    }
}