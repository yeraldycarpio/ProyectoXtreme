using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    [Table("person_references")]
    public class PersonReferences
    {
        public int Id { get; set; }
        public int Store_Id { get; set; }
        public int Person_Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Surname { get; set; }
        public string Second_Surname { get; set; }
        public string Phone { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Boolean Active { get; set; }

        [ForeignKey("Person_Id")]
        public Persons Persons { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store { get; set; }
    }
}
