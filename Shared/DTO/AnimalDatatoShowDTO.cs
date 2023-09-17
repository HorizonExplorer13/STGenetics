using STGeneticsTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.DTO
{
    public class AnimalDatatoShowDTO
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

    }
}
