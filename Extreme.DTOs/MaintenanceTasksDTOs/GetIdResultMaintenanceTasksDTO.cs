using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTasksDTOs
{
    public class GetIdResultMaintenanceTasksDTO
    {
        public int Id { get; set; }
        public int Maintenance_Id { get; set; }
        public string Task_Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Completed_At { get; set; }
        public DateTime Created_At { get; set; }
    }

}
