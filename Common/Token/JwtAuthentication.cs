using Common.DTO.HumanResourceManagement;
using Common.DTO.Users;
using Common.Model.Global.Users;
using Common.Model.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Token
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly IConfiguration _config;

        private readonly ILogger<JwtAuthentication> _log;

        public JwtRequirements Jwt { get; private set; }

        private const string Section = "JwtRequirements";


        public JwtAuthentication(IConfiguration config, ILogger<JwtAuthentication> log)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public JwtDTO GenerateJwtToken(UserDTO user)
        {
            try
            {
                //_log.LogInformation($"Generate token with the details of {user.Username}, {user.UserUID} and {user.RoleName}");

                var jwt = _config.GetSection(Section)
                                .GetChildren()
                                .ToArray();

                Jwt = new JwtRequirements(issuer: jwt[1].Value,
                                       audience: jwt[0].Value,
                                       key: jwt[2].Value);

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Jwt.Key));
                var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);


                var expirationDate = DateTime.Now.AddDays(1);

                if (Int32.TryParse(jwt[3].Value, out int expiration))
                {
                    expirationDate = DateTime.Now.AddMinutes(expiration);
                }

                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserUID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.PrimarySid, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.Name, user.FirstName),
                    //new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role, (!string.IsNullOrEmpty(user.RoleName)) ? user.RoleName : "GUEST" ),
                    new Claim(ClaimTypes.Expiration, expirationDate.ToString())
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = expirationDate,
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var writeToken = tokenHandler.WriteToken(token);


                if (string.IsNullOrEmpty(writeToken))
                {
                    //_log.LogError($"Failed to generate token with the details of {user.Username}, {user.UserId} and {user.RoleName}");

                    throw new ArgumentNullException("Token failed to generate.");
                }

                return new JwtDTO(writeToken, GenerateRefreshToken);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private string GenerateRefreshToken
        {
            get
            {
                this._log.LogInformation("Generate a refresh token.");

                var randomNumber = new byte[32];
                using (var generate = RandomNumberGenerator.Create())
                {
                    generate.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }
        }
    }
}
