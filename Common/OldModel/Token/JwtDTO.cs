using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Token
{
    public record JwtDTO
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public JwtDTO(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

    }
}
