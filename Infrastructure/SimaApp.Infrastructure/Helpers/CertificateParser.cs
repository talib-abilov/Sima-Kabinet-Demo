using SimaApp.Application.DTOS.Sima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Helpers
{
    public static class CertificateParser
    {
        public static CertificateObjectDto ParseToObject(string cert)
        {
            var certificateData = Convert.FromBase64String(cert);
            X509Certificate2 certificate;
            try
            {
                certificate = new X509Certificate2(certificateData);
            }
            catch (Exception e)
            {
                throw new Exception($"X509Error: Failed to parse certificate. {e.Message}", e);
            }

            // Extracting information from the certificate
            var subject = certificate.Subject;
            var issuer = certificate.Issuer;
            var validFrom = certificate.NotBefore;
            var validTo = certificate.NotAfter;
            var serialNumber = certificate.SerialNumber;
            var thumbprint = certificate.Thumbprint;

            var subjectStr = subject;
            var issuerStr = issuer;
            var validFromStr = validFrom.ToString("yyyy-MM-dd");
            var validToStr = validTo.ToString("yyyy-MM-dd");
            string? position = default;

            if (subject.Contains(", T="))
            {
                var subjectParts = subject.Split(", T=");
                if (subjectParts.Length >= 2)
                {
                    subjectStr = subjectParts[0];
                    position = subjectParts[1].Replace("\"", "");
                }
            }

            var keyValuePairs = ParseSubjectKeyValues(subjectStr);

            var result = new CertificateObjectDto
            {
                Pin = keyValuePairs.TryGetValue("SERIALNUMBER", out var value1) ? value1 : null,
                Name = keyValuePairs.TryGetValue("G", out var value2) ? value2 : null,
                Surname = keyValuePairs.TryGetValue("SN", out var value3) ? value3 : null,
                Fullname = keyValuePairs.TryGetValue("CN", out var value4) ? value4 : null,
                TaxId = keyValuePairs.TryGetValue("OU", out var value5)
                    ? (value5.Length >= 10 ? value5[^10..] : value5)
                    : null,
                OrganizationName = keyValuePairs.TryGetValue("O", out var value) ? value : null,
                Position = position,

                IsCeo = !string.IsNullOrEmpty(position) && position == "Hüquqi Təmsilçi",
                CertificateSerialNumber = serialNumber,
                CertificateThumbprint = thumbprint
            };

            return result;
        }

        /// <summary>
        /// Parses DN subject string handling quoted values that may contain commas (e.g. O="TAX, AUDIT MMC").
        /// </summary>
        private static Dictionary<string, string> ParseSubjectKeyValues(string subjectStr)
        {
            var parts = subjectStr.Split(", ");
            var reconstructed = new List<string>();

            foreach (var part in parts)
            {
                if (part.Contains("="))
                {
                    reconstructed.Add(part);
                }
                else if (reconstructed.Count > 0)
                {
                    reconstructed[^1] = reconstructed[^1] + ", " + part;
                }
            }

            return reconstructed
                .Select(p => p.Split("=", 2, StringSplitOptions.None))
                .Where(infos => infos.Length >= 2)
                .ToDictionary(infos => infos[0].Trim(), infos => infos[1].Trim().Trim('"'));
        }
    }
}
