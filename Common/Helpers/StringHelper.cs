using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class StringHelper
    {
        public static string FirstCharToLower(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToLower(input[0]) + input.Substring(1);
        }
        public static string HTMLClassFormatter(List<string>? input)
        {
			StringBuilder formattedClasses = new StringBuilder();
			string spacer = "";
            if (input != null)
            {
                foreach (string class_ in input)
                {
                    formattedClasses.Append(spacer);
                    formattedClasses.Append(class_);
                    spacer = " ";
                }
            }
            return formattedClasses.ToString();
		}

        public static string GenerateRandomString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            char[] str = new char[length];

            for (int i = 0; i < length; i++)
            {
                str[i] = chars[random.Next(chars.Length)];
            }

            return new string(str);
        }
    }
}
