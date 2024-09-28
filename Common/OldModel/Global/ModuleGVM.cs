using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global
{
    public class ModuleGVM
    {
        public int ModuleId { get; set; }
        public int? ParentId { get; set; } = 0;
        public string? Title { get; set; } = string.Empty;
        public string? DisplayName { get; set; } = string.Empty;
        public string? UrlPath { get; set; } = string.Empty;
        public string? ScriptPath { get; set; } = string.Empty;
        public string? IconName { get; set; } = string.Empty;
        public int? Sequence { get; set; } = 0;
        public bool? IsDropDown { get; set; } 
        public bool? IsMobile { get; set; }
        public bool? HasAdd { get; set; }
        public bool? HasUpdate { get; set; }
        public bool? HasDelete { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }


        // customized property
        public bool IsAccess { get; set; } = false;
        public string AccessScript { get; set; } = string.Empty;

        public string? GraphQLName { get; set; } = string.Empty;

	}
}
