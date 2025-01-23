using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalsDTOs
{
    public class SearchResultRentalsDTO
    {
        public int CountRow { get; set; }

        public List<RentalsDTO> Data { get; set; } = new();

        public class RentalsDTO
        {
            [Display(Name = "Store_id")]
            public int? Store_Id { get; set; }

            [Display(Name = "Person_Id")]
            public int? Person_Id { get; set; }

            [Display(Name = "Start_Date")]
            public DateTime? Start_Date { get; set; }

            [Display(Name = "DateTime")]
            public DateTime? End_Date { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            [Display(Name = "Name")]
            public string Name { get; set; }
        }
    }

}
