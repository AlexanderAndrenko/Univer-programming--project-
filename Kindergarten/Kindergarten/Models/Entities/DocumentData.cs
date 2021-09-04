using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Kindergarten.Models.Entities;

namespace Kindergarten.Models.Entities
{
    public class DocumentData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }

        public int? DishItemFactId { get; set; }
        public DishItemFact DishItemFact { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PartyId { get; set; }
        public Party Party { get; set; }
    }
}
