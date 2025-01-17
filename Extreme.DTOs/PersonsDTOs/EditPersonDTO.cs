using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonsDTOs
{
    public class EditPersonDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Document_Type_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Document_Number { get; set; }

        [Required]
        public int Store_Id { get; set; }

        [Required]
        public bool Is_Natural_Person { get; set; }

        [Required]
        [MaxLength(100)]
        public string First_Name { get; set; }

        [MaxLength(100)]
        public string Middle_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string First_Surname { get; set; }

        [MaxLength(100)]
        public string Second_Surname { get; set; }

        [MaxLength(150)]
        public string Business_Name { get; set; }

        [MaxLength(150)]
        public string Trade_Name { get; set; }

        [MaxLength(20)]
        public string NRC { get; set; }

        [Required]
        public int Economic_Activity_Id { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        public int Department_Id { get; set; }

        [Required]
        public int Municipality_Id { get; set; }

        [MaxLength(250)]
        public string Address_Details { get; set; }

        public bool Active { get; set; }

        [Required]
        public DateTime Updated_At { get; set; }
    }
}
