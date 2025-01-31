using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenancePartsDTOs

{
    public class EditMaintenancePartsDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Rental_Id")]
        [Required(ErrorMessage = "El campo Rental_Id es obligatorio.")]
        public int Rental_Id { get; set; }

        [Display(Name = "Maintenance_Record_Id ")]
        [Required(ErrorMessage = "El campo Maintenance_Record_Id  es obligatorio.")]
        public int Maintenance_Record_Id { get; set; }

        [Display(Name = "Part_Name")]
        [Required(ErrorMessage = "El campo Part_Name es obligatorio.")]
        public string Part_Name { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "El campo Quantity es obligatorio.")]
        public int Quantity { get; set; }

        [Display(Name = "Unit_Cost")]
        [Required(ErrorMessage = "El campo Unit_Cost es obligatorio.")]
        public decimal Unit_Cost { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "El campo Supplier es obligatorio.")]
        public string Supplier { get; set; }

    }
}
