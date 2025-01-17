using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PriceDTOs
{
    public class SearchQueryPriceDTO
    {
        [Range(0, double.MaxValue, ErrorMessage = "The minimum daily price must be a positive value.")]
        [Display(Name = "Min Daily Price")]
        public decimal? MinDaily_Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The maximum daily price must be a positive value.")]
        [Display(Name = "Max Daily Price")]
        public decimal? MaxDaily_Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The minimum monthly price must be a positive value.")]
        [Display(Name = "Min Monthly Price")]
        public decimal? MinMonthly_Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The maximum monthly price must be a positive value.")]
        [Display(Name = "Max Monthly Price")]
        public decimal? MaxMonthly_Price { get; set; }

        [Display(Name = "Product ID")]
        public int? Product_Id { get; set; }

        [MaxLength(100, ErrorMessage = "The product name must not exceed 100 characters.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
