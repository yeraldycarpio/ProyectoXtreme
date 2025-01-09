using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MunicipalitiesDTOs
{
    using System.ComponentModel.DataAnnotations;

    public class CreateMunicipalitiesDTO
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Municipality Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Municipality Code")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int Department_Id { get; set; }
    }
}
