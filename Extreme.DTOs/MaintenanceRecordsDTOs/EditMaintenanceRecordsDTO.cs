using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceRecordsDTOs

{
    public class EditMaintenanceRecordsDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Maintenance_Id")]
        [Required(ErrorMessage = "El campo Maintenance_Id es obligatorio.")]
        public int Maintenance_Id { get; set; }

        [Display(Name = "Task_Name")]
        [Required(ErrorMessage = "El campo Task_Name es obligatorio.")]
        public string Task_Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "El campo Description es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "El campo Status es obligatorio.")]
        public string Status { get; set; }

        [Display(Name = "Completed_At")]
        [Required(ErrorMessage = "El campo Completed_At es obligatorio.")]
        public DateTime Completed_At { get; set; }

    }
}
