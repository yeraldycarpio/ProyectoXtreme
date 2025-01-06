using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.UserDTOs
{
    public class SearchResultUserDTO
    {
        public int CountRow { get; set; }

        public List<UserDTO> Data { get; set; } = new();

        public class UserDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }
        }
    }
}
