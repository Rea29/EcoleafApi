using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users { 
    public class UserDetailsDTOOld
    {
        public Int64? LineId { get; set; }
        public Guid? UserUID { get; set; }


        public Guid? EmployeesUID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.RegExValidEmail, ErrorMessage = DataAnnotations.InvalidFormat.EMAIL_FORMAT)]
        public string Email { get; set; }
        public bool? HasEmployeeRecord { get; set; }
        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }

        public int? LoginAttempt { get; set; }
        public DateTime? LastLoginAttemptAt { get; set; }
        public string? RoleName { get; set; }
        public List<UserRoleDTO> UserRoles { get; set; } // List of user roles
        //[NotMapped]
        //public string? AppUrl { get; set; }
    }
}
