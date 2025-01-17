using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.EconomicsDTOs
{
    public class CreateEconomicDTO
    {
        [Required(ErrorMessage = "The Code is required.")]
        [MaxLength(50, ErrorMessage = "The Code must not exceed 50 characters.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [MaxLength(250, ErrorMessage = "The Description must not exceed 250 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Active field is required.")]
        public bool Active { get; set; }
    }

}
