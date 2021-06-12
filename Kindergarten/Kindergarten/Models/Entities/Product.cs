﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models.Entities
{
    class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DishItem> DishItems { get; set; }
        public ICollection<DishItemFact> DishItemFacts { get; set; }
        public ICollection<Party> Parties { get; set; }


    }
}
