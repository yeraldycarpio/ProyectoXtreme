using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PriceDTOs
{
    public class SearchResultPriceDTO
    {
        public int CountRow { get; set; }

        public List<PriceDTO> Data { get; set; } = new();

        public class PriceDTO
        {
            public int Id { get; set; }

            [Display(Name = "Daily Price")]
            public decimal Daily_Price { get; set; }

            [Display(Name = "Monthly Price")]
            public decimal Monthly_Price { get; set; }

            [Display(Name = "Product ID")]
            public int Product_Id { get; set; }

            [Display(Name = "Product Name")]
            public string ProductName { get; set; } // Nombre del producto asociado
        }
    }

}
