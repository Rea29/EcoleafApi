
namespace Common.ViewModels
{
    public class CustomModelResponse
    {
        public CustomModelResponse(
            string fieldName,
            string message,
            int statusCode,
            bool isSuccessful,
            string reponseString = "")
        {
            FieldName = fieldName;
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            ResponseString = reponseString;
        }


        public CustomModelResponse(string message,
            int statusCode,
            bool isSuccessful,
            object data = null,
            object errors = null)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            Data = data;
            Errors = errors;
        }

        public CustomModelResponse(string message,
           int statusCode,
           bool isSuccessful,
           bool isLogin)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            IsLogin = isLogin;
        }

        public CustomModelResponse(string message, int statusCode, bool isSuccessful)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
        }

        public CustomModelResponse(string message, int statusCode, bool isSuccessful, string createdIdResult)
        {
            Message = message;
            StatusCode = statusCode;
            IsSuccessful = isSuccessful;
            CreatedIdResult = createdIdResult;
        }

        public bool IsSuccessful { get; set; }

        public bool IsLogin { get; set; }

        public string FieldName { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public string ResponseString { get; set; }

        public object Data { get; set; }

        public object Errors { get; set; }

        public string CreatedIdResult { get; set; }

    }
}
