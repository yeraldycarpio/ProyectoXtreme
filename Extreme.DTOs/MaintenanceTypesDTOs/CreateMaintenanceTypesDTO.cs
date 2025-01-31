using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTypesDTOs

{
    public class CreateMaintenanceTypesDTO
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name es requerida")]
        public string Name { get; set; }

        [Display(Name = "Description ")]
        [Required(ErrorMessage = "Description  is required.")]
        public string Description { get; set; }

    }

}
