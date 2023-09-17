using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.Entities
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public DateTime BirthDate { get; set; }
        [ForeignKey("Sex")]
        public int SexId { get; set; }
        public Sex Sex { get; set; }

        public string? ProductoImg { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public Status Status { get; set; }
    }
}
