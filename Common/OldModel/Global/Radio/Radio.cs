using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Radio
{
    public class Radio
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public bool IsOptional { get; set; } = false;
        public bool IsChecked { get; set; } = false;
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public bool IsDisabled { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool IsReadOnly { get; set; } = false;
        public string AdditionalClasses { get; set; } = ""; 
    }
}
