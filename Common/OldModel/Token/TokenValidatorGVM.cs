using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Token
{
    public record TokenValidatorGVM
    {
        public string UserID { get; set; }
        public string Token { get; set; }

    }
}
