using Common.Constants;
using Common.Model.Global.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Constants.StoredProcedures;

namespace Common.Model.Global.Products.Suppliers
{
    public class SupplierGVM
    {
        public int? LineId { get; set; }
        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? SupplierId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? SupplierName { get; set; }
        [RegularExpression(RegEx.WEBSITE_WITH_SEMICOLON, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? Website { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? SupplierDescription { get; set; }
        
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.ONLYNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? ContactNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        public string? ContactPerson { get; set; }

        [RegularExpression(RegEx.RegExBusinessTIN, ErrorMessage = DataAnnotations.InvalidFormat.TIN_FORMAT)]
        public string? TINNumber { get; set; }
        [RegularExpression(RegEx.RegExValidEmail, ErrorMessage = DataAnnotations.InvalidFormat.EMAIL_FORMAT)]
        public string? EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? BusinessAddress { get; set; }

        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? Building { get; set; }

        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? Floor { get; set; }

        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.ONLYNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? StallNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
        public string? Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? CityId { get; set; }
        public string? CityName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? BarangayId { get; set; }
        public string? BarangayName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.ONLYNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
