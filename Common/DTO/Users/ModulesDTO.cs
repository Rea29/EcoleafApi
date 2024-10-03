using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users { 
    public class ModulesDTO
    {
        public Int64? LineId { get; set; }
        [Key]
        public Guid? ModuleUID { get; set; }


        public Guid? ParentUID { get; set; }
      
        public string? ModuleDisplayName { get; set; }
        public string? Component { get; set; }
        public string? UrlPath { get; set; }
        public string? Element { get; set; }
        public string? Icon { get; set; }
        public string? RouteId { get; set; }
        public string? AccessType { get; set; }


        public bool? IsActive { get; set; }

        //[NotMapped]
        //public string? AppUrl { get; set; }
    }
}
