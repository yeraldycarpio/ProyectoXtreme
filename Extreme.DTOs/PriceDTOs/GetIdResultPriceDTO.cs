using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PriceDTOs
{
    public class GetIdResultPriceDTO
    {
        public int Id { get; set; }

        public decimal Daily_Price { get; set; }

        public decimal Monthly_Price { get; set; }

        public int Product_Id { get; set; }

        public string ProductName { get; set; } // Nombre del producto asociado, opcional
    }

}
