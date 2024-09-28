using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class RangeIf : ValidationAttribute
    {
        public string _dependentProperty { get; set; }
        public string _dependentValue { get; set; } = string.Empty;
        public double _Minimum { get; set; }
        public double _Maximum { get; set; }
        public string _errorMessage { get; set; }

        public RangeIf(string dependentProperty, string dependentValue, double minimum, double maximum, string errorMessage)
        {
            this._dependentProperty = dependentProperty;
            this._dependentValue = dependentValue;
            this._Minimum = minimum;
            this._Maximum = maximum;
            this._errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(_dependentProperty);

            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                if (dependentValue.Equals(_dependentValue))
                {
                    if (Convert.ToDouble(value) >= _Minimum && Convert.ToDouble(value) <= _Maximum)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(_errorMessage);
                    }
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage("Dependent field not found."));
        }
    }
}
