using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class EditProductDTO
    {
        [Required(ErrorMessage = "The Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MaxLength(100, ErrorMessage = "The Name must not exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "The Description must not exceed 250 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Brand is required.")]
        [MaxLength(50, ErrorMessage = "The Brand must not exceed 50 characters.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "The Store_Id is required.")]
        public int Store_Id { get; set; }

        [Required(ErrorMessage = "The Category_Id is required.")]
        public int Category_Id { get; set; }
    }

}
