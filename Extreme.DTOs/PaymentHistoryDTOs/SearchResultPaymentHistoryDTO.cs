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
            [Display(Name = "Rental_Payment_Id")]
            public int? Rental_Payment_Id { get; set; }

            [Display(Name = "Amount")]
            public decimal? Amount { get; set; }

            [Display(Name = "Payment_Type")]
            public string Payment_Type { get; set; }

            [Display(Name = "Payment_Method")]
            public string Payment_Method { get; set; }

            [Display(Name = "Payment_Date")]
            public DateTime? Payment_Date { get; set; }

            [Display(Name = "Note")]
            public string Note { get; set; }
        }
    }

}
