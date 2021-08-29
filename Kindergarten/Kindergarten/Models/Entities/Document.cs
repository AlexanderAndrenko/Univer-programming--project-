using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    [Index("Date")]
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        //Навигационные свойства
        public int? MenuFactId { get; set; }
        public MenuFact MenuFact { get; set; }

        public int? NumberChildrenId { get; set; }
        public NumberChildren NumberChildren { get; set; }

        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        public ICollection<Party> Parties { get; set; }

        public ICollection<DocumentData> DocumentDatas { get; set; }
    }
}
