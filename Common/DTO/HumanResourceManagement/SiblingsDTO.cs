using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.HumanResourceManagement
{
    public class SiblingsDTO
    {
        [Key]
        public long? LineId { get; set; }
        public Guid? EmployeesSiblingsUID { get; set; }
        public Guid? EmployeesUID { get; set; }
        public string SiblingsFirstName { get; set; }
        public string SiblingsLastName { get; set; }
        public string SiblingsAge { get; set; }
        public string SiblingsOccupation { get; set; }
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
