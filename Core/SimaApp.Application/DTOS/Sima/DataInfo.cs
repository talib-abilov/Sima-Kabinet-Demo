using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class DataInfo
    {
        public string DataURI { get; set; } = null!;
        public string? AlgName { get; set; }
        public string? FingerPrint { get; set; }
    }
}
