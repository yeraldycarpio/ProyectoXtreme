using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalPaymentsDTOs

{
    public class CreateRentalPaymentsDTO
    {

        [Display(Name = "Rental_Id")]
        [Required(ErrorMessage = "Rental_ID es requerida")]
        public int Rental_Id { get; set; }

        [Display(Name = "Total_Amount")]
        [Required(ErrorMessage = "The Total_Amount is required.")]
        public decimal Total_Amount { get; set; }

        [Display(Name = "Pending_Amount")]
        [Required(ErrorMessage = "The Pending_Amount is required.")]
        public decimal Pending_Amount { get; set; }

        [Display(Name = "Advance_Payment")]
        [Required(ErrorMessage = "The Advance_Payment is required.")]
        public decimal Advance_Payment { get; set; }

        [Display(Name = "Payment_Status")]
        [Required(ErrorMessage = "The Payment_Status is required.")]
        public string Payment_Status { get; set; }

        [Display(Name = "Due_Date")]
        [Required(ErrorMessage = "The Due_Date is required.")]
        public DateTime Due_Date { get; set; }

    }

}
