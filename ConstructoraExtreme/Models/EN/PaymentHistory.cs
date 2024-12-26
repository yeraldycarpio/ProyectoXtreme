using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public int Rental_Payment_Id { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Type { get; set; }
        public string Payment_Method { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Note { get; set; }
        public DateTime Created_At { get; set; }

        [ForeignKey("Rental_Payment_Id")]
        public RentalPayments RentalPayments { get; set; }

    }
}
