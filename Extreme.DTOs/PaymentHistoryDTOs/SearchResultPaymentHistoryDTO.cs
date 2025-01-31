using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PaymentHistoryDTOs
{
    public class SearchResultPaymentHistoryDTO
    {
        public int CountRow { get; set; }

        public List<PaymentHistoryDTO> Data { get; set; } = new();

        public class PaymentHistoryDTO
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

}
