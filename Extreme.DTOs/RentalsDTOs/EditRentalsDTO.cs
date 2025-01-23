using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalsDTOs
{
    public class EditRentalsDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Store_Id")]
        [Required(ErrorMessage = "El campo Store_Id es obligatorio.")]
        public int Store_Id { get; set; }

        [Display(Name = "Person_Id")]
        [Required(ErrorMessage = "El campo Person_Id es obligatorio.")]
        public int Person_Id { get; set; }

        [Display(Name = "Total_Amount")]
        [Required(ErrorMessage = "El campo Total_Amount es obligatorio.")]
        public decimal Total_Amount { get; set; }

        [Display(Name = "Start_Date")]
        [Required(ErrorMessage = "El campo Start_Date es obligatorio.")]
        public DateTime Start_Date { get; set; }

        [Display(Name = "End_Date")]
        [Required(ErrorMessage = "El campo End_Date es obligatorio.")]
        public DateTime End_Date { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "El campo estatus es obligatorio.")]
        public string Status { get; set; }

        [Display(Name = "Updated_At")]
        [Required(ErrorMessage = "El campo estatus es obligatorio.")]
        public DateTime Updated_At { get; set; }

    }
}
