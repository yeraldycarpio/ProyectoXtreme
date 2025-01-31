using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MaintenanceTypesDTOs
{
    public class SearchResultMaintenanceTypesDTO
    {
        public int CountRow { get; set; }

        public List<MaintenanceTypesDTO> Data { get; set; } = new();

        public class MaintenanceTypesDTO
        {
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }
        }
    }

}
