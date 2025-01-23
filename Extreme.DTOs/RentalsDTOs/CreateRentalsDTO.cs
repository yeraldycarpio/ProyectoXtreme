using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalsDTOs

{
    public class CreateRentalsDTO
    {

        [Display(Name = "Store_Id")]
        [Required(ErrorMessage = "La tienda es requerida")]
        public int Store_Id { get; set; }

        [Display(Name = "Person_Id")]
        [Required(ErrorMessage = "La Persona es requerida")]
        public int Person_Id { get; set; }

        [Display(Name = "Total_Amount")]
        [Required(ErrorMessage = "The Total_Amount is required.")]
        public decimal Total_Amount { get; set; }

        [Display(Name = "Start_Date")]
        [Required(ErrorMessage = "The Start_Date is required.")]
        public DateTime Start_Date { get; set; }

        [Display(Name = "End_Date")]
        [Required(ErrorMessage = "The End_Date is required.")]
        public DateTime End_Date { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "The Status is required.")]
        public string Status { get; set; }
    }

}
