using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Rentals
    {
        public int Id { get; set; }
        public int Store_Id { get; set; }
        public int Person_Id { get; set; }
        public decimal Total_Amount { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store { get; set; }

        [ForeignKey("Person_Id")]
        public Persons Persons {  get; set; }

    }
}
