﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme.DTOs.StoreDTOs
{
    public class GetIdResultStoreDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la tienda")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Enlace de la dirección")]
        public string Address_Link { get; set; }

        [Display(Name = "Número de teléfono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "NIT")]
        public string Nit { get; set; }

        [Display(Name = "NRC")]
        public string NRC { get; set; }

        [Display(Name = "Giro")]
        public string Giro { get; set; }

        [Display(Name = "ID del usuario")]
        public int UserId { get; set; }
    }
}
