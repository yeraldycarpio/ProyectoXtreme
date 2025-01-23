using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ImageDTOs
{
    public class GetIdResultImageDTO
    {
        public int Id { get; set; }

        public int Store_Id { get; set; }

        public int Person_Id { get; set; }

        public byte[] File_Data { get; set; }

        public DateTime Creation_Date { get; set; }
    }

}
