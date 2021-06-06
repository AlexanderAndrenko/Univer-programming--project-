using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models.Entities
{
    class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
