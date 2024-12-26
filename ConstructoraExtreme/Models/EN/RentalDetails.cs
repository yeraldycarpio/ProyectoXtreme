using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class RentalDetails
    {
        public int Id { get; set; }
        public int Rental_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Daily_Price { get; set; }
        public int Rental_Days { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime Created_At { get; set; }

        [ForeignKey("Rental_Id")]
        public Rentals Rentals { get; set; }

        [ForeignKey("Product_Id")]
        public Products Products {  get; set; }
    }
}
