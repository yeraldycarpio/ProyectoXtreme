using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MunicipalitiesDTOs
{
    using System.ComponentModel.DataAnnotations;

    namespace Extreme.DTOs.MunicipalitiesDTOs
    {
        public class SearchQueryDTO
        {
            [MaxLength(100)] // Ajusta el límite según las reglas de negocio
            [Display(Name = "Municipality Code")]
            public string Code { get; set; }

            [MaxLength(100)] // Ajusta el límite según las reglas de negocio
            [Display(Name = "Municipality Name")]
            public string Name { get; set; }

            [Display(Name = "Department ID")]
            public int? Department_Id { get; set; } // Puede ser nulo para buscar sin filtro en el departamento

            public int PageNumber { get; set; } = 1; // Página inicial por defecto

            public int PageSize { get; set; } = 10; // Número de elementos por página
        }
    }

}
