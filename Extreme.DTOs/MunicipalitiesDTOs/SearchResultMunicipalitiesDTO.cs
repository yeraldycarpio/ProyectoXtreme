using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Extreme.DTOs.MunicipalitiesDTOs
{
    public class SearchResultMunicipalitiesDTO
    {
        public int CountRow { get; set; }

        public List<MunicipalityDTO> Data { get; set; } = new();

        public class MunicipalityDTO
        {
            public int Id { get; set; }

            [Display(Name = "Municipality Code")]
            public string Code { get; set; }

            [Display(Name = "Municipality Name")]
            public string Name { get; set; }

            [Display(Name = "Department ID")]
            public int Department_Id { get; set; }
        }
    }
}
