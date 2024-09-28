using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class ConvertListModelValueToLowerHelper
    {
        public static List<T> Convert<T>(List<T> originalList)
        {
            return originalList.Select(item =>
            {
                // Create a new instance of the model
                var newItem = Activator.CreateInstance<T>();
                // Copy properties to the new item
                foreach (var prop in typeof(T).GetProperties())
                {
                    var value = prop.GetValue(item);
                    if (prop.PropertyType == typeof(string))
                    {
                        // Convert to lowercase if it's a string
                        prop.SetValue(newItem, value?.ToString().ToLower());
                    }
                    else
                    {
                        // Copy other properties as is
                        prop.SetValue(newItem, value);
                    }
                }
                return newItem;
            }).ToList();
        }
    }
}
