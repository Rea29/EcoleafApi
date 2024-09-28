using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.ProgressReport
{
    public class ProgressReportDescriptionOfManpowerDTO
    {
        [Key]
        public long? LineId { get; set; }
        public Guid? ProgressReportManpowerUID { get; set; }
        public Guid? AccomplishReportUID { get; set; }
        public string DescriptionofManpower { get; set; }
        public string Howmanyworkers { get; set; }
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
