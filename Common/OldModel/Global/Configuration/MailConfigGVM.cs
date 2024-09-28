using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Configuration
{
    public class MailConfigGVM
    {
        public string SMTP { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; } = 0;
        public bool IsSsl { get; set; } = false;
    }
}
