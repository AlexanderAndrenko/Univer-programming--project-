using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Patronymic { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Position { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Phone { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
