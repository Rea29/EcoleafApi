using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users { 
    public class UserModulesDTO
    {
        public Int64? LineId { get; set; }
        [Key]
        public Guid? UserModuleUID { get; set; }


        public Guid? UserUID { get; set; }
        public Guid? ModuleUID { get; set; }

        public string? AccessType { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //[NotMapped]
        //public string? AppUrl { get; set; }
    }
}
