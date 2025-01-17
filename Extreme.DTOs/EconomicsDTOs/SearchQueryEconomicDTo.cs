using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.EconomicsDTOs
{
    public class SearchQueryEconomicDTO
    {
        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Activity Code")]
        public string Code { get; set; }

        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Activity Description")]
        public string Description { get; set; }

        [Display(Name = "Active Status")]
        public bool? Active { get; set; } // Puede ser nulo para buscar sin filtro en el estado activo

        public int PageNumber { get; set; } = 1; // Página inicial por defecto

        public int PageSize { get; set; } = 10; // Número de elementos por página
    }

}
