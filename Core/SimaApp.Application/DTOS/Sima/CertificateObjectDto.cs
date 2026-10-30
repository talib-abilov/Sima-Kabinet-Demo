using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class CertificateObjectDto
    {
       public string Pin {  get; set; }
       public string Name {  get; set; }
       public string Surname {  get; set; }
       public string Fullname {  get; set; }
       public string TaxId {  get; set; }
       public string OrganizationName {  get; set; }
       public bool IsCeo {  get; set; }
       public string CertificateSerialNumber {  get; set; }
       public string CertificateThumbprint {  get; set; }
        public string Position { get; set; }
    }
}
