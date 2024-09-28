using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
	public class ValidateAgeRangeAttribute : ValidationAttribute
	{
		private readonly int _minAge;
		private readonly int _maxAge;

		public ValidateAgeRangeAttribute(int minAge, int maxAge)
		{
			_minAge = minAge;
			_maxAge = maxAge;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value is DateTime dateOfBirth)
			{
				int age = DateTime.Today.Year - dateOfBirth.Year;

				if (dateOfBirth > DateTime.Today.AddYears(-age))
				{
					age--;
				}

				if (age < _minAge || age > _maxAge)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
