using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.RentalPaymentsDTOs
{
    public class GetIdResultRentalPaymentsDTO
    {
        public int Id { get; set; }
        public int Rental_Id { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Pending_Amount { get; set; }
        public decimal Advance_Payment { get; set; }
        public string Payment_Status { get; set; }
        public DateTime Due_Date { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Update_At { get; set; }
        public string Rental_Status { get; set; } // Estado del alquiler relacionado
    }

}
