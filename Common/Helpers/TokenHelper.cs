//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace Common.Helpers
//{
//    public static class TokenHelper
//    {

//        //public static string EncodeRS256(string key, Dictionary<string, object> payload)
//        //{
//        //    RSA rsa = RSA.Create();
//        //    int outReadBytes;
//        //    byte[] rsaPrivateKeyBytes = Convert.FromBase64String(key);
//        //    rsa.ImportPkcs8PrivateKey(rsaPrivateKeyBytes, out outReadBytes);
//        //    return Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS256);
//        //}

//        //public static string DecodeRS256(string token, string key)
//        //{
//        //    RSA rsa = RSA.Create();
//        //    int outReadBytes;
//        //    byte[] rsaPublicKeyBytes = Convert.FromBase64String(key);
//        //    rsa.ImportRSAPublicKey(rsaPublicKeyBytes, out outReadBytes);
//        //    return Jose.JWT.Decode(token, rsa, Jose.JwsAlgorithm.RS256);
//        //}

//    }
//}
