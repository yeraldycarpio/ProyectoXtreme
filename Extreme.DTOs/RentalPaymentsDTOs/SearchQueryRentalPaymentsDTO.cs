using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalPaymentsDTOs
{
    public class SearchQueryRentalPaymentsDTO
    {
        [Display(Name = "Rental_Id")]
        public int? Rental_Id { get; set; }

        [Display(Name = "Total_Amount")]
        public decimal? Total_Amount { get; set; }

        [Display(Name = "Pending_Amount")]
        public decimal? Pending_Amount { get; set; }

        [Display(Name = "Advance_Payment")]
        public decimal? Advance_Payment { get; set; }

        [Display(Name = "Payment_Status")]
        public string Payment_Status { get; set; }

        [Display(Name = "Due_Date")]
        public DateTime? Due_Date { get; set; }

        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }

}
