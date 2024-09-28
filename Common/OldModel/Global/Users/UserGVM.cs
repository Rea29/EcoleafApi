using Common.Constants;
using Common.Model.Global.Merchants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Users
{
    public class UserGVM
    {
        public int? LineId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string RoleId { get; set; }
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

        public int? LoginAttempt { get; set; }
        public DateTime? LastLoginAttemptAt { get; set; }

        // added properties
        public IEnumerable<MerchantGVM>? Merchants { get; set; } = new List<MerchantGVM>();
        public IEnumerable<ModuleGVM>? RoleModuleAccess { get; set; } = new List<ModuleGVM>();

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string MerchantIds { get; set; }

        public List<string>? Tokens { get; set; } = new List<string>();

        //customized properties

        public string? NotHashPassword { get; set; }

        public string? AppUrl { get; set; }
    }
}
