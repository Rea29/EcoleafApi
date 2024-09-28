using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Common.Constants
{
    /// <summary>
    /// This codes contains specific messages according to their functionalities and services.
    /// The codes are distinguished using 6 digit numbers according to their services.
    /// Below you will see an example for the codes and their services.
    /// Example:
    ///     - 10XXXX = User Service
    ///         -10X4XX - Bad errors
    ///         -10X5XX - Server errors
    ///     - 20XXXX = Seller Service
    ///         -20X4XX - Bad errors
    ///         -20X5XX - Server errors       
    ///     - 30XXXX = Payment Service 
    ///         -30X4XX - Bad errors
    ///         -30X5XX - Server errors   
    /// </summary>
    public sealed class StandardE2DCodes
    {

        private Dictionary<int, string> Codes { get; set; }

        public StandardE2DCodes()
        {
            Codes = new Dictionary<int, string>();
            Codes.Add(103001, "Password and confirm password did not match.");
            Codes.Add(103002, "");
            Codes.Add(103001, "Password and confirm password did not match.");

            Codes.Add(104010, "The verification code does not exist or invalid username");
            Codes.Add(104011, "The verification code is already been used");
            Codes.Add(104012, "The previous verification code can not be used");
            Codes.Add(104013, "You have entered an expired code. Please request for a new one");
            Codes.Add(104014, "Please provide the new contact email or phone number");

        }


        public IEnumerable<KeyValuePair<int, string>> UserServiceStandardCode(int idCode)
        {
            Codes.Where(x => x.Key == idCode);
            return Codes;
        }


    }
}
