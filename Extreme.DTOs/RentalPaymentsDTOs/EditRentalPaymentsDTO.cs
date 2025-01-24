using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalPaymentsDTOs

{
    public class EditRentalPaymentsDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Rental_Id")]
        [Required(ErrorMessage = "El campo Rental_Id es obligatorio.")]
        public int Rental_Id { get; set; }

        [Display(Name = "Total_Amount")]
        [Required(ErrorMessage = "El campo Total_Amount es obligatorio.")]
        public decimal Total_Amount { get; set; }

        [Display(Name = "Pending_Amount")]
        [Required(ErrorMessage = "El campo Pending_Amount es obligatorio.")]
        public decimal Pending_Amount { get; set; }

        [Display(Name = "Advance_Payment")]
        [Required(ErrorMessage = "El campo Advance_Payment es obligatorio.")]
        public decimal Advance_Payment { get; set; }

        [Display(Name = "Payment_Status")]
        [Required(ErrorMessage = "El campo Payment_Status es obligatorio.")]
        public string Payment_Status { get; set; }

        [Display(Name = "Due_Date")]
        [Required(ErrorMessage = "El campo Due_Date es obligatorio.")]
        public DateTime Due_Date { get; set; }

        [Display(Name = "Updated_At")]
        [Required(ErrorMessage = "El campo Updated_At es obligatorio.")]
        public DateTime Update_At { get; set; }

    }
}
