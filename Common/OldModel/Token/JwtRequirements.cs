using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Token
{
    public record JwtRequirements
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }


        public string Key { get; set; }

        public JwtRequirements(string issuer, string audience, string key)
        {
            Issuer = issuer;
            Audience = audience;
            Key = key;
        }
    }
}
