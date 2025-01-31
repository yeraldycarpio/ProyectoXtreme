using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenancePartsDTOs
{
    public class SearchResultMaintenancePartsDTO
    {
        public int CountRow { get; set; }

        public List<MaintenancePartsDTO> Data { get; set; } = new();

        public class MaintenancePartsDTO
        {

            public int Id { get; set; }
            public int Maintenance_Record_Id { get; set; }
            public string Part_Name { get; set; }
            public int Quantity { get; set; }
            public decimal Unit_Cost { get; set; }
            public decimal Total_Cost { get; set; }
            public string Supplier { get; set; }
            public DateTime Created_At { get; set; }
        }
    }

}
