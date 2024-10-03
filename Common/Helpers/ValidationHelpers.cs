using Common.Model.Global;
using Common.Model.Global.Roles;
using HotChocolate;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static HotChocolate.ErrorCodes;

namespace Common.Helpers
{
    public static class ValidationHelpers
    {
        public static bool NotEmpty(this object field)
        {
            if (field is string)
            {
                var aString = field as string;
                return string.IsNullOrEmpty(aString) ||
                       string.IsNullOrWhiteSpace(aString) ? false : true;
            }

            return field != null
                    ? true : false;
        }

        public static bool IsRegexValid(this string field, string regex)
        {
            return Regex.IsMatch(field, regex) ? true : false;
        }
    }

    public class ValidateInput
    {
        public List<CutomModelErrorResponseGVM> CustomError { get; set; }
        public IEnumerable<IError> GraphQLError { get; set; }

        public ValidateInput()
        {
        }

        public List<IError> ValidateModelData(object data)
        {
            var context = new ValidationContext(data);
            var validationErrors = new List<ValidationResult>();

            Validator.TryValidateObject(data, context, validationErrors, true);

            var res = validationErrors.Select(error =>
                   ErrorBuilder.New()
                                .SetExtension("fieldName", error.MemberNames.Select(a => StringHelper.FirstCharToLower(a)).FirstOrDefault())
                               .SetMessage(error.ErrorMessage)
                               .Build()).ToList();

            return res;
        }

        public List<CutomModelErrorResponseGVM> ValidateModelDataV2(object data)
        {
            var context = new ValidationContext(data);
            var validationErrors = new List<ValidationResult>();

            Validator.TryValidateObject(data, context, validationErrors, true);

            var res = new List<CutomModelErrorResponseGVM>();

            //Get All Field Names
            foreach (var i in validationErrors.Select(a => a.MemberNames))
            {
                foreach (var ia in i)
                {
                    if (!res.Any(a => a.FieldName == ia))
                    {
                        res.Add(new CutomModelErrorResponseGVM() { FieldName = ia, FieldError = new List<string>() });
                    }
                }
            }

            foreach (var i in res)
            {
                var tempErr = validationErrors.Where(a => a.MemberNames.Contains(i.FieldName)).Select(b => b.ErrorMessage);
                foreach (var ia in tempErr)
                {
                    i.FieldError.Add(String.IsNullOrEmpty(ia) ? "" : ia);
                }
            }

            return res;
        }


        public void ValidateModelDataV3(object data)
        {
            var context = new ValidationContext(data);
            var validationErrors = new List<ValidationResult>();

            Validator.TryValidateObject(data, context, validationErrors, true);

            var res = validationErrors.Select(error =>
                   ErrorBuilder.New()
                                .SetExtension("fieldName", error.MemberNames.Select(a => StringHelper.FirstCharToLower(a)).FirstOrDefault())
                               .SetMessage(error.ErrorMessage)
                               .Build()).ToList();

            if (res is not null)
            {
                GraphQLError = res;
            }

            var res2 = new List<CutomModelErrorResponseGVM>();
            //Get All Field Names
            foreach (var i in validationErrors.Select(a => a.MemberNames))
            {
                foreach (var ia in i)
                {
                    if (!res2.Any(a => a.FieldName == ia))
                    {
                        res2.Add(new CutomModelErrorResponseGVM() { FieldName = ia, FieldError = new List<string>() });
                    }
                }
            }

            foreach (var i in res2)
            {
                var tempErr = validationErrors.Where(a => a.MemberNames.Contains(i.FieldName)).Select(b => b.ErrorMessage);
                foreach (var ia in tempErr)
                {
                    i.FieldError.Add(String.IsNullOrEmpty(ia) ? "" : ia);
                }
            }

            if (res2.Count > 0)
            {
                CustomError = res2;
            }
        }

        //ref List<CutomModelErrorResponseGVM> data, 
        public void AddCustomModelErrorResponseGVM(string fieldName, List<string> fieldErrors)
        {
            // Handle null reference for data
            //if (data == null)
            //{
            //    data = new List<CutomModelErrorResponseGVM>();
            //}

            //var data = new List<CutomModelErrorResponseGVM>();

            if (CustomError == null)
            {
                CustomError = new List<CutomModelErrorResponseGVM>();
            }



            var newData = new CutomModelErrorResponseGVM();
            newData.FieldName = fieldName;

            // Null check for fieldErrors before adding to FieldError
            if (fieldErrors != null)
            {
                newData.FieldError = fieldErrors;
            }

            // Find existing CustomModelErrorResponseGVM with the same fieldName
            var existingData = CustomError.ToList().Find(a => a.FieldName == fieldName);

            if (existingData != null)
            {
                // Add fieldErrors to the existing CustomModelErrorResponseGVM
                existingData.FieldError.AddRange(fieldErrors);
            }
            else
            {
                // Add newData to the list
                CustomError.Add(newData);
            }
        }

        //List<CutomModelErrorResponseGVM> data,
        public void ProcessCustomModelErrorResponseGVM(string ErrorMessageHeader)
        {
            
                var ErrList = new List<IError>();

                if (CustomError != null && CustomError.Count > 0)
                {
                    foreach (var i in CustomError)
                    {
                        foreach (var ia in i.FieldError)
                        {
                            var errorBuilder = ErrorBuilder.New();
                            errorBuilder.SetMessage(ia);
                            errorBuilder.SetExtension("fieldName", StringHelper.FirstCharToLower(i.FieldName));
                            ErrList.Add(errorBuilder.Build());
                        }

                    }

                //throw new GraphQLException(ErrList);
                throw new GraphQLException(ErrList);
            }


        }

    }
}
