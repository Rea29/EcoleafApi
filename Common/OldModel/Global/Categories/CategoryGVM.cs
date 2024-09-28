using Common.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Constants.StoredProcedures;
using HotChocolate.Data;
using Common.Model.FilterTypes;

namespace Common.Model.Global.Categories
{
    public class CategoryGVM
    {
        public int? LineId { get; set; }
        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? CategoryId { get; set; }
        public string? ParentCategoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [RegularExpression(RegEx.ALPHANUMERIC_WITH_SPACE, ErrorMessage = DataAnnotations.RegexMessage.ONLYlETTERSNUMBERS)]
        [MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
        public string? CategoryName { get; set; }


        //[SupportedImageFile( ErrorMessage = DataAnnotations.FileValidation.UNSUPPORTED_FILE_TYPE)]
        [FileSize( 0,1, ErrorMessage = DataAnnotations.FileValidation.FILE_TOO_LARGE)]
        public IFile? CategoryImageFile { get; set; }

        [GraphQLIgnore]
        public IFormFile? CategoryImage { get; set; }
        public string? CategoryImageFileUrl { get; set; }
        [MaxLength(200, ErrorMessage = DataAnnotations.FileValidation.FILENAME_TOO_LONG)]
        public string? CategoryImageFileName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Level { get; set; }

        //[UseFiltering<SubCategoryFilterType>]
        public List<SubCategoryGVM>? SubCategories { get; set; }

    }

    public class SubCategoryGVM : CategoryGVM
    {

    }
}
