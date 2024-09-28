
namespace Common.Constants
{
    public static class ApiResponseMessage
    {
        public const string FIELDREQUIREDMESSAGE = "This field is required";
        public const string SUCCESS = "Success";
        public const string CREATED = "Created";
        public const string UPDATED = "Updated";
        public const string DELETED = "Deleted";
        public const string ACCEPTED = "Accepted";

        public static class InvalidPassword
        {
            public const string PASSWORD_FORMAT = "The Password format is not valid.";
            public const string PASSWORD_CHARACTER_LIMIT = "Password must be 8-12 characters.";
            public const string PASSWORD_NOT_MATCH = "New Password and Confirm Password did not match.";
        }

        public static class Exceptions
        {
            public const string INTERNAL_SERVER_MESSAGE = "An error occur. Please contact service administrator.";
            public const string UNPROCESSABLE_ENTITIES = "Unprocessable Entity";
            public const string BAD_REQUEST = "Bad Request";
            public const string NOT_FOUND = "Not found";
            public const string UNAUTHORIZED = "Unauthorized";
            public const string LOGIN_FAILED_ATTEMPT_3_TIMES = "You have reached the maximum login attempts, you may login after 30 minutes.";
            public const string INVALID_USERNAME_OR_PASSWORD = "Invalid Username or Password.";
            public const string EXPIRED_ACCOUNT = "Your account already expired, please contact system administrator.";
            public const string GOOGLE_CAPTCHA_ERROR = "Error validating Google Captcha, please try again if error persists contact system administrator";
            public const string INCORRECT_PASSWORD = "Incorrect Password";
            public const string USERALREADYLOGGEDIN = "User Already Logged in";
        }
    }
}
