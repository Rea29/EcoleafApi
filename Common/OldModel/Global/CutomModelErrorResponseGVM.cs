using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global
{
    public class CutomModelErrorResponseGVM
    {
        public string FieldName { get; set; } = string.Empty;
        public List<string> FieldError { get; set; } = new List<string>();
    }
}
