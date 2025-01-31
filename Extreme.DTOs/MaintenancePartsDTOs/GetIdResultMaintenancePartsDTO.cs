using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenancePartsDTOs
{
    public class GetIdResultMaintenancePartsDTO
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
