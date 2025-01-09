using System.ComponentModel.DataAnnotations;

namespace Extreme.DTOs.MunicipalitiesDTOs
{
    public class EditMunicipalitiesDTO
    {
        // Constructor vacío para inicializar valores predeterminados
        public EditMunicipalitiesDTO()
        {
            Name = string.Empty;
            Code = string.Empty;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Municipality Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)] // Ajusta el límite según las reglas de negocio
        [Display(Name = "Municipality Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int Department_Id { get; set; }
    }
}
