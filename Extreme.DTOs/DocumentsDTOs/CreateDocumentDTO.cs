using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DocumentsDTOs
{
    public class CreateDocumentDTO

    {
        [Required]
        [MaxLength(50)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Is Natural Person")]
        public bool IsNaturalPerson { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}
