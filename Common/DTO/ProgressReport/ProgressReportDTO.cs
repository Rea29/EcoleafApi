using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.ProgressReport
{
    public class ProgressReportDTO
    {
       
        public Int64? LineId { get; set; }
        [Key]
        public Guid? AccomplishReportUID { get; set; }
        public string GeneralRequirements { get; set; }
        public string Projectname { get; set; }
        public string EngineerName { get; set; }
        public string Previous { get; set; }
        public string Thisperiod { get; set; }
        public string Todate { get; set; }
        public string DescriptionofManpower { get; set; }
        public string Howmanyworkers { get; set; }
        public string Date { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
