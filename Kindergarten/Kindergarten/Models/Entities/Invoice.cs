using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int ID { get; set; }

        //Дата создани записи
        [Required]
        public DateTime DateCreated { get; set; }

        //Дата накладной
        [Required]
        public DateTime DateOfInvoice { get; set; }

        //Номер накладной поставщика
        [Column(TypeName = "nvarchar(20)")]
        public string SupplierNumber { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
