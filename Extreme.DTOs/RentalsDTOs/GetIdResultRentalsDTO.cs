using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class GetIdResultRentalsDTO
    {
        public int Id { get; set; }
        public int Store_Id { get; set; }
        public int Person_Id { get; set; }
        public decimal Total_Amount { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Store_Name { get; set; } // Nombre de la tienda
        public string Person_Name { get; set; } // Nombre de la persona
    }

}
