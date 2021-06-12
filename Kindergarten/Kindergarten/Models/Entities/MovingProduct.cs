using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    [Index("Date")]
    class MovingProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Required]
        public float Quantity { get; set; }



        //Навигационные свойства
        public int DishItemFatcId { get; set; }
        public DishItemFact DishItemFact { get; set; }

        public int NumberChildrenId { get; set; }
        public NumberChildren NumberChildren { get; set; }

        public int TypeMovingProductId { get; set; }
        public TypeMovingProduct TypeMovingProduct { get; set; }

        public int PartyId { get; set; }
        public Party Party { get; set; }

    }
}
