using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGeneticsTest.Shared.DTO
{
    public class PaginationDTO
    {
        public int PageNumber { get; set; } = 1;
        private int RowsperPage { get; set; } = 10;
        private readonly int MaxRowsPerPage = 20;

        public int RowPerPage
        {
            get
            {
                return RowsperPage;
            }
            set
            {
                RowsperPage = (value > MaxRowsPerPage) ? MaxRowsPerPage : value;
            }
        }
    }
}
