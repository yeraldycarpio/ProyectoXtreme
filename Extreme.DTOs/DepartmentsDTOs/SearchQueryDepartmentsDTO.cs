using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DepartmentsDTOs
{
    public class SearchQueryDepartmentsDTO
    {
        [Display(Name = "Codigo del departamento")]
        public string? Code { get; set; }

        [Display(Name = "Nombre del departamento")]
        public string? Name { get; set; }

        [Display(Name = "Página")]
        public int Skip { get; set; } = 0;

        [Display(Name = "Registros por Página")]
        public int Take { get; set; } = 10;

        /// <summary>
        /// 1 = No se cuenta el total de resultados.
        /// 2 = Se cuenta el total de resultados.
        /// </summary>
        public byte SendRowCount { get; set; } = 1;
    }

}
