using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonReferencesDTOs
{
    public class SearchResultDTO
    {
        public int CountRow { get; set; }

        public List<DataDTO> Data { get; set; } = new();

        public class DataDTO
        {
            public int Id { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Phone")]
            public string Phone { get; set; }

            [Display(Name = "Store Name")]
            public string StoreName { get; set; }

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }

            [Display(Name = "Created At")]
            public DateTime CreatedAt { get; set; }

            [Display(Name = "Updated At")]
            public DateTime UpdatedAt { get; set; }
        }
    }
}