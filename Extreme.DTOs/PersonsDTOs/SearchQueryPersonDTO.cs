using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonsDTOs
{
    public class SearchQueryPersonDTO
    {
        public string Document_Number { get; set; }
        public string First_Name { get; set; }
        public string First_Surname { get; set; }
        public string Business_Name { get; set; }
        public string Trade_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        // Filtros de búsqueda opcionales
        public int? Document_Type_Id { get; set; }
        public int? Economic_Activity_Id { get; set; }
        public int? Department_Id { get; set; }
        public int? Municipality_Id { get; set; }
        public bool? Is_Natural_Person { get; set; }
        public bool? Active { get; set; }

        // Paginación
        public int PageNumber { get; set; } = 1;  // Página inicial por defecto
        public int PageSize { get; set; } = 10;   // Tamaño de página por defecto
    }
}
