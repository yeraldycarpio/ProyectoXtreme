using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    [Table("municipalities_catalog")]
    public class MunicipalitiesCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Department_Id { get; set; }

        [ForeignKey("Department_Id")]
        public DepartmentsCatalog DepartmentsCatalog { get; set; }
    }
}
