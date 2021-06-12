using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models.Entities
{
    class Dish
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

        public ICollection<DishItem> DishItems { get; set; }

        //Навигационные свойства
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
