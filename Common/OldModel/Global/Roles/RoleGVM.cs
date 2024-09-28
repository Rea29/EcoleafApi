using Common.Constants;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace Common.Model.Global.Roles
{
    public class RoleGVM
    {
        public int? LineId { get; set; }

        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string RoleId { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		[MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
		[RegularExpression(RegEx.ALPHABET, ErrorMessage = DataAnnotations.RegexMessage.ALPHABETH)]
		public  string Name { get; set; } 

        public string? Description { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<ModuleGVM> RoleModuleAccess { get; set; } = new List<ModuleGVM>();

        // customized properties
        public int? ActiveUsers { get; set; } = 0;
    }

}
