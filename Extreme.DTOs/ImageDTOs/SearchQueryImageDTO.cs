using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ImageDTOs
{
    public class SearchQueryImageDTO
    {
        public int? Store_Id { get; set; }  // Puede ser null si no se filtra por Store

        public int? Person_Id { get; set; }  // Puede ser null si no se filtra por Person

        public DateTime? Start_Date { get; set; }  // Puede ser null si no se filtra por fecha

        public DateTime? End_Date { get; set; }  // Puede ser null si no se filtra por fecha

        public string File_Data_Filter { get; set; }  // Puede usarse para algún filtro adicional en el contenido de la imagen (por ejemplo, tipo de archivo)

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
