using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.EconomicsDTOs
{
    public class SearchResultEconomicDTO
    {
        public int CountRow { get; set; }

        public List<EconomicActivityDTO> Data { get; set; } = new();

        public class EconomicActivityDTO
        {
            public int Id { get; set; }

            [Display(Name = "Activity Code")]
            public string Code { get; set; }

            [Display(Name = "Activity Description")]
            public string Description { get; set; }

            [Display(Name = "Active Status")]
            public bool Active { get; set; }
        }
    }

}
