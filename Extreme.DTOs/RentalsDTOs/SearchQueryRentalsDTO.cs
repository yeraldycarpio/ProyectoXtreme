using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ProductsDTOs
{
    public class SearchQueryRentalsDTO
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

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
