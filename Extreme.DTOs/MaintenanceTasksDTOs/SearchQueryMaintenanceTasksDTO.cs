using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTasksDTOs
{
    public class SearchQueryMaintenanceTasksDTO
    {
        [Display(Name = "Maintenance_Id ")]
        public int? Maintenance_Id { get; set; }

        [Display(Name = "Task_Name")]
        public string Task_Name { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
