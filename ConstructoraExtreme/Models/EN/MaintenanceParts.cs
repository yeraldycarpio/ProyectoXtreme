using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class MaintenanceParts
    {
        public int Id { get; set; }
        public int Maintenance_Record_Id { get; set; }
        public string Part_Name { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Cost { get; set; }
        public decimal Total_Cost { get; set; }
        public string Supplier { get; set; }
        public DateTime Created_At { get; set; }

        [ForeignKey("Maintenance_Record_Id")]
        public MaintenanceRecords MaintenanceRecords { get; set; }
    }
}
