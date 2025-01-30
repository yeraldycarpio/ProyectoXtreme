using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PaymentHistoryDTOs

{
    public class CreatePaymentHistoryDTO
    {

        [Display(Name = "Rental_Payment_Id")]
        [Required(ErrorMessage = "Rental_Payment_Id es requerida")]
        public int Rental_Payment_Id { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "The Amount is required.")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment_Type")]
        [Required(ErrorMessage = "The Payment_Type is required.")]
        public string Payment_Type { get; set; }

        [Display(Name = "Payment_Method")]
        [Required(ErrorMessage = "The Payment_Method is required.")]
        public string Payment_Method { get; set; }

        [Display(Name = "Payment_Date")]
        [Required(ErrorMessage = "The Payment_Date is required.")]
        public DateTime Payment_Date { get; set; }

        [Display(Name = "Note")]
        [Required(ErrorMessage = "The Note is required.")]
        public string Note { get; set; }

    }

}
