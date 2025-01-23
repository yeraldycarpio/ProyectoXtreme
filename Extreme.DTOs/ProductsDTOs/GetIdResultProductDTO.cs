using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class GetIdResultProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public int Store_Id { get; set; }

        public string StoreName { get; set; } // Nombre de la tienda asociado, opcional si deseas incluir detalles adicionales
    
        public int Category_Id { get; set; }
        public string CategoryName { get; set; } //Nombre de la categoria opcional incluir detalles adicionales
    }

}
