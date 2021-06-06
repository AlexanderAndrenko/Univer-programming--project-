using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models.Entities
{
    class DishItem
    {
        public int Id { get; set; }
        public  int NurseryNorm { get; set; }
        public int YardNorm { get; set; }

        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
