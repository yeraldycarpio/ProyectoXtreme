using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Available_Quantity { get; set; }
        public int Product_Id { get; set; }
        public int Store_Id { get; set; }

        [ForeignKey("Product_Id")]
        public Products Products { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store { get; set; }
    }
}
