using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    [Table("departments_catalog")]
    public class DepartmentsCatalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
