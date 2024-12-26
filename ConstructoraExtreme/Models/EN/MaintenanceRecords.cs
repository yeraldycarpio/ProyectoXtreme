using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class MaintenanceRecords
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Maintenance_Type_Id { get; set; }
        public int Store_Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Estimated_end_Date { get; set; }
        public DateTime Actual_end_Date { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public decimal Technician_name { get; set; }
        public string Descrption { get; set; }
        public string Observation { get; set; }
        public DateTime Next_Maintenance_Date { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Update_At { get; set; }

        [ForeignKey("Product_Id")]
        public Products Products { get; set; }

        [ForeignKey("Maintenance_Type_Id")]
        public MaintenanceTypes MaintenanceTypes { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store { get; set; }

    }

}
