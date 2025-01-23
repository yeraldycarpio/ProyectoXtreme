using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ImageDTOs
{
    public class SearchResultImageDTO
    {
        public int TotalResults { get; set; }  // El número total de resultados encontrados

        public List<ImageDTO> Images { get; set; }  // Lista de imágenes encontradas

        public SearchResultImageDTO()
        {
            Images = new List<ImageDTO>();  // Inicializamos la lista de imágenes
        }
    }

    public class ImageDTO
    {
        public int Id { get; set; }

        public int Store_Id { get; set; }

        public int Person_Id { get; set; }

        public DateTime Creation_Date { get; set; }

        // Otros campos que quieras incluir en el resultado de búsqueda
    }

}
