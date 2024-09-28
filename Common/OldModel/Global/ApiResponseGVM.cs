
using System.Runtime.CompilerServices;

namespace Common.ViewModels
{
    public class ApiResponseGVM 
    {
        public bool IsSuccessful { get; set; }

        private bool deviceIdExist;
        public bool IsLogin {
            get { return deviceIdExist; } 
            set { deviceIdExist = value ? false : true; } 
        }

        public string FieldName { get; set; }
        
        public string Message { get; set; }
        
        public int StatusCode { get; set; }

        public string ResponseString { get; set; }

        public object ResponseObject { get; set; }

        public object Data { get; set; }

        public object Errors { get; set; }

        public ApiResponseGVM(string fieldName,
            string message,
            int statusCode,
            bool isSuccessful,
            string responseObject = "")
        {
            FieldName = fieldName;
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            ResponseObject = responseObject;
        }

        public ApiResponseGVM(
          string message,
          int statusCode,
          bool isSuccessful,
          object data = null,
          object errors = null)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            ResponseObject = data;
            Errors = errors;
        }

        public ApiResponseGVM(
         string message,
         int statusCode,
         bool isSuccessful,
         bool isLogin = true,
         object data = null)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            IsLogin = isLogin;
            ResponseObject = data;
        }

        public ApiResponseGVM(
          string message,
          int statusCode,
          bool isSuccessful)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
        }

        public ApiResponseGVM()
        {
        }
    }
}
