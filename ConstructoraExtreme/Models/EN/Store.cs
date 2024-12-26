using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address_Link { get; set; }
        public string phone_number { get; set; }
        public string Nit { get; set; }
        public string NRC   { get; set; }
        public string Giro { get; set; }
        public int User_Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
