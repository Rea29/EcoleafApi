namespace Common.Constants
{
    public static class RegEx
    {
        public const string ALPHANUMERIC_WITH_SPACE = @"^[a-zA-Z0-9\s]+$";
        public const string ALPHANUMERIC_WITHOUT_SPACE = @"^[a-zA-Z0-9]+$";
        public const string ALPHANUMERIC_WITH_DASH = @"^[0-9A-Za-z\s\-]+$";
        public const string NUMERIC = @"^[0-9]*$";
        public const string PHONE_NUMBER = @"^(9)\d{9}$";
        public const string EMAIL = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string ALPHABET = @"^[a-zA-Z ]+$";
        public const string ALPHABET_WITH_SPACE = @"^[a-zA-Z\s]+$";
        public const string ALPHABET_WITH_SPACE_N_DASH = @"^[a-zA-Z\s\-]+$";
        public const string PRODUCT_PRICE = @"^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$";
        public const string NUMERIC_DECIMAL = @"^\d*\.?\d+$";
        public const string NO_NUMERIC = @"^[^\d()]+$";
        public const string NUMERIC_WITH_NEGATIVE_NUM = @"^-?[0-9]\d*(\.\d+)?$";
        public const string WEBSITE = @"^[A-Za-z0-9_.,/?@&=+$!~*'()-]*$";
        public const string WEBSITE_WITH_SEMICOLON = @"^[A-Za-z0-9_.,/:;?@&=+$!~*'()-]*$";


        public const string EMAIL_WITH_N_SpecialCharacter = @"^([\w\.\-\u00f1\u00d1]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string ALPHABET_WITH_N_SpecialCharacter = @"^[a-zA-Z \u00f1\u00d1]+$";
        public const string ALPHANUMERIC_WITH_SPACE_WITH_N_SpecialCharacter = @"^[a-zA-Z0-9\s\u00f1\u00d1]+$";
        public const string ALPHANUMERIC_WITHOUT_SPACE_WITH_SPACE_WITH_N_SpecialCharacter = @"^[a-zA-Z0-9\u00f1\u00d1]+$";
        public const string ALPHANUMERIC_WITH_DASH_WITH_N_SpecialCharacter = @"^[0-9A-Za-z\s\-\u00f1\u00d1]+$";

        public const string RegExContactNo = @"^[0-9]{10,11}$";
        public const string RegExBankAccountNo = @"^[0-9]{1,50}$";
        public const string RegExBusinessTIN = @"^\d{3}-\d{3}-\d{3}-\d{3}$";
        public const string RegExTenDigitNumber = @"^[0-9]{10}$";
        public const string RegExZipCode = @"^[0-9]{4}$";
        public const string RegExPhilippinePhoneNumber = @"^(\+639)\d{9}$";
        public const string RegExPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,12}$";
        // bak:  @"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}\p{Pd}]+)*@([\w\-]+)((\.(\w){2,3})+)$";
        // bak2: @"^\w+([.-]?\w+)*@\w+([\w]?\w+)*(\.\w{2,})+$
        public const string RegExValidEmail = @"^([\w-]|(?<!\.)\.)+[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9\-]+)((\.([a-zA-Z]){2,9}){0,2})";
        public const string RegExValidPhNumberOrEmail = @"^(?:(^(\+639)\d{9}$)|(^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)))$";
        public const string RegExNoSpecialCharacterAndNumber = @"^[a-zA-Z_. ]*$";
        public const string RegExAlphaNumericWithHypen = @"^[a-zA-Z0-9-]+$";

	}
}
