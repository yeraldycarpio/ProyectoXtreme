using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.MunicipalitiesDTOs
{
    public class GetIdResultMunicipalitiesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Department_Id { get; set; }
    }
}
