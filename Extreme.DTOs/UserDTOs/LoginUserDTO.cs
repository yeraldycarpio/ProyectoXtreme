using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.UserDTOs
{
    public class LoginUserDTO
    {

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "Por favor, ingrese su Correo Electrónico.")]
        [MaxLength(100, ErrorMessage = "El Correo Electrónico no debe contener más de 100 carácteres.")]
        [EmailAddress(ErrorMessage = "Ingrese un Correo Electrónico válido.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Por favor, ingrese su Contraseña.")]
        public string Password { get; set; }
    }
}
