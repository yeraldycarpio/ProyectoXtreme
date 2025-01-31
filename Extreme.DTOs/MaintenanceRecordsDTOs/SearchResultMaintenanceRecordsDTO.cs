using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceRecordsDTOs
{
    public class SearchResultMaintenanceRecordsDTO
    {
        public int CountRow { get; set; }

        public List<MaintenanceRecordsDTO> Data { get; set; } = new();

        public class MaintenanceRecordsDTO
        {

            public int Id { get; set; }
            public int Maintenance_Id { get; set; }
            public string Task_Name { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
        }
    }

}
