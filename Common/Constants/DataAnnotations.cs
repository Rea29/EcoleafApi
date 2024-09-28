using Microsoft.VisualBasic;
using System.Numerics;

namespace Common.Constants
{
    public static class DataAnnotations
    {

        public static class RequiredFields
        {
            //public const string DEFAULT_MESSAGE = "This field is required.";
            public const string DEFAULT_MESSAGE = "Please provide information on the required fields.";
            
            public static class Login
            {
                public const string USERNAME = "Email or Username is required.";
                public const string PASSWORD = "Password is required.";
            }

            public static class User
            {
                public const string USERNAME = "Username is required.";
                public const string FIRSTNAME = "First Name is required.";
                public const string LASTNAME = "Last Name is required.";
            }

            public static class ResetAndForgotPassword
            {
                public const string CONTACT_REQUIRED = "Contact is required.";
                public const string PHONE_NUMBER_REQUIRED = "Phone Number is required.";
                public const string EMAIL_ADDRESS_REQUIRED = "Email Address is required.";
                public const string PHONE_EMAIL_ADDRESS_REQUIRED = "Phone Number or Email Address is required.";
                public const string CURRENT_PASSWORD = "Current Password is required.";
                public const string NEW_PASSWORD = "New Password is required.";
                public const string CONFIRM_PASSWORD = "Confirm Password is required.";
            }

            public static class Date
            {
                public const string START_DATE = "Start Date is required.";
                public const string END_DATE = "End Date is required.";
                public const string ACCESS_VALIDITY_FROM = "Access Validity From is required.";
                public const string ACCESS_VALIDITY_TO = "Access Validity To is required.";
                public const string BIRTHDAY = "Birthday is required.";
            }

            public static class Shared
            {
                public const string EMAIL = "Email is required.";
                public const string MOBILE_NUMBER = "Mobile Number is required.";
            }
        }

        public static class MinMaxCharacterLimit
        {
            public const string EIGHT_TO_TWELVE_CHAR_LIMIT = "This field's length should be from 8 to 12.";
        }

        public static class MinCharacterLimit
        {
            public const string EIGHT_CHAR_LIMIT = "This field's min length is 8.";
            public const string TEN_CHAR_LIMIT = "This field's min length is 10.";
        }

        public static class MaxCharacterLimit
        {
            public const string ONE_CHAR_LIMIT = "This field's max length is 1 only.";
            public const string THREE_CHAR_LIMIT = "This field's max length is 3 only.";
            public const string TEN_CHAR_LIMIT = "This field's max length is 10 only.";
            public const string TWELVE_CHAR_LIMIT = "This field's max length is 12 only.";
            public const string FIFTEEN_CHAR_LIMIT = "This field's max length is 15 only.";
            public const string THIRTEEN_CHAR_LIMIT = "This field's max length is 13 only.";
            public const string TWENTY_CHAR_LIMIT = "This field's max length is 20 only.";
            public const string TWENTY_FIVE_CHAR_LIMIT = "This field's max length is 25 only";
            public const string FIFTY_CHAR_LIMIT = "Max 50 characters allowed";
            public const string ONE_HUNDRED_CHAR_LIMIT = "This field's max length is 100 only.";
            public const string TWO_HUNDRED_CHAR_LIMIT = "This field's max length is 200 only.";
            public const string ONE_HUNDRED_FIFTY_CHAR_LIMIT = "This field's max length is 150 only";
            public const string TWO_HUNDRED_FIFTY_CHAR_LIMIT = "This field's max length is 250 only";
            public const string FIVE_THOUSAND_CHAR_LIMIT = "This field's max length is 5000 only.";
            public const string CHAR_LIMIT_670 = "This field's max length is 670 only.";
            public const string CHAR_LIMIT_672 = "This field's max length is 672 only.";
        }

        public static class InputRange
        {
            public const string PRICE_RANGE = "Allowed values are 1.00 up to 1,000,000.00 only.";
            public const string QUANTITY_RANGE = "Allowed values are 0 up to 999,999 only.";
            public const string VOUCHER_QUANTITY_RANGE = "Allowed values are 1 up to 1,000,000 only.";
            public const string RETURN_DAYS_RANGE = "Allowed values are 0 up to 7 only.";
            public const string USAGE_LIMIT = "Allowed values are 1 up to 5 only.";
            public const string VOUCHER_PERCENTAGE_RANGE = "Allowed values are 5 up to 95 only.";
            public const string VOUCHER_AMOUNT_RANGE = "Allowed values are 50.00 up to 9999.00 only.";
            public const string REQUIRED_ORDER_TOTAL_RANGE = "Allowed values are 50 up to 1,000,000 only.";
            public const string ORDER_TOTAL_CAP_RANGE = "Allowed values are 50 up to 1,000,000 only.";
            public const string PRODUCT_METRIC_RANGE = "Allowed values are 0.01 up to 100.00 only.";
            public const string PACKAGE_DETAILS_RANGE = "Allowed values are 0.01 up to 10,000.00 only.";
        }

        public static class RegexMessage
        {
            public const string ONLYWEBSITE = "Only letters, numbers and dots are allowed.";
            public const string ONLYlETTERSNUMBERS = "Only letters and numbers are allowed.";
            public const string ONLYNUMBERS = "Only numbers are allowed.";
            public const string ALPHANUMERIC = "This field is for alphanumeric characters only.";
            public const string NUMERIC = "This field is for numeric characters only.";
            public const string ALPHABETH = "Only letters are allowed";
            public const string NUMERIC_DECIMAL = "This field is for numeric characters, including decimals, and negative values are not allowed.";
            public const string NO_NUMERIC = "This field is for letter characters and symbols only.";
        }

        public static class InvalidFormat
        {
            public const string EMAIL_FORMAT = "The Email format is not valid.";
            public const string PASSWORD = "The Password format is not valid.";
            public const string PHONE_NUMBER_FORMAT = "The Phone Number format is not valid.";
            public const string PHONE_EMAIL_NUMBER_FORMAT = "The Phone Number or Email format is not valid.";
            public const string TIN_FORMAT = "The TIN Number format is not valid.";

        }

        public static class InvalidPassword
        {
            public const string PASSWORD_NOT_MATCH = "New Password and Confirm Password did not match.";
            public const string PASSWORD_REGEX = "New Password must contain 8-12 characters, atleast 1 upper case, 1 number and 1 special character.";
        }

        public static class PossitiveNumbersOnly
        {
            public const string POSITIVE_NUMBERS = "Kindly input positive numbers only.";
        }

        public static class ResetPassword
        {

            public const string NEW_PASSWORD = "New Password is required.";
            public const string CONFIRM_PASSWORD = "Confirm Password is required.";
            public const string PASSWORD_REGEX = "New Password must contain 8-12 characters, atleast 1 upper case, 1 number and 1 special character.";
            public const string PASSWORD_NOT_MATCH = "New Password and Confirm Password did not match.";
        }

        public static class FileValidation
        {

            public const string FILENAME_TOO_LONG = "Filename is too long. Maximum of 200 characters.";
            public const string FILE_TOO_LARGE = "Image file too large. Maximum image size: 1 MB.";
            public const string UNSUPPORTED_FILE_TYPE = "Unsupported file type. Supported file types are: JPG, JPEG, PNG, SVG.";
        }

    }
}
