using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class NumberChildren
    {
        [Key]
        public int Id { get; set; }
        
        //Дата записи
        public DateTime Date { get; set; }

        //Количество детей ясли
        public int QuantityNursery { get; set; }

        //Количество детей сад
        public int QuantityYard { get; set; }


        public ICollection<MovingProduct> MovingProducts { get; set; }
    }
}
