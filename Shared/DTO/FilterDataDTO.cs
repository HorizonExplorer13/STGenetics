using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.DTO
{
    public class FilterDataDTO
    {
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public DateTime? BirthDate { get; set; }

        public decimal? Price { get; set; }

        public int? SexId { get; set; }
        public int? StatusId { get; set; }
    }
}
