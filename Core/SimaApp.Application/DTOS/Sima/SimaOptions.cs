using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class SimaOptions
    {
        public int ClientId { get; set; }
        public string MasterKey { get; set; } = null!;
        public string TheKeyAlgName { get; set; } = null!;
    }
}
