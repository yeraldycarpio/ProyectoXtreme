using Microsoft.VisualBasic;

namespace ConstructoraExtreme.Models.EN
{
    public class DocumentTypesCatalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Boolean IsNaturalPerson { get; set; }
        public Boolean Active { get; set; }
        public DateAndTime CreatedAt { get; set; }
    }
}
