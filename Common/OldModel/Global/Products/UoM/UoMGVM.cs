using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Products.UoM
{
    public class UoMGVM
    {
        public int? LineId { get; set; }
        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? UoMId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHABET_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ALPHANUMERIC)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? UoMName { get; set; }
        [RegularExpression(RegEx.ALPHABET_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ALPHANUMERIC)]
        [MaxLength(3, ErrorMessage = DataAnnotations.MaxCharacterLimit.THREE_CHAR_LIMIT)]
        public string? UoMShortDescription { get; set; }
        [RegularExpression(RegEx.ALPHABET_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ALPHANUMERIC)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? UoMLongDescription { get; set; }
        public string? UoMStatus { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
