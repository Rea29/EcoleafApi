using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global
{
    public class PageInformation
    {
        public int TotalCount { get; set; }
        public PageButton PageInfo { get; set; }
    }

    public class PageButton
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
