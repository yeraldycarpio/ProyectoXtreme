using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
     public class Persons
    {
        public int Id { get; set; }
        public int Document_Type_Id { get; set; }
        public string Document_Number { get; set; }
        public int Store_Id { get; set; }
        public Boolean Is_Natural_Person { get; set; }
        public String First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Surname { get; set; }
        public string Second_Surname { get; set; }
        public string Business_Name { get; set; }
        public string Trade_Name { get; set; }
        public string NRC {  get; set; }
        public int Economic_Activity_Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public int Department_Id { get; set; }
        public int Municipality_Id { get; set; }
        public string Address_Details { get; set; }
        public Boolean Active { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        [ForeignKey("Document_Type_Id ")]
        public DocumentTypesCatalog DocumentTypesCatalog { get; set; }

        [ForeignKey("Economic_Activity_Id ")]
        public EconomicActivitiesCatalog EconomicActivitiesCatalog { get; set; }

        [ForeignKey("Department_Id ")]
        public DepartmentsCatalog DepartmentsCatalog { get; set; }

        [ForeignKey("Municipality_Id ")]
        public MunicipalitiesCatalog MunicipalitiesCatalog { get; set; }

        [ForeignKey("Store_Id ")]
        public Store Store { get; set; }
    }
}
