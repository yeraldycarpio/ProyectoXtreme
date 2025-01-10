using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RolesDTOs
{
    public class CreateRoleDTO
    {
        [Display(Name = "Nombre Rol")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El Nombre no debe contener más de 50 carácteres.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}
