using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenancePartsDTOs

{
    public class CreateMaintenancePartsDTO
    {

        [Display(Name = "Maintenance_Record_Id")]
        [Required(ErrorMessage = "Maintenance_Record_Id")]
        public int Maintenance_Record_Id { get; set; }

        [Display(Name = "Part_Name")]
        [Required(ErrorMessage = "The Part_Name is required.")]
        public string Part_Name { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "The Quantity is required.")]
        public int Quantity { get; set; }

        [Display(Name = "Unit_Cost ")]
        [Required(ErrorMessage = "The Unit_Cost  is required.")]
        public decimal Unit_Cost { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "The Supplier is required.")]
        public string Supplier { get; set; }

    }

}
