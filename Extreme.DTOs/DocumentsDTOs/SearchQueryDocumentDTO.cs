using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DocumentsDTOs
{
    public class SearchQueryDocumentDTO
    {
        [MaxLength(50)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Code")]
        public string? Code { get; set; }

        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Is Natural Person")]
        public bool? IsNaturalPerson { get; set; }

        [Display(Name = "Active")]
        public bool? Active { get; set; }
    }
}
