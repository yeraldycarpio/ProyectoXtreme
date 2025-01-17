using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonsDTOs
{
    public class SearchResultPersonDTO
        {
            public int TotalRecords { get; set; }  // Número total de registros disponibles (sin paginación)
            public int PageNumber { get; set; }  // Página actual
            public int PageSize { get; set; }  // Tamaño de la página
            public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);  // Total de páginas

            // Lista de personas (resultados de la búsqueda)
            public List<GetIdResultPersonDTO> Persons { get; set; } = new List<GetIdResultPersonDTO>();  // Inicializado para evitar null

            // Constructor vacío
            public SearchResultPersonDTO()
            {
            }

            // Constructor con parámetros para inicializar rápidamente la clase
            public SearchResultPersonDTO(int totalRecords, int pageNumber, int pageSize, List<GetIdResultPersonDTO> persons)
            {
                TotalRecords = totalRecords;
                PageNumber = pageNumber;
                PageSize = pageSize;
                Persons = persons ?? new List<GetIdResultPersonDTO>();  // Si 'persons' es null, inicializa con una lista vacía
            }
        }
    }


