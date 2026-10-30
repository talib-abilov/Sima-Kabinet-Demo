using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class Contract
    {
        public SignableContainer SignableContainer { get; set; } = null!;
        public Header Header { get; set; } = null!;
    }
}
