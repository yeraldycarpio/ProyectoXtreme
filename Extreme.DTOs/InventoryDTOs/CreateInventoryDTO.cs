using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Extreme.DTOs.Inventory
{
    public class CreateInventoryDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Available_Quantity must be greater than 0.")]
        public int Available_Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Product_Id must be a valid identifier.")]
        public int Product_Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Store_Id must be a valid identifier.")]
        public int Store_Id { get; set; }
    }
}
