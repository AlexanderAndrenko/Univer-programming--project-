using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class NumberChildren
    {
        [Key]
        public int Id { get; set; }

        //Дата записи
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        //Количество детей ясли
        [Required]
        public int QuantityNursery { get; set; }

        //Количество детей сад
        [Required]
        public int QuantityYard { get; set; }


        public ICollection<MovingProduct> MovingProducts { get; set; }
    }
}
