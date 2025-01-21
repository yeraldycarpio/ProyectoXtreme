using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DepartmentsDTOs

{
    public class CreateDepartmentsDTO
    {


        [Display(Name = "Código")]
        [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo Código no puede tener más de 2 caracteres.")]
        public string Code { get; set; }

        [Display(Name = "Nombre del departamento")]
        [Required(ErrorMessage = "El campo Nombre del departamento es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Nombre del departamento no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

    }


}
