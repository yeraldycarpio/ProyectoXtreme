using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.StoreDTOs
{
    public class EditStoreDTO
    {
        // Constructor que inicializa el DTO a partir de un modelo de entidad Store
        public EditStoreDTO(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            Address = store.Address;
            Address_Link = store.Address_Link;
            PhoneNumber = store.phone_number;
            Nit = store.Nit;
            NRC = store.NRC;
            Giro = store.Giro;
            UserId = store.User_Id;
        }

        // Constructor vacío
        public EditStoreDTO()
        {
            Name = string.Empty;
            Address = string.Empty;
            Address_Link = string.Empty;
            PhoneNumber = string.Empty;
            Nit = string.Empty;
            NRC = string.Empty;
            Giro = string.Empty;
        }

        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Nombre de la tienda")]
        [Required(ErrorMessage = "El campo Nombre de la tienda es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Nombre de la tienda no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El campo Dirección no puede tener más de 200 caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Enlace de la dirección")]
        [MaxLength(200, ErrorMessage = "El campo Enlace de la dirección no puede tener más de 200 caracteres.")]
        public string Address_Link { get; set; }

        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "El campo Número de teléfono es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo Número de teléfono no puede tener más de 20 caracteres.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "NIT")]
        [Required(ErrorMessage = "El campo NIT es obligatorio.")]
        [MaxLength(17, ErrorMessage = "El campo NIT no puede tener más de 17 caracteres.")]
        public string Nit { get; set; }

        [Display(Name = "NRC")]
        [Required(ErrorMessage = "El campo NRC es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo NRC no puede tener más de 10 caracteres.")]
        public string NRC { get; set; }

        [Display(Name = "Giro")]
        [Required(ErrorMessage = "El campo Giro es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Giro no puede tener más de 50 caracteres.")]
        public string Giro { get; set; }

        [Display(Name = "ID del usuario")]
        [Required(ErrorMessage = "El campo ID del usuario es obligatorio.")]
        public int UserId { get; set; }
    }
}
