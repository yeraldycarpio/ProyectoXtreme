using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.InventoryDTOs
{
    internal class SearchQueryInventoryDTO
    {
            public int? Id { get; set; } 
            public int? AvailableQuantity { get; set; } 
            public int? ProductId { get; set; }
            public int? StoreId { get; set; } 

            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10; 
        }

    }

