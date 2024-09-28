using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO.MaterialRequisitionSlip;

namespace Common.DTO.ProjectMonitoringManagement
{
    public class ProjectsDTO
    {
        [Key]
        public Int64? LineId { get; set; }
        public Guid? ProjectUID { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLocation { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ContractAmount { get; set; }
        public string ProjectStartDate { get; set; }
        public string MobilizationDate { get; set; }
        public string Retention { get; set; }
        public string Downpayment { get; set; } 
        public string Bonds { get; set; }
        public string ProjectStatus { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
