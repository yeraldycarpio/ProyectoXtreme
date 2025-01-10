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
        public EditUserDTO(GetIdResultUserDTO user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }

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
        [MaxLength(100, ErrorMessage = "El campo Correo Electrónico no puede tener más de 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Escriba un Correo Electrónico válido.")]
        public string Email { get; set; }
    }
}