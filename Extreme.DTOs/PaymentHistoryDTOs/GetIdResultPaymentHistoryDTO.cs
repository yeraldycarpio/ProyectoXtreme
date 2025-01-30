using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PaymentHistoryDTOs
{
    public class GetIdResultPaymentHistoryDTO
    {
        public int Id { get; set; }
        public int Rental_Payment_Id { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Type { get; set; }
        public string Payment_Method { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Note { get; set; }
        public DateTime Created_At { get; set; }
    }

}
