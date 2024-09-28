using Common.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class PasswordSecurityProvider
    {
        private int _maximumSaltLength { get; } = 16;

        private int _minimumIterations { get; } = 5000;

        private int _maximumIterations { get; } = 10000;

        private int _maximumDataLength { get; } = 32;

        //public PasswordSecurityProvider(int maxSaltLength, int minimumIterations, int maximumIterations, int maximumDataLength)
        //{
        //    _maximumSaltLength = maxSaltLength;
        //    _minimumIterations = minimumIterations;
        //    _maximumIterations = maximumIterations;
        //    _maximumDataLength = maximumDataLength;
        //}

        private string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public (string HashedPassword, string Salt, int Iterations) SecurePassword(string password)
        {
            var salt = GenerateSalt(_maximumSaltLength);
            var rand = new Random(_minimumIterations);
            var iterations = rand.Next(_maximumIterations + 1);
            var hashedPassword = SecurePassword(password, salt, iterations).HashPassword;
            return (hashedPassword, salt, iterations);
        }

        public SecurePasswordDTO SecurePassword(string password, string salt, int iterations = 200)
        {
            try
            {
                byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

                using (var algorithm = new Rfc2898DeriveBytes(
                                           password,
                                           saltBytes,
                                           iterations,
                                           HashAlgorithmName.SHA256))
                {
                    var keySize = 32;
                    var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
                    var generatedSalt = Convert.ToBase64String(algorithm.Salt);

                    return new SecurePasswordDTO
                    {
                        IsSuccess = true,
                        HashPassword = $"{iterations}.{generatedSalt}.{key}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new SecurePasswordDTO();
            }
        }

        public bool IsValidPassword(string hashedPassword, string password, string salt, int iterations = 200)
        {
            var securedPassword = SecurePassword(password, salt, iterations).HashPassword;
            return hashedPassword == securedPassword;
        }
    }
}
