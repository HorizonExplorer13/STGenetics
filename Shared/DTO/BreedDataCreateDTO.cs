using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.DTO
{
    public class BreedDataCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
