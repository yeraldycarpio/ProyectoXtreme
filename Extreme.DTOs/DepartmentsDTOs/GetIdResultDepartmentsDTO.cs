using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DepartmentsDTOs
{
    public class GetIdResultDepartmentsDTO
    {
        public int Id { get; set; }

        [Display(Name = "Codigo del departamento")]
        public string Code { get; set; }

        [Display(Name = "Nombre del departamento")]
        public string Name { get; set; }

    }
}
