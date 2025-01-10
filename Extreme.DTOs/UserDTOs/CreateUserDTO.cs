using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
       
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El Nombre no debe contener más de 50 carácteres.")]
        public string Name { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El Correo Electrónico no debe contener más de 100 carácteres.")]
        [EmailAddress(ErrorMessage = "Escriba un Correo Electrónico válido.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        public string Password { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Por favor, seleccione un  Rol.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Rol seleccionado no es válido.")]
        public int RoleId { get; set; }
    }

}
