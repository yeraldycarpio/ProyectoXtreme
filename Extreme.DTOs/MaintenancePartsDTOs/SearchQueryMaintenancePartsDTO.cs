using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenancePartsDTOs
{
    public class SearchQueryMaintenancePartsDTO
    {
        [Display(Name = "Maintenance_Record_Id")]
        public int? Maintenance_Record_Id { get; set; }

        [Display(Name = "Part_Name")]
        public string Part_Name { get; set; }

        [Display(Name = "Supplier ")]
        public string Supplier { get; set; }

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
