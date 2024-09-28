using System;
using System.ComponentModel;
using System.Linq;

namespace Common.Helpers
{
    public static class EnumDescription
    {
        public static string GetEnumDescription(this Enum value)
        {
            var attributes = value.GetType()
                                  .GetField(value.ToString())
                                  .GetCustomAttributes(typeof(DescriptionAttribute), false) 
                                    as DescriptionAttribute[];

            return attributes is not null && attributes.Any() ? 
                   attributes.FirstOrDefault().Description : 
                   value.ToString();
        }


    }
}
