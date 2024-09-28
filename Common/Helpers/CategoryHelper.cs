using Common.Model.Global.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Constants.StoredProcedures;

namespace Common.Helpers
{
    public class CategoryHelper
    {
        public static List<CategoryGVM> GetStructuredArray(List<CategoryGVM> categories)
        {
            var structuredArray = new List<CategoryGVM>();

            foreach (var category in categories)
            {
                

                structuredArray.Add(category);
            }

            return structuredArray;
        }
    }

}
