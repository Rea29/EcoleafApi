using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class Pagination
    {
        /// Total count of items
        /// </summary>
        public int TotalItems { get; set; }
        public int TotalItemsShown { get; set; }

        /// <summary>
        /// Count of items at the page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Sorted by field name
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Is this an ascending sort?
        /// </summary>
        public bool IsSortAscending { get; set; }

        /// <summary>
        /// Information about what page should be requested
        /// </summary>
        public RouteInfo Route { get; set; } = new RouteInfo();
        public decimal TotalPages { get; set; }
        public int PagesShownUpperLimit { get; set; } = 1;
        public int PagesShownLowerLimit { get; set; } = 1;
        public int PagesInitial { get; set; } = 5;
        public int PagesShownEllipsis { get; set; } = 3;
        public List<int> InitialPages { get; set; } =  new List<int>(){1,2,3,4,5};
    public class RouteInfo
        { 
            public string Action { get; set; }
            public string Controller { get; set; }
            public string targetPartialView { get; set; }
            public string targetLoader { get; set; }
        }

        public decimal GetTotalPages()
        {
            var totalPages = Math.Ceiling((decimal)TotalItems / (decimal)PageSize);
            if (totalPages < Page)
                return Page;
            else
                return totalPages;
        }
    }

}
