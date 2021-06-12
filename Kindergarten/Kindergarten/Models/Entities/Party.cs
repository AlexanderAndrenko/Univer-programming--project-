using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class Party
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        public bool IsClosed { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateClosed { get; set; }

        public bool IsDeleted { get; set; }


        public ICollection<MovingProduct> MovingProducts { get; set; }

        //Навигационные свойства
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SuppleirId { get; set; }
        public Supplier Supplier { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
