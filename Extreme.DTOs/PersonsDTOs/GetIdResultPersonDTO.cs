using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonsDTOs
{
    public class GetIdResultPersonDTO
    {
            public int Id { get; set; }
            public int Document_Type_Id { get; set; }
            public string Document_Number { get; set; }
            public int Store_Id { get; set; }
            public bool Is_Natural_Person { get; set; }
            public string First_Name { get; set; }
            public string Middle_Name { get; set; }
            public string First_Surname { get; set; }
            public string Second_Surname { get; set; }
            public string Business_Name { get; set; }
            public string Trade_Name { get; set; }
            public string NRC { get; set; }
            public int Economic_Activity_Id { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Country { get; set; }
            public int Department_Id { get; set; }
            public int Municipality_Id { get; set; }
            public string Address_Details { get; set; }
            public bool Active { get; set; }
            public DateTime Created_At { get; set; }
            public DateTime Updated_At { get; set; }

            // Aquí agregamos las propiedades de las entidades relacionadas si es necesario
            public string Document_Type_Name { get; set; }
            public string Economic_Activity_Name { get; set; }
            public string Department_Name { get; set; }
            public string Municipality_Name { get; set; }
            public string Store_Name { get; set; }
        }
    }
