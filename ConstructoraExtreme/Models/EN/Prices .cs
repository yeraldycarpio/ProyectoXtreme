using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Prices
    {
        public int Id { get; set; }
        public decimal Daily_Price { get; set; }
        public decimal Monthly_Price { get; set; }
        public int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public Products Products { get; set; }
    }
}
