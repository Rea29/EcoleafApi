using Common.Constants;
using Common.Model.Global.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Subcategories
{
    public class SubcategoryGVM
    {
        public int? LineId { get; set; }
        [Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        public string? CategoryId { get; set; }
        public string? ParentCategoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
        [MaxLength(50, ErrorMessage = DataAnnotations.MaxCharacterLimit.FIFTY_CHAR_LIMIT)]
        public string? CategoryName { get; set; }


        //[SupportedImageFile(ErrorMessage = DataAnnotations.FileValidation.UNSUPPORTED_FILE_TYPE)]
        [FileSize(0, 1, ErrorMessage = DataAnnotations.FileValidation.FILE_TOO_LARGE)]
        public IFile? CategoryImageFile { get; set; }
        public string? CategoryImageFileUrl { get; set; }
        [MaxLength(200, ErrorMessage = DataAnnotations.FileValidation.FILENAME_TOO_LONG)]
        public string? CategoryImageFileName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedAt { get; set; }
        public int? Level { get; set; }
        public List<CategoryGVM>? SubCategories { get; set; } = new List<CategoryGVM>();
    }
}
