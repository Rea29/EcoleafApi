using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Users { 
    public class UserDTO
    {
        public Int64? LineId { get; set; }
        [Key]
        public Guid? UserUID { get; set; }

        public string? UserRoleUID { get; set; }

        public Guid? EmployeesUID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.RegExValidEmail, ErrorMessage = DataAnnotations.InvalidFormat.EMAIL_FORMAT)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? Password { get; set; }

      
        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }


        //[NotMapped]
        //public int? LoginAttempt { get; set; }
        //[NotMapped]
        //public DateTime? LastLoginAttemptAt { get; set; }

        //// added properties
        ////public IEnumerable<ModuleGVM>? RoleModuleAccess { get; set; } = new List<ModuleGVM>();


        //[NotMapped]
        //public List<string>? Tokens { get; set; } = new List<string>();

        ////customized properties
        //[NotMapped]
        public string? NotHashPassword { get; set; }
        public int? LoginAttempt { get; set; }
        public DateTime? LastLoginAttemptAt { get; set; }
        public string? RoleName { get; set; }
        //[NotMapped]
        //public string? AppUrl { get; set; }
    }
}
