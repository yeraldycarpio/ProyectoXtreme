﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.PersonReferencesDTOs
{
    public class EditPersonReferencesDTO
    {
        [Required]
        public int Id { get; set; }

        //  [Required]
        //public int Store_Id { get; set; }

        //        [Required]
        //public int Person_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }

        [MaxLength(50)]
        public string Middle_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string First_Surname { get; set; }

        [MaxLength(50)]
        public string Second_Surname { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
