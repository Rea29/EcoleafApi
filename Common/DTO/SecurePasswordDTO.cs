using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class SecurePasswordDTO
    {
        public string HashPassword { get; set; } = string.Empty;

        public bool IsSuccess { get; set; } = false;
    }
}
