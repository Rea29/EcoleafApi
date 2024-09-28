using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constants;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;

namespace Common.Model.Global.Brands
{
	public class BrandGVM
	{
		///[GraphQLType(typeof(NonNullType<UploadType>))]
		///
		[Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		public string MerchantId { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		public string BrandId { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		[MaxLength(length: 100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
		public string BrandName { get; set; }

		public IFile? BrandLogoFile { get; set; }
		[GraphQLIgnore]
		public IFormFile? BrandLogo { get; set; }
		public string? LogoFileUrl { get; set; }
		public string? LogoFileName { get; set; }

		[MaxLength(length: 100, ErrorMessage = DataAnnotations.MaxCharacterLimit.ONE_HUNDRED_CHAR_LIMIT)]
		public string? Manufacturer { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		public bool IsActive { get; set; }

		[Required(ErrorMessage = DataAnnotations.RequiredFields.DEFAULT_MESSAGE)]
		public string? CreatedBy { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string? UpdatedBy { get; set; } = string.Empty;
		public DateTime? UpdatedAt { get; set; }
	}
}
