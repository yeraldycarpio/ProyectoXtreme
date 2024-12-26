using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Images
    {
        public int Id { get; set; }
        public int Store_Id { get; set; }
        public int Person_Id { get; set; }
        public byte File_Data { get; set; }
        public DateTime Creation_Date { get; set; }

        [ForeignKey("Person_Id")]
        public Persons Persons { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store {  get; set; }
    }
}
