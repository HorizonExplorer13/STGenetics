using STGeneticsTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.DTO
{
    public class AnimalDataCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int BreedId { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]
        public int SexId { get; set; }
        public string? ProductoImg { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0;
        public int? StatusId { get; set; }

    }
}
