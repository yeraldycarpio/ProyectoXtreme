using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.DocumentsDTOs
{
    public class GetIdResultDocumentDTO 
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsNaturalPerson { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
