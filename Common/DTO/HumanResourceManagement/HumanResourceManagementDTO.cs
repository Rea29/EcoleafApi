using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.HumanResourceManagement
{
    public class HumanResourceManagementDTO
    {
        [Key]
        public Int64? LineId{ get; set; }
        public Guid? EmployeesUID { get; set; }
        public string Company { get; set; }
        public string DateOfApplication { get; set; }
        public string PositionApplyingFor { get; set; }
        public string DesiredSalary { get; set; }
        public string FullName { get; set; }
        public string CompleteAddress { get; set; }
        public string MobileNumber { get; set; }
        public string CivilStatus { get; set; }
        public string Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string EmailAddress { get; set; }
        public string SpouseName { get; set; }
        public string SpouseAge { get; set; }
        public string SpouseOccupation { get; set; }
        public string NameOfChildren { get; set; }
        public string AgeOfChildren { get; set; }
        public string BirthdayOfChildren { get; set; }
        public string FathersFullName { get; set; }
        public string FathersOccupation { get; set; }
        public string MothersFullName { get; set; }
        public string MothersOccupation { get; set; }
        public string SiblingsFullName { get; set; }
        public string SiblingsOccupation { get; set; }
        public string SiblingsAge { get; set; }
        public string ContactPersonOfEmergency { get; set; }
        public string ContactPersonAddress { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string Question6 { get; set; }
        public string Question7 { get; set; }
        public string Question8 { get; set; }
        public string Question9 { get; set; }
        public string Question10 { get; set; }
        public string Question11 { get; set; }
        public string Question12 { get; set; }
        public string Question13 { get; set; }
        public string CollegeCredentials { get; set; }
        public string HighSchoolName { get; set; }
        public string VocationalTrainingCertificate { get; set; }
        public string CurrentCompanyName { get; set; } 
        public string CurrentPosition { get; set; }
        public string StartedDate { get; set; }
        public string DateEnd { get; set; }
        public string ReasonForLeaving { get; set; }
        public string SSSNumber { get; set; }
        public string PagibigNumber { get; set; }
        public string PhilhealthNumber { get; set; }
        public string TinNumber { get; set; }
        public string ReferrencesFullName { get; set; }
        public string ReferrencesCompleteAddress { get; set; }
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
