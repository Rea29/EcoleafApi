namespace Common.Constants
{
    public static class Constants
    {
        public static class Keys
        {
            public const string RecaptchaSiteKey = "6LfpJgcaAAAAAJobkHHXTgYdXfXK4gnbnALtVzwG";

        }

        public static class Regex
        {
            public const string RegExNumeric = @"^[0-9]*$";
            public const string RegExContactNo = @"^[0-9]{10,11}$";
            public const string RegExBankAccountNo = @"^[0-9]{1,50}$";
            public const string RegExBusinessTIN = @"^\d{3}-\d{3}-\d{3}-\d{3}$";
            public const string RegExTenDigitNumber = @"^[0-9]{10}$";
            public const string RegExZipCode = @"^[0-9]{4}$";
            public const string RegExPhilippinePhoneNumber = @"^(\+639)\d{9}$";
            public const string RegExPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$";
            public const string RegExValidEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            public const string RegExNoSpecialCharacterAndNumber = @"^[a-zA-Z\-\s]*$";
        }

        public static class CommonVariables
        {
            public const string Caps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string Numeric = "1234567890";
            public const string Special = "!#$%&'()*+,-./:;<=>?@[]^_`{|}~";

            public const string Action = "action";
        }


    }
}
