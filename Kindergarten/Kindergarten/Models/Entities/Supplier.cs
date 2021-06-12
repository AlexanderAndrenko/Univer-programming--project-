using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarhcar(20)")]
        public string Phone { get; set; }


        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Party> Parties { get; set; }

    }
}
