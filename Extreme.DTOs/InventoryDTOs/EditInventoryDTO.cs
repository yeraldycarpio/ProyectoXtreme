using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.InventoryDTOs
{
        public class EditInventoryDTO
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "The Available Quantity is required.")]
            [Range(1, int.MaxValue, ErrorMessage = "Available Quantity must be greater than 0.")]
            [Display(Name = "Available Quantity")]
            public int Available_Quantity { get; set; }

            [Required(ErrorMessage = "The Product ID is required.")]
            [Display(Name = "Product ID")]
            public int Product_Id { get; set; }

            [Required(ErrorMessage = "The Store ID is required.")]
            [Display(Name = "Store ID")]
            public int Store_Id { get; set; }

            [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters.")]
            [Display(Name = "Product Name")]
            public string ProductName { get; set; } // Nombre del producto asociado

            [StringLength(100, ErrorMessage = "Store Name cannot be longer than 100 characters.")]
            [Display(Name = "Store Name")]
            public string StoreName { get; set; } // Nombre de la tienda asociada
        }
    }


