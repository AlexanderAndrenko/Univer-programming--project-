using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class DishFact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        public int DishNurseryNorm { get; set; }

        [Required]
        public int DishYardNorm { get; set; }

        public ICollection<DishItemFact> DishItemFacts { get; set; }

        //Навигационные свойства
        public int MenuFactId { get; set; }
        public MenuFact MenuFact { get; set; }
    }
}
