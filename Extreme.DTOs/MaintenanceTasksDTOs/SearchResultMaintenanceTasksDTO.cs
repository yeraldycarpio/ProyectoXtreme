using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTasksDTOs
{
    public class SearchResultMaintenanceTasksDTO
    {
        public int CountRow { get; set; }

        public List<MaintenanceTasksDTO> Data { get; set; } = new();

        public class MaintenanceTasksDTO
        {
            [Display(Name = "Maintenance_Id ")]
            public int? Maintenance_Id { get; set; }

            [Display(Name = "Task_Name")]
            public string Task_Name { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

        }
    }

}
