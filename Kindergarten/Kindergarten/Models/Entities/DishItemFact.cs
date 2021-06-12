using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class DishItemFact
    {
        public int Id { get; set; }
        public int NurseryNorm { get; set; }
        public int YardNorm { get; set; }

        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DishFactId { get; set; }
        public DishFact DishFact { get; set; }


        public ICollection<MovingProduct> MovingProducts { get; set; }
    }
}
