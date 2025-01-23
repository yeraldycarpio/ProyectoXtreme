﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructoraExtreme.Models.EN
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      //  public string Category { get; set; }
        public string Brand { get; set; }
        public int Store_Id { get; set; }

        public int Category_Id { get; set; }

        [ForeignKey("Store_Id")]
        public Store Store { get; set; }

        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
}
