using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class SearchQueryProductDTO
    {
        [MaxLength(100, ErrorMessage = "The Name must not exceed 100 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The Brand must not exceed 50 characters.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Store ID")]
        public int? Store_Id { get; set; } // Optional filter by store

        [Display(Name = "Category_Id ")]
        public int? Category_Id { get; set; } 

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
