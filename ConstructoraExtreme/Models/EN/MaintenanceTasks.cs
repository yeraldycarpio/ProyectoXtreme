using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class MaintenanceTasks
    {
        public int Id { get; set; }
        public int Maintenance_Id { get; set; }
        public string Task_Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Completed_At { get; set; }
        public DateTime Created_At { get; set; }

        [ForeignKey("Maintenance_Id")]
        public MaintenanceRecords MaintenanceRecords { get; set; }

    }
}
