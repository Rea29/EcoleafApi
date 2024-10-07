using Common.Constants;
using Common.DTO.HumanResourceManagement;
using Common.DTO.MaterialRequisitionSlip;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MaterialRequesitionSlip
{
    public class MRSApproversDTO
    {
        
        public Int64? LineId { get; set; }
        [Key]
        public Guid? MRSApproverUID { get; set; }
        public Guid? MaterialRequestUID { get; set; }
        public Guid? EmployeesUID { get; set; }
        public int? HierarchySequence { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApproverName { get; set; }
        //public bool? IsActive { get; set; }
        //public string? CreatedBy { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public string? UpdatedBy { get; set; }
        //public DateTime? UpdatedAt { get; set; }

       

    }
}
