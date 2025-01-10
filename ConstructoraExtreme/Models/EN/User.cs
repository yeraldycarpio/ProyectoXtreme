using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ConstructoraExtreme.Models.EN
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }

        [Column("role_id")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
