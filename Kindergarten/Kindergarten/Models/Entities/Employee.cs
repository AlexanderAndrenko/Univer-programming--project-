using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kindergarten.Models.Entities
{
    class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarhchar(100")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarhchar(100")]
        public string Lastname { get; set; }

        [Column(TypeName = "nvarhchar(100")]
        public string? Patronymic { get; set; }

        [Column(TypeName = "nvarhchar(100")]
        public string? Position { get; set; }

        [Column(TypeName = "nvarhchar(20")]
        public string? Phone { get; set; }
    }
}
