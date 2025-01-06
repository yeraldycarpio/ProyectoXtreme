using Extreme.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.DTOs.UsersDTOs
{
    public class EditUserDTO
    {
        // Constructor que inicializa el DTO a partir de un modelo de entidad User
        public EditUserDTO(GetIdResultUserDTO user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
        }

        // Constructor vacío
        public EditUserDTO()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del Correo Electrónico es inválido.")]
        [MaxLength(100, ErrorMessage = "El campo Correo Electrónico no puede tener más de 100 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        [MaxLength(100, ErrorMessage = "El campo Contraseña no puede tener más de 100 caracteres.")]
        public string? Password { get; set; }
    }
}