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
        [Key]
        public Int64? LineId { get; set; }

        public Guid? UserUID { get; set; }

        public string? RoleId { get; set; }
        public string? RoleName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		[MaxLength(25, ErrorMessage = DataAnnotations.MaxCharacterLimit.TWENTY_FIVE_CHAR_LIMIT)]
		[RegularExpression(RegEx.RegExAlphaNumericWithHypen, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
		public string EmployeeNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.RegExValidEmail, ErrorMessage = DataAnnotations.InvalidFormat.EMAIL_FORMAT)]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		[MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
		[RegularExpression(RegEx.ALPHABET, ErrorMessage = DataAnnotations.RegexMessage.ALPHABETH)]
		public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		[MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
		[RegularExpression(RegEx.ALPHABET, ErrorMessage = DataAnnotations.RegexMessage.ALPHABETH)]
		public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.RegExPhilippinePhoneNumber, ErrorMessage = DataAnnotations.InvalidFormat.PHONE_NUMBER_FORMAT)]
        public string MobileNumber { get; set; }
        public DateOnly? Birthday { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string CreatedBy { get; set; }
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
        //[NotMapped]
        //public string? AppUrl { get; set; }
    }
}
