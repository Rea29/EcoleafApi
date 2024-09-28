using Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string _dependentProperty { get; set; }
        public object _targetValue { get; set; }
        public string _errorMessage { get; set; }

        public RequiredIfAttribute(string dependentProperty, object targetValue, string errorMessage)
        {
            this._dependentProperty = dependentProperty;
            this._targetValue = targetValue;
            this._errorMessage = errorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (_targetValue is string)
            {
                var v = Convert.ToString(_targetValue);
                var values = v.Split("|");

                var field = validationContext.ObjectType.GetProperty(_dependentProperty);
                if (field != null)
                {
                    foreach (var s in values)
                    {
                        var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                        if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(s)))
                        {
                            if (!_innerAttribute.IsValid(value))
                            {
                                string name = validationContext.DisplayName;
                                return new ValidationResult(_errorMessage);
                            }
                        }
                    }
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(FormatErrorMessage(_dependentProperty));
                }

            }
            else
            {
                var field = validationContext.ObjectType.GetProperty(_dependentProperty);
                if (field != null)
                {
                    var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                    if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
                    {
                        if (!_innerAttribute.IsValid(value))
                        {
                            string name = validationContext.DisplayName;
                            return new ValidationResult(_errorMessage);
                        }
                    }
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(FormatErrorMessage(_dependentProperty));
                }
            }


        }
    }
}
