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
    public class MaterialRequisitionSlipDTO
    {
        [Key]
        public Int64? LineId { get; set; }
        
        public Guid? MaterialRequestUID { get; set; }
        public string? TypeOfRequest { get; set; }
        public string? MRSNumber { get; set; }
        public Guid? ProjectUID { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string? Remarks { get; set; }
        public string? ScopeOfWorks { get; set; }
        public string? ScheduleOfUrgency { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        //public List<MaterialRequestItemsDTO>? RequestItems { get; set; }
        // Navigation property
        public List<MaterialRequestItemsDTO>? Items { get; set; }
        public List<MRSApproversDTO>? Approvers { get; set; }

    }
}
