using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class DishFact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DishNurseryNorm { get; set; }
        public int DishYardNorm { get; set; }

        public ICollection<DishItemFact> DishItemFacts { get; set; }

        //Навигационные свойства
        public int MenuFactId { get; set; }
        public MenuFact MenuFact { get; set; }
    }
}
