using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class SearchResultProductDTO
    {
        public int CountRow { get; set; }

        public List<ProductDTO> Data { get; set; } = new();

        public class ProductDTO
        {
            public int Id { get; set; }

            [Display(Name = "Product Name")]
            public string Name { get; set; }

            [Display(Name = "Product Description")]
            public string Description { get; set; }

            [Display(Name = "Category")]
            public string Category { get; set; }

            [Display(Name = "Brand")]
            public string Brand { get; set; }

            [Display(Name = "Store ID")]
            public int Store_Id { get; set; }

            [Display(Name = "Store Name")]
            public string StoreName { get; set; }
        }
    }

}
