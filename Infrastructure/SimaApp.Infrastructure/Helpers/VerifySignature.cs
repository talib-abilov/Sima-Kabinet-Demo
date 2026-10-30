using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Helpers
{
    public class VerifySignature
    {
        public static async Task<bool> VerifyAsync(string body,string cert,string sign,string alg)
        {
            byte[] certificateBytes = Convert.FromBase64String(cert);

            var certParser = new X509CertificateParser();
            var certificate = certParser.ReadCertificate(certificateBytes);

            var signAlg = alg switch
            {
                "ECDSA_SHA256" => "SHA-256withECDSA",

                _ => throw new NotSupportedException(
                    $"Unsupported signature algorithm: {alg}")
            };


            var signer = SignerUtilities.GetSigner(signAlg);


            var publicKey = certificate.GetPublicKey();

            signer.Init(false, publicKey);


            byte[] processBuffer = Encoding.UTF8.GetBytes(body);

            signer.BlockUpdate(
                processBuffer,
                0,
                processBuffer.Length);


            byte[] signatureBytes = Convert.FromBase64String(sign);

            bool isValid = signer.VerifySignature(signatureBytes);


            return isValid;
        }
    }
}
