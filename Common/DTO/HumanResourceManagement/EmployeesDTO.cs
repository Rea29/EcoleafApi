using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.HumanResourceManagement
{
    public class EmployeesDTO
    {
        [Key]
        public long? LineId { get; set; }
        public Guid? EmployeesUID { get; set; }
        public string Company { get; set; }
        public string DateOfApplication { get; set; }
        public string EmployeeNumber { get; set; }
        public string PositionApplyingFor { get; set; }
        public string DesiredSalary { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string BarangayId { get; set; }
        public string ZipCode { get; set; }
        public string HomeTelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string CivilStatus { get; set; }
        public string Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string EmailAddress { get; set; }
        public string SpouseName { get; set; }
        public string SpouseAge { get; set; }
        public string SpouseOccupation { get; set; }
        public string Gender { get; set; }

        public string FathersFullName { get; set; }
        public string FathersOccupation { get; set; }
        public string MothersFullName { get; set; }
        public string MothersOccupation { get; set; }

        public string ContactPersonIncaseOfEmergency { get; set; }
        public string ContactPersonNumber { get; set; }
        public string ContactPersonAddress { get; set; }
        public string LanguageOrDialectSpoken { get; set; }
        public int? StatusSequence { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<ChildrenDTO>? EmployeesChildren { get; set; }
        public List<SiblingsDTO>? EmployeesSiblings { get; set; }








    }
}
