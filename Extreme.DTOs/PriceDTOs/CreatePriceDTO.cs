using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PriceDTOs
{
    public class CreatePriceDTO
    {
        [Required(ErrorMessage = "The Daily Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Daily Price must be a positive value.")]
        public decimal Daily_Price { get; set; }

        [Required(ErrorMessage = "The Monthly Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Monthly Price must be a positive value.")]
        public decimal Monthly_Price { get; set; }

        [Required(ErrorMessage = "The Product_Id is required.")]
        public int Product_Id { get; set; }
    }

}
