using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models.Entities
{
    [Index("Name", IsUnique = true)]
    class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = ("navrchar(100)"))]
        public string Name { get; set; }

        public ICollection<DishItem> DishItems { get; set; }
        public ICollection<DishItemFact> DishItemFacts { get; set; }
        public ICollection<Party> Parties { get; set; }


    }
}
