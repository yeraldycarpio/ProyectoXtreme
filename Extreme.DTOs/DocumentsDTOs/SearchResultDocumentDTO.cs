using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DocumentsDTOs
{
    public class SearchResultDocumentDTO
    {
        public int CountRow { get; set; }

        public List<DocumentDTO> Data { get; set; } = new();

        public class DocumentDTO
        {
            public int Id { get; set; }

            [Display(Name = "Code")]
            public string Code { get; set; }

            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Is Natural Person")]
            public bool IsNaturalPerson { get; set; }

            [Display(Name = "Active")]
            public bool Active { get; set; }

            [Display(Name = "Created At")]
            public DateTime CreatedAt { get; set; }
        }
    }
}
