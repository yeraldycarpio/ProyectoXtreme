using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTasksDTOs

{
    public class CreateMaintenanceTasksDTO
    {

        [Display(Name = "Maintenance_Id")]
        [Required(ErrorMessage = "Maintenance_Id es requerida")]
        public int Maintenance_Id { get; set; }

        [Display(Name = "Task_Name")]
        [Required(ErrorMessage = "The Task_Name is required.")]
        public string Task_Name { get; set; }

        [Display(Name = "Description ")]
        [Required(ErrorMessage = "The Description is required.")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "The Status is required.")]
        public string Status { get; set; }

    }

}
