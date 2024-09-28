﻿using Common.Constants;
using Common.Model.Global.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Merchants
{
    public class MerchantBranchGVM
    {

        public int? LineId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string MerchantBranchId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string MerchantId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string Merchant { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string BranchName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string BranchAddress { get; set; }

        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
        public string? Building { get; set; }

        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? Floor { get; set; }

        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.NUMERIC)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string? StallNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ALPHANUMERIC)]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string CityId { get; set; }
        public string? CityName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string BarangayId { get; set; }
        public string? BarangayName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.ONLYNUMBERS)]
        [MaxLength(10, ErrorMessage = DataAnnotations.MaxCharacterLimit.TEN_CHAR_LIMIT)]
        public string ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string CountryId { get; set; }
        public string? CountryName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.NUMERIC, ErrorMessage = DataAnnotations.RegexMessage.NUMERIC)]
        [MaxLength(15, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTEEN_CHAR_LIMIT)]
        public string BranchContactNumber { get; set; }

       
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }


    }
}
