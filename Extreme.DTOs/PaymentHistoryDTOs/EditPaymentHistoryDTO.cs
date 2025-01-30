using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PaymentHistoryDTOs

{
    public class EditPaymentHistoryDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Rental_Payment_Id")]
        [Required(ErrorMessage = "El campo Rental_Payment_Id es obligatorio.")]
        public int Rental_Payment_Id { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "El campo Amount es obligatorio.")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment_Type")]
        [Required(ErrorMessage = "El campo Payment_Type es obligatorio.")]
        public string Payment_Type { get; set; }

        [Display(Name = "Payment_Method")]
        [Required(ErrorMessage = "El campo Payment_Method es obligatorio.")]
        public string Payment_Method { get; set; }

        [Display(Name = "Payment_Date")]
        [Required(ErrorMessage = "El campo Payment_Date es obligatorio.")]
        public DateTime Payment_Date { get; set; }

        [Display(Name = "Note")]
        [Required(ErrorMessage = "El campo Note es obligatorio.")]
        public string Note { get; set; }

    }
}
