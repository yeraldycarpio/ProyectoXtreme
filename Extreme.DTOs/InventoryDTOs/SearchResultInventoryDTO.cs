using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Extreme.DTOs.InventoryDTOs
    {
        public class SearchResultInventoryDTO
        {
            public int CountRow { get; set; }

            public List<InventoryDTO> Data { get; set; } = new();

            public class InventoryDTO
            {
                public int Id { get; set; }

                [Display(Name = "Available Quantity")]
                public int Available_Quantity { get; set; }

                [Display(Name = "Product ID")]
                public int Product_Id { get; set; }

                [Display(Name = "Store ID")]
                public int Store_Id { get; set; }

                [Display(Name = "Product Name")]
                public string ProductName { get; set; } // Nombre del producto asociado

                [Display(Name = "Store Name")]
                public string StoreName { get; set; } // Nombre de la tienda asociada
            }
        }
    }
