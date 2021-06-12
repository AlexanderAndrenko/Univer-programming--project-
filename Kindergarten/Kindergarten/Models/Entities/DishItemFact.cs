using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class DishItemFact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NurseryNorm { get; set; }
        
        [Required]
        public int YardNorm { get; set; }


        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DishFactId { get; set; }
        public DishFact DishFact { get; set; }


        public ICollection<MovingProduct> MovingProducts { get; set; }
    }
}
