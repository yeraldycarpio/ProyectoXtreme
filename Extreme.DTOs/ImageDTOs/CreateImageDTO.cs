using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.ImageDTOs
{
    public class CreateImageDTO
    {
        [Required]
        public int Store_Id { get; set; }

        [Required]
        public int Person_Id { get; set; }

        [Required]
        public byte[] File_Data { get; set; }

        [Required]
        public DateTime Creation_Date { get; set; }
    }

}
