using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;


        public FileSizeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object value)
        {
            if (value is not null)
            {
                var fileSize = value.GetType().GetProperty("Length").GetValue(value, null);
                //string strValue = value as string;

                int maxFileSize = _max * 1024 * 1024;

                if (Convert.ToInt32(fileSize) > 0)
                {

                    return Convert.ToInt32(fileSize) <= maxFileSize;
                }

            }
              

            return true;
        }
    }
    //public class SupportedImageFileAttribute : ValidationAttribute
    //{

     

    //    public override bool IsValid(object value)
    //    {
    //        //string strValue = value as string;
    //        if(value is not null)
    //        {
    //            var ContentType = value.GetType().GetProperty("ContentType").GetValue(value, null);
    //            string[] imageType = ContentType.ToString().Split('/');
    //            if (!string.IsNullOrEmpty(imageType[1]))
    //            {
    //                bool res = new string[] { "jpg", "jpeg", "png", "svg" }.Contains(imageType[1].ToString().ToLower());
    //                return res;
    //            }
    //        }
          

    //        return true;
    //    }
    //}
}
