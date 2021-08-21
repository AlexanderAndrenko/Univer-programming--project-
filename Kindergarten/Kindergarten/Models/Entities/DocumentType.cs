using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        //Наименование типа движения товара
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
