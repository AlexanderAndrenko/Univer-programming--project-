using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kindergarten.Models.Entities
{
    public class DishItemFact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float NurseryNorm { get; set; }
        
        [Required]
        public float YardNorm { get; set; }


        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DishFactId { get; set; }
        public DishFact DishFact { get; set; }


        public ICollection<Document> Documents { get; set; }
    }
}
