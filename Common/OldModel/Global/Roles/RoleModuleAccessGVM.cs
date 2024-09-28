using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Roles
{
    public class RoleModuleAccessGVM
    {
        public int LineId { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public int ModuleId { get; set; }
        public string AccessScript { get; set; } = string.Empty;
        public int Status { get; set; } = 1;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set;} = string.Empty;
        public DateTime UpdatedAt { get; set;}


        // customized properties
        public bool IsAccess { get; set; } = false;
        public string DisplayName { get; set; } = string.Empty;

    }
}
