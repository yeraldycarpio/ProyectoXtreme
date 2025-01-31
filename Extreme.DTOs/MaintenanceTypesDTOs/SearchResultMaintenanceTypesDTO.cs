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
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime Created_At { get; set; }
        }
    }

}
