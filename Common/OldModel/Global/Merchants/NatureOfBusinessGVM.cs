using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Merchants
{
    public class NatureOfBusinessGVM
    {
        public int? NatureOfBusinessId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? IsEnabled { get; set; }
        public string? IsNonService { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? LastModifiedBy { get; set; }
        public string? DateLastModified { get; set; }

    }
}
