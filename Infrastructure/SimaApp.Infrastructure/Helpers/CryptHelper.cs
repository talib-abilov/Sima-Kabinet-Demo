using EllipticCurve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimaApp.Infrastructure.Helpers
{
    public class CryptHelper
    {
        public static string ComputeSha256(string rawData)
        {
            using var sha256Hash = SHA256.Create();
            var hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Convert.ToBase64String(hash);
        }
        public static byte[] ComputeSha256HashAsByte(string rawData)
        {
            using var sha256Hash = SHA256.Create();
            return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        }
        public static string ComputeHmacSha256(string data, string secretKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hashBytes);
        }

        public static byte[] ComputeHmacSha256(byte[] computedSha256AsByte, string key)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            return hmac.ComputeHash(computedSha256AsByte);
        }
        // public static byte[] SignECDSA(byte[] checksum, string secretKey)
        //{
        //    using ECDsa ecdsa = ECDsa.Create();

        //    ecdsa.ImportFromPem(secretKey);

        //    return ecdsa.SignData(checksum,HashAlgorithmName.SHA256);
        //}
    }
}
