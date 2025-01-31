using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTypesDTOs

{
    public class EditMaintenanceTypesDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "El campo Description es obligatorio.")]
        public string Description { get; set; }

    }
}
