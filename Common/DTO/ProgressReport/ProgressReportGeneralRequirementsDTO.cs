using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.ProgressReport
{
    public class ProgressReportGeneralRequirementsDTO
    {
        [Key]
        public long? LineId { get; set; }
        public Guid? ProgressReportGeneralRequirementsUID { get; set; }
        public Guid? AccomplishReportUID { get; set; }
        public string GeneralRequirements { get; set; }
        public string Previous { get; set; }
        public string Thisperiod { get; set; }
        public string Todate { get; set; }
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
